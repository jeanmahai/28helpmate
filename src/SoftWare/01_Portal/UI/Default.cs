using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.UI.Forms.FormUI;
using Helpmate.BizEntity.Enum;
using Helpmate.BizEntity;
using Helpmate.UI.Forms.UserContorl.Common;
using Helpmate.Facades;
using Helpmate.UI.Forms.Models;
using Helpmate.Facades.LotteryWebSvc;
using Common.Utility;
using Helpmate.UI.Forms.Code;

namespace Helpmate.UI.Forms
{
    public partial class Default : Form
    {
        public CommonFacade serviceFacade = new CommonFacade();

        public Default()
        {
            InitializeComponent();
        }

        private void Default_Load(object sender, EventArgs e)
        {
            Header.GameSourceSysNo = 10001;
            Header.RegionSourceSysNo = Convert.ToInt32(lblBJ.Tag);
            Header.SiteSourceSysNo = Convert.ToInt32(lbl71.Tag);

            bgwApp.RunWorkerAsync();
            bgwNews.RunWorkerAsync();

            var childForm = new UserInfo();
            CurrMenu(MenuEnum.User, childForm.SiteMapList, childForm);
            lblServerTime.Text = serviceFacade.GetServerDate().ToString();
        }

        private void pnlHome_Click(object sender, EventArgs e)
        {
            var childForm = new Home();
            CurrMenu(MenuEnum.Home, childForm.SiteMapList, childForm);
            RefreshPage();
        }

        private void pnlSuperTrend_Click(object sender, EventArgs e)
        {
            var childForm = new SuperTrend();
            CurrMenu(MenuEnum.SuperTrend, childForm.SiteMapList, childForm);
            RefreshPage();
        }

        private void pnlOmission_Click(object sender, EventArgs e)
        {
            var childForm = new Omission();
            CurrMenu(MenuEnum.Omission, childForm.SiteMapList, childForm);
            RefreshPage();
        }

        private void pnlNormalTrend_Click(object sender, EventArgs e)
        {
            var childForm = new NormalTrend();
            CurrMenu(MenuEnum.NormalTrend, childForm.SiteMapList, childForm);
            RefreshPage();
        }

        private void pnlPay_Click(object sender, EventArgs e)
        {
            var childForm = new UserInfo();
            CurrMenu(MenuEnum.Pay, childForm.SiteMapList, childForm);
            RefreshPage();
        }

        private void pnlUser_Click(object sender, EventArgs e)
        {
            var childForm = new UserInfo();
            CurrMenu(MenuEnum.User, childForm.SiteMapList, childForm);
            RefreshPage();
        }

        private void pnlRemindSet_Click(object sender, EventArgs e)
        {
            var childForm = new RemindSet();
            CurrMenu(MenuEnum.RemindSet, childForm.SiteMapList, childForm);
            RefreshPage();
        }

        public void CurrMenu(MenuEnum menuEnum, List<SiteModel> siteMapList, Form conForm)
        {
            switch (menuEnum)
            {
                case MenuEnum.Home:
                    CurrMenuCtrl(lblHome, picHomeCurr, conForm, siteMapList);
                    break;
                case MenuEnum.SuperTrend:
                    CurrMenuCtrl(lblSuperTrend, picSuperTrend, conForm, siteMapList);
                    break;
                case MenuEnum.Omission:
                    CurrMenuCtrl(lblMovie, picMovieCurr, conForm, siteMapList);
                    break;
                case MenuEnum.NormalTrend:
                    CurrMenuCtrl(lblNormalTrend, picNormalTrendCurr, conForm, siteMapList);
                    break;
                case MenuEnum.Special:
                    CurrMenuCtrl(lblEmail, picEmailCurr, conForm, siteMapList);
                    break;
                case MenuEnum.User:
                    CurrMenuCtrl(lblUser, picUserCurr, conForm, siteMapList);
                    break;
                case MenuEnum.RemindSet:
                    CurrMenuCtrl(lblRemindSet, picRemindSetCurr, conForm, siteMapList);
                    break;
            }
        }

