using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.UI.Forms.Models;
using Helpmate.Facades;
using Helpmate.BizEntity;
using Helpmate.UI.Forms.UIContorl.Common;
using Helpmate.Facades.LotteryWebSvc;
using Common.Utility;
using Helpmate.BizEntity.Enum;
using Helpmate.UI.Forms.Code;
using Helpmate.QueryFilter;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class UserInfo : Form, IPage
    {
        public CommonFacade serviceFacade = new CommonFacade();
        public List<SiteModel> SiteMapList { get; set; }
        public OpaqueCommand cmd = new OpaqueCommand();

        public UserInfo()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel(){ Text="个人中心"}
            };
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            ddlQuestion1.DataSource = UtilsTool.ProtectionQuestion();
            ddlQuestion2.DataSource = UtilsTool.ProtectionQuestion();
            QueryData();
        }
        public void QueryData(int? pageIndex = null)
        {
            if (!bgworkerUserInfo.IsBusy)
            {
                cmd.ShowOpaqueLayer(this, 125, true);
                bgworkerUserInfo.RunWorkerAsync();
            }
        }        

        #region 获取用户信息
        private void bgworkerUserInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = serviceFacade.GetUserInfo();
        }
        private void bgworkerUserInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmd.HideOpaqueLayer();
            var result = e.Result as ResultRMOfUser;

            if (e.Error != null)
            {
                WriteLog.Write("GetUserInfo", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result) && result.Data != null)
            {
                lblUserName.Text = result.Data.UserName;
                lblUserID.Text = result.Data.UserID;
                lblPhone.Text = result.Data.Phone;
                lblQQ.Text = result.Data.QQ;
            }
        }
        #endregion
        
        #region 充值
        private void btnPay_Click(object sender, EventArgs e)
        {
            string cardID = tbxPayCardID.Text.Trim();
            string cardPwd = tbxPayPwd.Text.Trim();
            if (string.IsNullOrEmpty(cardID))
            {
                MessageBox.Show("必须输入卡号！");
            }
            else if (string.IsNullOrEmpty(cardPwd))
            {
                MessageBox.Show("必须输入密码！");
            }
            else
            {
                if (!bgworkerPay.IsBusy)
                {
                    cmd.ShowOpaqueLayer(this, 125, true);
                    Pay item = new Pay();
                    item.CardID = cardID;
                    item.CardPwd = cardPwd;
                    bgworkerPay.RunWorkerAsync(item);
                }
            }
        }
        private void bgworkerPay_DoWork(object sender, DoWorkEventArgs e)
        {
            Pay item = e.Argument as Pay;
            string cardID = tbxPayCardID.Text.Trim();
            string cardPwd = tbxPayPwd.Text.Trim();
            e.Result = serviceFacade.Pay(item.CardID, item.CardPwd);
        }
        private void bgworkerPay_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmd.HideOpaqueLayer();
            var result = e.Result as ResultRMOfBoolean;

            if (e.Error != null)
            {
                WriteLog.Write("Pay", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result) && result.Data != null)
            {
                tbxPayCardID.Text = "";
                tbxPayPwd.Text = "";
                MessageBox.Show("充值成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 修改密码
        private void btnIssue_Click(object sender, EventArgs e)
        {
            string question1 = ddlQuestion1.SelectedValue.ToString();
            string question2 = ddlQuestion2.SelectedValue.ToString();
            string answer1 = tbxAnswer1.Text.Trim();
            string answer2 = tbxAnswer2.Text.Trim();
            string oldPwd = tbxOldPwd.Text.Trim();
            string newPwd = tbxNewPwd.Text.Trim();
            if (string.IsNullOrEmpty(question1) && string.IsNullOrEmpty(question2))
            {
                MessageBox.Show("至少需要选择一个密保问题！");
            }
            else if (string.IsNullOrEmpty(answer1) && string.IsNullOrEmpty(answer2))
            {
                MessageBox.Show("至少需要输入一个密保问题答案！");
            }
            else if (string.IsNullOrEmpty(oldPwd))
            {
                MessageBox.Show("必须输入旧密码！");
            }
            else if (string.IsNullOrEmpty(newPwd))
            {
                MessageBox.Show("必须输入新密码！");
            }
            else
            {
                if (!bgworkerChangePwd.IsBusy)
                {
                    cmd.ShowOpaqueLayer(this, 125, true);
                    ChangePwd item = new ChangePwd();
                    item.OldPwd = oldPwd;
                    item.NewPwd = newPwd;
                    item.Q1 = question1;
                    item.A1 = answer1;
                    item.Q2 = question2;
                    item.A2 = answer2;
                    bgworkerChangePwd.RunWorkerAsync(item);
                }
            }
        }
        private void bgworkerChangePwd_DoWork(object sender, DoWorkEventArgs e)
        {
            ChangePwd item = e.Argument as ChangePwd;
            e.Result = serviceFacade.ChangePwd(item.Q1, item.Q2, item.A1, item.A2, item.OldPwd, item.NewPwd);
        }
        private void bgworkerChangePwd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmd.HideOpaqueLayer();
            var result = e.Result as ResultRMOfObject;

            if (e.Error != null)
            {
                WriteLog.Write("ChangePwd", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result) && result.Data != null)
            {
                ddlQuestion1.SelectedIndex = 0;
                ddlQuestion2.SelectedIndex = 0;
                tbxAnswer1.Text = "";
                tbxAnswer2.Text = "";
                tbxOldPwd.Text = "";
                tbxNewPwd.Text = "";
                MessageBox.Show("修改成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
