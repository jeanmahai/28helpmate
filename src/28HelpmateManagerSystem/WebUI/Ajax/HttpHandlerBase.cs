using System.Web;
using System.Web.SessionState;

namespace WebUI.Ajax
{

    public class HttpHandlerBase:IReadOnlySessionState,IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            DoRequest(context);
        }

        public virtual void DoRequest(HttpContext ctx){}
    }
}