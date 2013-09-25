using System.Web;

namespace WebUI.Utility
{
    public class QueryStringVal
    {
        private static HttpRequest Request{get { return HttpContext.Current.Request; }}

        public static string Action { get { return Request.QueryString["Action"]; } }
    }
}