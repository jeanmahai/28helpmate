using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Utility;
using Helpmate.UI.Forms.UserContorl;
using Helpmate.BizEntity.Enum;
using Helpmate.Facades.LotteryWebSvc;
using Helpmate.Facades;

namespace Helpmate.UI.Forms.FormUI.Customer
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        public User user = new User();

        private void Register_Load(object sender, EventArgs e)
        {
            cmbQuestionOne.DataSource = UtilsTool.ProtectionQuestion();
            cmbQuestionTwo.DataSource = UtilsTool.ProtectionQuestion();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            user.UserID = txtUserID.Text.Trim();
            user.UserPwd = txtUserPwd.Text.Trim();
            user.UserName = txtUserName.Text.Trim();
            user.Phone = txtPhone.Text.Trim();
            user.QQ = txtQQ.Text.Trim();

            user.SecurityQuestion1 = cmbQuestionOne.SelectedValue.ToString();
            user.SecurityAnswer1 = txtAnswerOne.Text.Trim();
            user.SecurityQuestion2 = cmbQuestionTwo.SelectedValue.ToString();
            user.SecurityAnswer2 = txtAnswerTwo.Text.Trim();

            string msg = ValidationTool.IsEmpty(user.UserID, "邮箱账号");
            if (!AlertMessage(msg, txtUserID)) return;

            if (!ValidationTool.IsEmail(user.UserID))
            {
                AlertMessage("请输入正确的邮箱地址！", txtUserID); return;
            }

            msg = ValidationTool.IsEmpty(user.UserName, "昵称");
            if (!AlertMessage(msg, txtUserName)) return;

            if (!string.IsNullOrEmpty(user.Phone) && !ValidationTool.IsMobile(user.Phone))
            {
                AlertMessage("请输入正确的手机号码！", txtPhone); return;
            }

            msg = ValidationTool.IsEmpty(user.UserPwd, "密码");
            if (!AlertMessage(msg, txtUserPwd)) return;

            msg = ValidationTool.IsEmpty(txtNUserPwd.Text, "确认密码");
            if (!AlertMessage(msg, txtNUserPwd)) return;

            if (!ValidationTool.Equals(user.UserPwd, txtNUserPwd.Text.Trim()))
            {
                AlertMessage("两次输入的密码不一致！", txtNUserPwd); return;
            }

            if (string.IsNullOrEmpty(user.SecurityQuestion1) && string.IsNullOrEmpty(user.SecurityQuestion2))
            {
                AlertMessage("必须至少选择一个密码保护问题！", cmbQuestionOne);
                return;
            }

            if (!string.IsNullOrEmpty(user.SecurityQuestion1) && string.IsNullOrEmpty(user.SecurityAnswer1))
            {
                AlertMessage("请输入密码问题答案一！", txtAnswerOne);
                return;
            }

            if (!string.IsNullOrEmpty(user.SecurityQuestion2) && string.IsNullOrEmpty(user.SecurityAnswer2))
            {
                AlertMessage("请输入密码问题答案二！", txtAnswerTwo); return;
            }

            btnRegister.Enabled = false;
            btnCancel.Enabled = false;
            pnlLoading.Controls.Clear();
            pnlLoading.Controls.Add(LoadingCtrl.LoadModel());
            bgwRegister.RunWorkerAsync();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgwRegister_DoWork(object sender, DoWorkEventArgs e)
        {
            var customer = new CustomerFacade();
            e.Result = customer.UserRegister(user);
        }

        private void bgwRegister_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnRegister.Enabled = true;
            btnCancel.Enabled = true;
            pnlLoading.Controls.Clear();

            if (e.Error != null)
            {
                WriteLog.Write("UserRegister", e.Error.Message);
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, "用户注册失败，请稍后再试！"));
                return;
            }

            var result = e.Result as ResultRMOfString;
            if (!result.Success)
            {
                AppMessage.AlertErrMessage(result.Message);
            }
            else
            {
                AppMessage.Alert("恭喜您，注册成功！");
                this.Close();
            }
        }
    }
}
