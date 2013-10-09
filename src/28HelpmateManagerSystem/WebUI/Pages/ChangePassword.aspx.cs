using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using WebUI.Utility;

namespace WebUI.Pages
{
    public partial class ChangePassword : RequiredLogin
    {
        public override void PageLoad()
        {
            base.PageLoad();
            btnOK.ServerClick += new EventHandler(btnOK_ServerClick);
        }

        void btnOK_ServerClick(object sender, EventArgs e)
        {
            var oldPsw = OldPsw.Value;
            var newPsw = NewPsw.Value;
            var message = SystemUserLogic.ChangePwd(SessionVal.UserSysNo,oldPsw,newPsw);
            if(!string.IsNullOrEmpty(message))
            {
                Alert(message);
            }
            else
            {
                Alert("修改成功");
            }
        }

    }
}