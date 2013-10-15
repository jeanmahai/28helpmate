using System.Web;
using System.Web.SessionState;

namespace WebUI.Utility
{
    public class SessionVal
    {
        private static HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }
        public static string UserId
        {
            get { return Session["UserId"] == null ? "" : Session["UserId"].ToString(); }
            set { Session["UserId"] = value; }
        }
        public static int UserSysNo
        {
            get { return Session["UserSysNo"] == null ? -1 :int.Parse(Session["UserSysNo"].ToString()); }
            set { Session["UserSysNo"] = value; }
        }
    }
}