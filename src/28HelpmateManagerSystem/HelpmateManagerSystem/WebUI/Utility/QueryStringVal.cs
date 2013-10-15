using System.Web;

namespace WebUI.Utility
{
    public class QueryStringVal
    {
        private static HttpRequest Request { get { return HttpContext.Current.Request; } }

        public static string Action { get { return Request.QueryString["Action"]; } }

        public static int PageIndex
        {
            get
            {
                int pageIndex;
                if (int.TryParse(Request.QueryString["PageIndex"],out pageIndex)) return pageIndex;
                return 0;
            }
        }
    }
}