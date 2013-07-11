using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.UI.Forms.UserContorl;
using Helpmate.BizEntity.Enum;
using Utility.Update;
using Common.Utility;
using System.Diagnostics;
using Helpmate.Facades.LotteryWebService;
using Helpmate.UI.Forms.FormUI.Customer;

namespace Helpmate.UI.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public User user = new User();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            user.UserName = txtUserName.Text.Trim();
            user.UserPwd = txtUserPwd.Text;

            pnlLoading.Controls.Clear();

            string msg = ValidationTool.IsEmpty(user.UserName, "用户名");
            if (!string.IsNullOrEmpty(msg)) { pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, msg)); txtUserName.Focus(); return; }

            msg = ValidationTool.IsEmpty(user.UserPwd, "密码");
            if (!string.IsNullOrEmpty(msg)) { pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, msg)); txtUserPwd.Focus(); return; }

            btnLogin.Enabled = false;
            pnlLoading.Controls.Add(LoadingCtrl.LoadModel());

            bgwUserLogin.RunWorkerAsync();
            //bgwUpdate.RunWorkerAsync();
        }

        private void backgroundUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateClass updater = new UpdateClass();
            var list = updater.CheckForUpdates();
            e.Result = list.Length > 0;
        }

        private void backgroundUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnLogin.Enabled = true;
            pnlLoading.Controls.Clear();

            if (e.Error != null)
            {
                AppMessage.AlertMessage("请检查网络是否正常，稍后再试！");
                return;
            }

            if (Convert.ToBoolean(e.Result))
            {
                UtilsTool.Alert("发现新的版本，立即更新！");
                Process.Start("Update.exe", "121");
            }
            else
            {
                bgwUserLogin.RunWorkerAsync();
            }
        }

        private void bgwUserLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            if (user.UserName == "admin" && user.UserPwd == "admin")
            {
                e.Result = 800;
            }
            else
            {
                e.Result = 400;
            }
        }

        private void bgwUserLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnLogin.Enabled = true;
            if (e.Error != null)
            {
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, "用户登录失败，请稍后再试！"));
                return;
            }

            switch (Convert.ToInt32(e.Result))
            {
                case 800:
                    this.DialogResult = DialogResult.OK;
                    break;

                case 400:
                    pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, "用户或密码错误！"));
                    break;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var register = new Register();
            register.ShowDialog();
        }
    }
}
