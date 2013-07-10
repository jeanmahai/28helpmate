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

namespace Helpmate.UI.Forms
{
    public partial class LoginForm : Form
    {
        private string dbAddress = string.Empty;
        private string dbName = string.Empty;
        private string userName = string.Empty;
        private string userPwd = string.Empty;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //btnLogin.Enabled = false;
            //dbAddress = txtSqlAddress.Text.Trim();
            //dbName = txtDBName.Text.Trim();
            //userName = txtUserName.Text.Trim();
            //userPwd = txtUserPwd.Text.Trim();

            //pnlLoading.Controls.Clear();

            //string msg = ValidationTool.IsEmpty(dbAddress, "Sql连接地址");
            //if (!string.IsNullOrEmpty(msg)) { pnlLoading.Controls.Add(LoadingCtrl.LoadModel(AppMessage.Error, msg)); txtSqlAddress.Focus(); return; }

            //msg = ValidationTool.IsEmpty(dbName, "数据库名称");
            //if (!string.IsNullOrEmpty(msg)) { pnlLoading.Controls.Add(LoadingCtrl.LoadModel(AppMessage.Error, msg)); txtDBName.Focus(); return; }

            //msg = ValidationTool.IsEmpty(userName, "用户名");
            //if (!string.IsNullOrEmpty(msg)) { pnlLoading.Controls.Add(LoadingCtrl.LoadModel(AppMessage.Error, msg)); txtUserName.Focus(); return; }

            //msg = ValidationTool.IsEmpty(userPwd, "密码");
            //if (!string.IsNullOrEmpty(msg)) { pnlLoading.Controls.Add(LoadingCtrl.LoadModel(AppMessage.Error, msg)); txtUserPwd.Focus(); return; }

            pnlLoading.Controls.Add(LoadingCtrl.LoadModel());
            bgwUserLogin.RunWorkerAsync();
        }

        private void bgwUserLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateClass updater = new UpdateClass();
            var list = updater.CheckForUpdates();
            e.Result = list.Length > 0;
        }

        private void bgwUserLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                AppMessage.AlertMessage("请检查网络连接是否正常，客户端检测更新失败！");
                this.Close();
            }
            else if (Convert.ToBoolean(e.Result))
            {
                UtilsTool.Alert("发现新的版本，立即更新！");
                Process.Start("Update.exe", "121");
            }

            btnLogin.Enabled = true;
            if (Convert.ToBoolean(e.Result))
            {
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Right, "Sql连接成功！"));
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, "请检查输入信息,Sql连接错误！"));
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
