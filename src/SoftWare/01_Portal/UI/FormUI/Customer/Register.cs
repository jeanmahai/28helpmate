using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.Facades.LotteryWebService;
using Common.Utility;
using Helpmate.UI.Forms.UserContorl;
using Helpmate.BizEntity.Enum;

namespace Helpmate.UI.Forms.FormUI.Customer
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        public User user = new User();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            user.UserID = txtUserID.Text.Trim();
            user.UserPwd = txtUserPwd.Text.Trim();
            user.UserName = txtUserName.Text.Trim();


            string msg = ValidationTool.IsEmpty(user.UserID, "邮箱账号");
            if (!AlertMessage(msg, txtUserID)) return;

            if (!ValidationTool.IsEmail(user.UserID))
            {
                AlertMessage("请输入正确的邮箱地址！", txtUserID);
                return;
            }

            msg = ValidationTool.IsEmpty(user.UserName, "昵称");
            if (!AlertMessage(msg, txtUserName)) return;

            msg = ValidationTool.IsEmpty(user.UserPwd, "密码");
            if (!AlertMessage(msg, txtUserPwd)) return;

            msg = ValidationTool.IsEmpty(txtNUserPwd.Text, "确认密码");
            if (!AlertMessage(msg, txtNUserPwd)) return;

            if (!ValidationTool.Equals(user.UserPwd, txtNUserPwd.Text.Trim()))
            {
                AlertMessage("两次输入的密码不一致！", txtNUserPwd);
                return;
            }

            if (string.IsNullOrEmpty(txtQuestionOne.Text.Trim()) && string.IsNullOrEmpty(txtQuestionTwo.Text.Trim()))
            {
                AlertMessage("必须至少有一个密码保护问题！", txtQuestionOne);
                return;
            }

            if (!string.IsNullOrEmpty(txtQuestionOne.Text.Trim()) && string.IsNullOrEmpty(txtAnswerOne.Text.Trim()))
            {
                AlertMessage("请输入密码问题答案一！", txtAnswerOne);
                return;
            }

            if (!string.IsNullOrEmpty(txtQuestionTwo.Text.Trim()) && string.IsNullOrEmpty(txtAnswerTwo.Text.Trim()))
            {
                AlertMessage("请输入密码问题答案二！", txtAnswerTwo);
                return;
            }
            
            btnRegister.Enabled = false;
            btnCancel.Enabled = false;
            pnlLoading.Controls.Clear();
            pnlLoading.Controls.Add(LoadingCtrl.LoadModel());
            bgwRegister.RunWorkerAsync();
        }

        private bool AlertMessage(string msg, TextBox txtObj)
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


        }

        private void bgwRegister_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnRegister.Enabled = false;
            btnCancel.Enabled = false;
            pnlLoading.Controls.Clear();

            if (e.Error != null)
            {
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, "用户注册失败，请稍后再试！"));
                return;
            }


        }
    }
}