        private void CurrMenuCtrl(Label currLbl, PictureBox currPic, Form childForm, List<SiteModel> siteMapList)
        {
            if (this.MdiChildren.Length > 0 && this.ActiveMdiChild.Name == childForm.Name) return;

            picHomeCurr.Visible = false;
            lblHome.Font = new Font(lblHome.Font, FontStyle.Regular);
            picSuperTrend.Visible = false;
            lblSuperTrend.Font = new Font(lblSuperTrend.Font, FontStyle.Regular);
            picMovieCurr.Visible = false;
            lblMovie.Font = new Font(lblMovie.Font, FontStyle.Regular);
            picEmailCurr.Visible = false;
            lblMovie.Font = new Font(lblMovie.Font, FontStyle.Regular);
            picNormalTrendCurr.Visible = false;
            lblNormalTrend.Font = new Font(lblUser.Font, FontStyle.Regular);
            picUserCurr.Visible = false;
            lblUser.Font = new Font(lblUser.Font, FontStyle.Regular);
            picRemindSetCurr.Visible = false;
            lblRemindSet.Font = new Font(lblRemindSet.Font, FontStyle.Regular);

            currLbl.Font = new Font(lblSuperTrend.Font, FontStyle.Bold);
            currPic.Visible = true;
            pnlSiteMap.Controls.Clear();
            var siteMap = new SiteMapCtrl();
            siteMap.LoadPageConfig(siteMapList);
            pnlSiteMap.Controls.Add(siteMap);

            int i;
            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Name == childForm.Name)
                    break;
            }
            if (i == this.MdiChildren.Length)
            {
                childForm.MdiParent = this;
                childForm.Dock = DockStyle.Fill;
                childForm.Show();
            }
            else
            {
                this.MdiChildren[i].BringToFront();
            }
        }

        # region Title Tab Click Event

        private void lblBJ_Click(object sender, EventArgs e)
        {
            lblBJ.BackColor = Color.White;
            lblCanada.BackColor = Color.DeepSkyBlue;
            Header.RegionSourceSysNo = Convert.ToInt32(lblBJ.Tag);
            RefreshPage();
        }

        private void lblCanada_Click(object sender, EventArgs e)
        {
            lblBJ.BackColor = Color.DeepSkyBlue;
            lblCanada.BackColor = Color.White;
            Header.RegionSourceSysNo = Convert.ToInt32(lblCanada.Tag);
            RefreshPage();
        }

        private void lbl71_Click(object sender, EventArgs e)
        {
            lbl71.BackColor = Color.White;
            lbl53.BackColor = Color.DeepSkyBlue;
            lblZM.BackColor = Color.DeepSkyBlue;
            Header.SiteSourceSysNo = Convert.ToInt32(lbl71.Tag);
            RefreshPage();
        }

        private void lbl53_Click(object sender, EventArgs e)
        {
            lbl71.BackColor = Color.DeepSkyBlue;
            lbl53.BackColor = Color.White;
            lblZM.BackColor = Color.DeepSkyBlue;
            Header.SiteSourceSysNo = Convert.ToInt32(lbl53.Tag);
            RefreshPage();
        }

        private void lblZM_Click(object sender, EventArgs e)
        {
            lbl71.BackColor = Color.DeepSkyBlue;
            lbl53.BackColor = Color.DeepSkyBlue;
            lblZM.BackColor = Color.White;
            Header.SiteSourceSysNo = Convert.ToInt32(lblZM.Tag);
            RefreshPage();
        }

        public void RefreshPage()
        {
            var page = this.ActiveMdiChild as IPage;
            if (page != null)
            {
                page.QueryData(1);
            }
            if (!bgwApp.IsBusy)
            {
                tmApp.Enabled = false;
                bgwApp.RunWorkerAsync();
            }
        }

        # endregion Title Tab Click Event

        private void timerServer_Tick(object sender, EventArgs e)
        {
            timerServer.Enabled = false;
            DateTime dtNow = DateTime.Parse(lblServerTime.Text.Trim()).AddSeconds(1);
            lblServerTime.Text = dtNow.ToString();
            timerServer.Enabled = true;
        }

        private void bgwApp_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = serviceFacade.GetInfoForTimer();
        }

        private void bgwApp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = e.Result as ResultRMOfInfoForTimer;
            if (e.Error != null)
            {
                WriteLog.Write("GetInfoForTimer", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result) && result.Data != null)
            {
                lblCurrent.Text = string.Format("本期分析期号：{0}   第{1}期开奖号码：{2}", result.Data.Lottery.PeriodNum + 1, result.Data.Lottery.PeriodNum, result.Data.Lottery.RetNum);
                if (result.Data.Remind != null && result.Data.Remind.Status == 1)
                {
                    UtilsTool.PlayMusic("Theme/play.wav", true);
                    AppMessage.Alert(string.Format("{0}{1}网站已连续开{2}期{3}", PageUtils.LoadGameName(), PageUtils.LoadSiteName(), result.Data.Remind.SourceSysNo, result.Data.Remind.Cnt, result.Data.Remind.RetNum));
                    UtilsTool.Play.Stop();
                }

                if (string.IsNullOrEmpty(lblServerTime.Text))
                {
                    lblServerTime.Text = result.ServerDate.ToString();
                    timerServer.Enabled = true;
                }
                tmApp.Enabled = true;
            }
        }

        private void tmApp_Tick(object sender, EventArgs e)
        {
            if (!bgwApp.IsBusy)
            {
                tmApp.Enabled = false;
                bgwApp.RunWorkerAsync();
            }
        }

        private void bgwNews_DoWork(object sender, DoWorkEventArgs e)
        {
            var customerFacade = new CustomerFacade();
            e.Result = customerFacade.GetNotice();
        }

        private void bgwNews_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = e.Result as ResultRMOfListOfNotices;
            if (e.Error != null)
            {
                WriteLog.Write("GetInfoForTimer", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result) && result.Data != null)
            {
                if (result.Data != null)
                {
                    newsList = result.Data.ToList<Notices>();
                    tmNews.Enabled = true;
                }
            }
        }

        protected List<Notices> newsList = new List<Notices>();
        protected int showIndex = 0;
        private void tmNews_Tick(object sender, EventArgs e)
        {
            if (newsList.Count == 0)
            {
                tmNews.Enabled = false;
                return;
            }

            tmNews.Enabled = false;
            if (showIndex >= newsList.Count) showIndex = 0;
            if (showIndex < newsList.Count)
            {
                tslNews.Text = newsList[showIndex].Contents;
                showIndex++;
            }
            tmNews.Enabled = true;
        }
    }
}
