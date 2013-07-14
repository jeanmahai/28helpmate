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

namespace Helpmate.UI.Forms.FormUI
{
    public partial class UserInfo : Form, IPage
    {
        BaseFacade bf = new BaseFacade();
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
            ddlQuestion1.DataSource = UtilsTool.ProtectionQuestion();
            ddlQuestion2.DataSource = UtilsTool.ProtectionQuestion();
            QueryData();
        }

        #region 获取用户信息
        public void QueryData(int? pageIndex = null)
        {
            cmd.ShowOpaqueLayer(this, 125, true);
            QueryDataDelegate dn = new QueryDataDelegate(AsyncWaysQueryData);
            AsyncCallback acb = new AsyncCallback(CallBackMethod);
            IAsyncResult iar = dn.BeginInvoke(acb, dn);
        }
        public delegate ResultRMOfUser QueryDataDelegate();
        private ResultRMOfUser AsyncWaysQueryData()
        {
            return serviceFacade.GetUserInfo();
        }
        public void CallBackMethod(IAsyncResult ar)
        {
            QueryDataDelegate dn = (QueryDataDelegate)ar.AsyncState;
            var result = dn.EndInvoke(ar);
            this.HandleUserResultData(result);
        }
        public delegate void HandleUserResultDataCallback(ResultRMOfUser result);
        private void HandleUserResultData(ResultRMOfUser result)
        {
            if (this.btnIssue.InvokeRequired)
            {
                HandleUserResultDataCallback d = new HandleUserResultDataCallback(HandleUserResultData);
                this.Invoke(d, new object[] { result });
            }
            else
            {
                if (result != null)
                {
                    if (result.Success && result.Data != null)
                    {
                        lblUserName.Text = result.Data.UserName;
                        lblUserID.Text = result.Data.UserID;
                        lblPhone.Text = result.Data.Phone;
                        lblQQ.Text = result.Data.QQ;
                    }
                }
            }
            cmd.HideOpaqueLayer();
        }
        #endregion

        #region 充值
        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                cmd.ShowOpaqueLayer(this, 125, true);
                PayDelegate dn = new PayDelegate(AsyncWaysPay);
                AsyncCallback acb = new AsyncCallback(CallBackPay);
                IAsyncResult iar = dn.BeginInvoke(cardID, cardPwd, acb, dn);
            }
        }
        public delegate ResultRMOfObject PayDelegate(string cardID, string cardPwd);
        private ResultRMOfObject AsyncWaysPay(string cardID, string cardPwd)
        {
            return serviceFacade.Pay(cardID, cardPwd);
        }
        public void CallBackPay(IAsyncResult ar)
        {
            cmd.HideOpaqueLayer();
            PayDelegate dn = (PayDelegate)ar.AsyncState;
            var result = dn.EndInvoke(ar);
            HandlePayResultData(result);
        }
        public delegate void HandlePayResultDataCallback(ResultRMOfObject result);
        private void HandlePayResultData(ResultRMOfObject result)
        {
            if (this.btnPay.InvokeRequired)
            {
                HandlePayResultDataCallback d = new HandlePayResultDataCallback(HandlePayResultData);
                this.Invoke(d, new object[] { result });
            }
            else
            {
                if (result != null)
                {
                    if (result.Success)
                    {
                        tbxPayCardID.Text = "";
                        tbxPayPwd.Text = "";
                        MessageBox.Show("充值成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        MessageBox.Show(result.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            cmd.HideOpaqueLayer();
        }
        #endregion

        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                cmd.ShowOpaqueLayer(this, 125, true);
                ChangePwdDelegate dn = new ChangePwdDelegate(AsyncWaysChangePwd);
                AsyncCallback acb = new AsyncCallback(CallBackChangePwd);
                IAsyncResult iar = dn.BeginInvoke(oldPwd, newPwd, question1, question2, answer1, answer2, acb, dn);
            }
        }
        public delegate ResultRMOfObject ChangePwdDelegate(string question1, string question2, string answer1, string answer2, string oldPwd, string newPwd);
        private ResultRMOfObject AsyncWaysChangePwd(string question1, string question2, string answer1, string answer2, string oldPwd, string newPwd)
        {
            return serviceFacade.ChangePwd(question1, question2, answer1, answer2, oldPwd, newPwd);
        }
        public void CallBackChangePwd(IAsyncResult ar)
        {
            cmd.HideOpaqueLayer();
            ChangePwdDelegate dn = (ChangePwdDelegate)ar.AsyncState;
            var result = dn.EndInvoke(ar);
            HandleChangePwdResultData(result);
        }
        public delegate void HandleChangePwdResultDataCallback(ResultRMOfObject result);
        private void HandleChangePwdResultData(ResultRMOfObject result)
        {
            if (this.btnIssue.InvokeRequired)
            {
                HandleChangePwdResultDataCallback d = new HandleChangePwdResultDataCallback(HandleChangePwdResultData);
                this.Invoke(d, new object[] { result });
            }
            else
            {
                if (result != null)
                {
                    if (result.Success)
                    {
                        ddlQuestion1.SelectedIndex = 0;
                        ddlQuestion2.SelectedIndex = 0;
                        tbxAnswer1.Text = "";
                        tbxAnswer2.Text = "";
                        tbxOldPwd.Text = "";
                        tbxNewPwd.Text = "";
                        MessageBox.Show("修改成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            cmd.HideOpaqueLayer();
        }
        #endregion
    }
}
