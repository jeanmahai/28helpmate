using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace _28Helpmate.WebSocketServer
{
    public class Global:System.Web.HttpApplication
    {
        private readonly SocketServer MySocketServer=new SocketServer();
        protected void Application_Start(object sender,EventArgs e)
        {
            MySocketServer.Start();
        }

        protected void Session_Start(object sender,EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender,EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender,EventArgs e)
        {

        }

        protected void Application_Error(object sender,EventArgs e)
        {

        }

        protected void Session_End(object sender,EventArgs e)
        {

        }

        protected void Application_End(object sender,EventArgs e)
        {

        }
    }
}