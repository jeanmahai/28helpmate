using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebService
{
    public class UserState
    {
        public string UserName { get; set; }
        public int UserSysNo { get; set; }
        public string Key { get; set; }
        public DateTime LastDateTime { get; set; }
    }
    public static class SessionValue
    {
        public const string TOKEN = "TOKEN";
        //public const string USER_NAME = "USER_NAME";
        public const string KEY = "KEY";
        public const string CODE = "CODE";

        private static HttpSessionState CurrentSession
        {
            get { return HttpContext.Current.Session; }
        }

        //public static string UserName
        //{
        //    get { return CurrentSession[USER_NAME].ToString(); }
        //    set { CurrentSession[USER_NAME] = value; }
        //}
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
        public static string Code
        {
            get { return CurrentSession[CODE].ToString(); }
            set { CurrentSession[CODE] = value; }
        }
        private static List<UserState> UserStates { get; set; }

        static SessionValue()
        {
            UserStates=new List<UserState>();
        }
        public static UserState Get(string userName)
        {
            return UserStates.Single(p => p.UserName == userName);
        }
        public static UserState Get(int userSysNo)
        {
            return UserStates.Single(p => p.UserSysNo == userSysNo);
        }
        //public static string GenerateKey(int userSysNo)
    }
    public static class UserKeys
    {
        private static object obj = new object();
        private static Dictionary<int, string> _Keys = null;
        private static Dictionary<int, string> Keys
        {
            get
            {
                if (_Keys == null)
                {
                    _Keys = new Dictionary<int, string>(100000);
                }
                return _Keys;
            }
        }
        public static void WriteKey(int userSysNo, string key)
        {
            lock (obj)
            {
                Keys[userSysNo] = key;
            }
        }
        public static string ReadKey(int userSysNo)
        {
            lock (obj)
            {
                return Keys != null && Keys.ContainsKey(userSysNo) ? Keys[userSysNo] : "";
            }
        }
    }
}