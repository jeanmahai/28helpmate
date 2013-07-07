using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebService
{
    public class Global:System.Web.HttpApplication
    {

        protected void Application_Start(object sender,EventArgs e)
        {

        }

        protected void Session_Start(object sender,EventArgs e)
        {
            Session[SessionValue.TOKEN] = "";
            Session[SessionValue.USER_NAME] = "";
        }

        protected void Application_BeginRequest(object sender,EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender,EventArgs e)
        {

        }

        protected void Application_Error(object sender,EventArgs e)
        {
            var ex = Server.GetLastError().GetBaseException();
            MyTree.Utility.Log.Log4netExt.Error(ex.ToString());
        }

        protected void Session_End(object sender,EventArgs e)
        {

        }

        protected void Application_End(object sender,EventArgs e)
        {

        }
    }
}