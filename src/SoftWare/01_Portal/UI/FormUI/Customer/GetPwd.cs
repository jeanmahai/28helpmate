using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Helpmate.UI.Forms.UserContorl;
using System.Windows.Forms;
using Helpmate.Facades.LotteryWebSvc;
using Common.Utility;
using Helpmate.BizEntity.Enum;
using Helpmate.Facades;

namespace Helpmate.UI.Forms.FormUI.Customer
{
    public partial class GetPwd : Form
    {
        public GetPwd()
        {
            InitializeComponent();
        }
        public User user = new User();
        private void GetPwd_Load(object sender, EventArgs e)
        {
            cmbQuestionOne.DataSource = UtilsTool.ProtectionQuestion();
            cmbQuestionTwo.DataSource = UtilsTool.ProtectionQuestion();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            user.UserID = txtUserID.Text.Trim();

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

            btnSure.Enabled = false;
            btnCancel.Enabled = false;
            pnlLoading.Controls.Clear();
            pnlLoading.Controls.Add(LoadingCtrl.LoadModel());
            bgwGetPwd.RunWorkerAsync();
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

        private void bgwGetPwd_DoWork(object sender, DoWorkEventArgs e)
        {
            var customer = new CustomerFacade();
            e.Result = customer.GetPwd(user.UserID, user.SecurityQuestion1, user.SecurityAnswer1, user.SecurityQuestion2, user.SecurityAnswer2);
        }
        private void bgwGetPwd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSure.Enabled = true;
            btnCancel.Enabled = true;
            pnlLoading.Controls.Clear();

            if (e.Error != null)
            {
                WriteLog.Write("GetPwd", e.Error.Message);
                pnlLoading.Controls.Add(LoadingCtrl.LoadModel(MessageType.Error, "找回密码失败，请稍后再试！"));
                return;
            }

            var result = e.Result as ResultRMOfString;
            if (!result.Success)
            {
                AppMessage.AlertErrMessage(result.Message);
            }
            else
            {
                lblNewPwd.Text = result.Data;
                AppMessage.Alert(string.Format("密码重置成功，新密码是：{0}！", result.Data));
            }
        }
    }
}
