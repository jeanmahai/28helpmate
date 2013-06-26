using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.IO;

namespace Common.Utility
{
    public class WebPrintHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return false; }
        }

        private IPrintDataBuild CreateDataBuilder(string dataBuilderTypeName)
        {
            Type type = Type.GetType(dataBuilderTypeName, true);
            return (IPrintDataBuild)Activator.CreateInstance(type);
        }

        private IWebPrint CreatePrinter(string extention)
        {
            string typeName = WebPrintConfig.GetHandlerTypeName(extention);
            if (string.IsNullOrWhiteSpace(typeName))
            {
                throw new ApplicationException("Not config print handler for '." + extention + "' template file in config file '" + WebPrintConfig.GetConfigFilePath() + "'.");
            }
            Type type = Type.GetType(typeName, true);
            return (IWebPrint)Activator.CreateInstance(type);
        }

        public void ProcessRequest(HttpContext context)
        {
            string name = context.Request.QueryString["ECCentral_WebPrinter_Name"];
            string languageCode = context.Request.QueryString["ECCentral_WebPrinter_languageCode"];

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(languageCode);

            string templateFileFullPath;
            string dataBuilderTypeName;
            WebPrintConfig.GetPrinterSetting(name, languageCode, out templateFileFullPath, out dataBuilderTypeName);
            if (string.IsNullOrWhiteSpace(dataBuilderTypeName))
            {
                throw new ApplicationException("Not config data builder for web printer '" + name + "' in config file '" + WebPrintConfig.GetConfigFilePath() + "'.");
            }
            if (string.IsNullOrWhiteSpace(templateFileFullPath))
            {
                throw new ApplicationException("Not config template file for web printer '" + name + "' in language '" + languageCode + "' in config file '" + WebPrintConfig.GetConfigFilePath() + "'.");
            }
            string templateExtention = Path.GetExtension(templateFileFullPath).Trim('.');

            IWebPrint printer = CreatePrinter(templateExtention);
            IPrintDataBuild dataBuilder = CreateDataBuilder(dataBuilderTypeName);

            KeyValueVariables variables;
            KeyTableVariables tableVariables;
            dataBuilder.BuildData(context.Request.Form, out variables, out tableVariables);
            printer.RenderHtmlForPrint(context, templateFileFullPath, variables, tableVariables);
        }
    }
}
