using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.utility
{
    public class FormVal
    {
        private static HttpRequest Request { get { return HttpContext.Current.Request; } }
        public static string UserId{get { return Request.Form["UserId"]; }}
        public static string Password{get { return Request.Form["Password"]; }}
        public static string Action{get { return Request.Form["Action"]; }}
        public static string OldPsw { get { return Request.Form["OldPsw"]; } }
        public static string NewPsw { get { return Request.Form["NewPsw"]; } }
    }
}