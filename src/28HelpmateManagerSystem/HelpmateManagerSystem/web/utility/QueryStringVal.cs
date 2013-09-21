using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.utility
{
    public class QueryStringVal
    {
        private static HttpRequest Request{get { return HttpContext.Current.Request; }}

        public static string Action { get { return Request.QueryString["Action"]; } }
    }
}