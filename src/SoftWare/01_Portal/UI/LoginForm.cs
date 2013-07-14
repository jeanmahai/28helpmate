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
using Helpmate.UI.Forms.FormUI.Customer;
using Helpmate.Facades.LotteryWebSvc;
using Helpmate.Facades;


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

            if (!ValidationTool.IsEmail(user.UserName))
            {
                AlertMessage("请输入正确的邮箱地址！", txtUserName); return;
            }

            msg = ValidationTool.IsEmpty(user.UserPwd, "密码");
            if (!string.IsNullOrEmpty(msg)) { pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, msg)); txtUserPwd.Focus(); return; }

            msg = ValidationTool.IsEmpty(txtCode.Text.Trim(), "验证码");
            if (!string.IsNullOrEmpty(msg)) { pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, msg)); txtCode.Focus(); return; }

            btnLogin.Enabled = false;
            btnRegister.Enabled = false;
            pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Loading, "正在登录..."));
            bgwUserLogin.RunWorkerAsync();
        }

        private bool AlertMessage(string msg, Control txtObj)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, msg));
                txtObj.Focus();
                return false;
            }
            return true;
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
            btnRegister.Enabled = true;
            pnlLoading.Controls.Clear();

            if (e.Error != null)
            {
                AppMessage.AlertErrMessage("请检查网络是否正常，稍后再试！");
                return;
            }

            if (Convert.ToBoolean(e.Result))
            {
                AppMessage.Alert("发现新的版本，立即更新！");
                Process.Start("Update.exe", "121");
            }
            else
            {
                btnLogin.Enabled = false;
                btnRegister.Enabled = false;
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Loading, "正在加载验证码！"));
                bgwCode.RunWorkerAsync();
            }
        }

        private void bgwUserLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            var customer = new CustomerFacade();
            e.Result = customer.UserLogin(user.UserName, user.UserPwd, txtCode.Text.Trim());
        }

        private void bgwUserLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnLogin.Enabled = true;
            btnRegister.Enabled = true;
            pnlLoading.Controls.Clear();

            if (e.Error != null)
            {
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, "用户登录失败，请稍后再试！"));
                return;
            }

            var result = e.Result as ResultRMOfString;
            if (!result.Success)
            {
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, result.Message));
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var register = new Register();
            register.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            btnLogin.Enabled = false;
            btnRegister.Enabled = false;
            pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Loading, "正在检查版本更新..."));
            bgwUpdate.RunWorkerAsync();
        }

        private void bgwCode_DoWork(object sender, DoWorkEventArgs e)
        {
            var customer = new CustomerFacade();
            e.Result = customer.LoadCode();

        }

        private void bgwCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnLogin.Enabled = true;
            btnRegister.Enabled = true;
            pnlLoading.Controls.Clear();

            if (e.Error != null)
            {
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, "加载验证码失败，请稍后再试！"));
                return;
            }

            ValidCode code = new ValidCode(6, ValidCode.CodeType.Numbers);
            picCode.Image = code.CreateCheckCodeImage(e.Result.ToString());
        }

        private void picCode_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            btnRegister.Enabled = false;
            pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Loading, "正在加载验证码！"));
            bgwCode.RunWorkerAsync();
        }
    }
}
