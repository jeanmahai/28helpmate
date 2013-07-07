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

            //pnlLoading.Controls.Add(LoadingCtrl.LoadModel());
            //bgwUserLogin.RunWorkerAsync();
        }

        private void bgwUserLogin_DoWork(object sender, DoWorkEventArgs e)
        {
          
        }

        private void bgwUserLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnLogin.Enabled = true;
            if (Convert.ToBoolean(e.Result))
            {
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(AppMessage.Right, "Sql连接成功！"));
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(AppMessage.Error, "请检查输入信息,Sql连接错误！"));
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
          
        }
    }
}
