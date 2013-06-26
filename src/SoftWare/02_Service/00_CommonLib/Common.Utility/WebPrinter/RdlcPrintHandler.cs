using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Collections.Specialized;
using System.Threading;

namespace Common.Utility
{
    public class RdlcPrintHandler : IWebPrint
    {
        public void RenderHtmlForPrint(HttpContext context, string templateFileFullPath,
            KeyValueVariables variables, KeyTableVariables tableVariables)
        {
            using (RdlcPrintPage page = new RdlcPrintPage())
            {
                HtmlGenericControl c = new HtmlGenericControl("html");
                page.Controls.Add(c);

                HtmlHead head = new HtmlHead();
                head.ID = "head1";
                c.Controls.Add(head);

                HtmlGenericControl b = new HtmlGenericControl("body");
                c.Controls.Add(b);

                HtmlForm form = new HtmlForm();
                form.ID = "form1";
                b.Controls.Add(form);

                ScriptManager scriptHandler = new ScriptManager();
                scriptHandler.ID = "ScriptManager1";
                form.Controls.Add(scriptHandler);

                ReportViewer rv = new ReportViewer();
                rv.ShowExportControls = false;
                rv.SizeToReportContent = true;
                rv.Width = new System.Web.UI.WebControls.Unit("100%");
                form.Controls.Add(rv);

                rv.LocalReport.ReportPath = templateFileFullPath;

                if (variables != null)
                {
                    foreach (var entry in variables)
                    {
                        string tmp = CovertToString(entry.Value);
                        rv.LocalReport.SetParameters(new ReportParameter(entry.Key, tmp));
                    }
                }

                rv.LocalReport.DataSources.Clear();
                if (tableVariables != null)
                {
                    foreach (var entry in tableVariables)
                    {
                        rv.LocalReport.DataSources.Add(new ReportDataSource(entry.Key, entry.Value));
                    }
                }

                rv.LocalReport.Refresh();
                page.ProcessRequest(context);
            }

            // 禁用缓存
            context.Response.Expires = -1;
            context.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            context.Response.CacheControl = "no-cache";
            context.Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.Cache.SetNoStore();

            //context.Response.ContentType = "text/html";
            context.Response.Flush();
        }

        private string CovertToString(object value)
        {
            if (value == null || value == DBNull.Value || value.ToString().Trim().Length <= 0)
            {
                return string.Empty;
            }
            Type type = value.GetType();
            while (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)
                    && type.GetGenericArguments() != null
                    && type.GetGenericArguments().Length == 1 && type.IsEnum)
            {
                type = type.GetGenericArguments()[0];
            }
            if (type.IsEnum)
            {
                return ((Enum)value).ToDisplayText();
            }
            else
            {
                return value.ToString();
            }
        }

        private class RdlcPrintPage : Page
        {
            public override void VerifyRenderingInServerForm(Control control)
            {

            }

            public override bool EnableEventValidation
            {
                get { return false; }
                set { }
            }
        }
    }
}
