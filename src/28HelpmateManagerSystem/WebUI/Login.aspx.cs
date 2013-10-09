using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataEntity;
using Logic;
using WebUI.Utility;
using DataEntity.QueryFilter;

namespace WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NoticesQueryFilter queryFilter = new NoticesQueryFilter();
            queryFilter.PageCount = 0;
            queryFilter.PageIndex = 1;
            queryFilter.PageSize = 10;

            NoticesLogic.QueryNotices(queryFilter);

            btnOK.ServerClick += new EventHandler(btnOK_ServerClick);
        }
        public void Alert(string message)
        {
            ScriptManager.RegisterStartupScript(this,
                GetType(),
                string.Format("alert_{0}",new Random().Next(1000)),
                string.Format("$(document).ready(function(){{ var timer=setTimeout(function(){{alert('{0}');clearTimeout(timer)}},1000); }}); ",message),
                true);
        }

        void btnOK_ServerClick(object sender, EventArgs e)
        {
            var userId = UserId.Value;
            var psw = Password.Value;
            SystemUser user;
            var message = SystemUserLogic.Login(userId, psw, "127.0.0.1", out user);
            if (!string.IsNullOrEmpty(message))
            {
                Alert(message);
            }
            else
            {
                SessionVal.UserId = userId;
                SessionVal.UserSysNo = user.SysNo;
                Response.Redirect("/Index.aspx");
            }
        }

    }
}