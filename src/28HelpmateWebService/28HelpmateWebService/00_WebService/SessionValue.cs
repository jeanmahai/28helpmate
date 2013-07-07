using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebService
{
    public class SessionValue
    {
        public const string TOKEN = "TOKEN";
        public const string USER_NAME = "USER_NAME";
        public const string KEY = "KEY";

        private static HttpSessionState CurrentSession
        {
            get { return HttpContext.Current.Session; }
        }

        public static string UserName
        {
            get { return CurrentSession[USER_NAME].ToString(); }
            set { CurrentSession[USER_NAME] = value; }
        }
        public static string Token
        {
            get { return CurrentSession[TOKEN].ToString(); }
            set { CurrentSession[TOKEN] = value; }
        }
        public static string Key
        {
            get { return CurrentSession[KEY].ToString(); }
            set { CurrentSession[KEY] = value; }
        }
    }
}