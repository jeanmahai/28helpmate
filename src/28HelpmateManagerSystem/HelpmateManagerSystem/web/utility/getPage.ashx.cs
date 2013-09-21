using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace web.utility
{
    /// <summary>
    /// getPage 的摘要说明
    /// </summary>
    public class getPage:HttpHandlerBase
    {
        public override void DoRequest(HttpContext ctx)
        {
            var pageName = ctx.Request.QueryString["pageName"];
            ctx.Response.Write(FindPage(pageName));
        }

        private string FindPage(string pageName)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            path = Path.Combine(path,"res","pages",pageName + ".htm");
            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path,Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            return "";
        }
    }
}