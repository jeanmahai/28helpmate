using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Business;

namespace WebService
{
    public class Global:System.Web.HttpApplication
    {
        private static LotteryDAL Dal=new LotteryDAL();

        protected void Application_Start(object sender,EventArgs e)
        {

        }

        protected void Session_Start(object sender,EventArgs e)
        {
            //Session[SessionValue.TOKEN] = "";
            //Session[SessionValue.USER_NAME] = "";
            MyTree.Utility.Log.Log4netExt.Info(Dal.GetClientIP());
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

            //Response.Write("系统错误");
            //Response.End();
        }

        protected void Session_End(object sender,EventArgs e)
        {

        }

        protected void Application_End(object sender,EventArgs e)
        {

        }
    }
}