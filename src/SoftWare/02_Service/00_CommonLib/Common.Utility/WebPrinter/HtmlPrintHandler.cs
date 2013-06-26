using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Web;
using System.Configuration;
using System.Threading;
using System.Text.RegularExpressions;
using System.Data;

namespace Common.Utility
{
    public class HtmlPrintHandler : IWebPrint
    {
        private string BuildHtml(string templateFileFullPath, KeyValueVariables variables, KeyTableVariables tableVariables)
        {
            string html = File.ReadAllText(templateFileFullPath, Encoding.UTF8);
            return TemplateString.BuildHtml(html, variables, tableVariables);
        }

        public void RenderHtmlForPrint(HttpContext context, string templateFileFullPath,
            KeyValueVariables variables, KeyTableVariables tableVariables)
        {
            // 禁用缓存
            context.Response.Expires = -1;
            context.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            context.Response.CacheControl = "no-cache";
            context.Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.Cache.SetNoStore();

            context.Response.ContentType = "text/html";

            string html = BuildHtml(templateFileFullPath, variables, tableVariables);

            context.Response.Write(html);
            context.Response.Flush();
        }
    }
}
