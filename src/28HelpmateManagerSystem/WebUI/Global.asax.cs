using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using WebUI.Utility;
using Common.Utility;

namespace WebUI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AutorunManager.Startup(ex => Common.Utility.Logger.WriteLog(ex.ToString(), "Protal_Exception"));
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                Common.Utility.Logger.WriteLog(ex.ToString(), "Protal_Exception");
            }
        }


        protected void Session_Start(object sender, EventArgs e)
        {
            SessionVal.UserId = "";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = HttpContext.Current.Server.GetLastError();
            if (ex != null)
            {
                Common.Utility.Logger.WriteLog(ex.ToString(), "Protal_Exception");
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            AutorunManager.Shutdown(ex => Common.Utility.Logger.WriteLog(ex.ToString(), "Protal_Exception"));
        }
    }
}