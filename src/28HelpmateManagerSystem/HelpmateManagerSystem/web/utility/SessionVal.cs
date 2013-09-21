using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace web.utility
{
    public class SessionVal
    {
        private static HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }
        public static string UserId
        {
            get { return Session["UserId"].ToString(); } 
            set { Session["UserId"] = value; }
        }
    }
}