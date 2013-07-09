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

namespace Helpmate.UI.Forms
{
    public partial class Default : Form
    {
        public Default()
        {
            InitializeComponent();
        }

        private void Default_Load(object sender, EventArgs e)
        {
            Header.SiteSourceSysNo = Convert.ToInt32(lblBJ.Tag);
            Header.GameSourceSysNo = Convert.ToInt32(lbl71.Tag);

            var childForm = new Home();
            CurrMenu(MenuEnum.Home, childForm.SiteMapList, childForm);
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
        }

        private void pnlNormalTrend_Click(object sender, EventArgs e)
        {
            var childForm = new NormalTrend();
            CurrMenu(MenuEnum.NormalTrend, childForm.SiteMapList, childForm);
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
                case MenuEnum.Tools:
                    CurrMenuCtrl(lblOther, picOtherCurr, conForm, siteMapList);
                    break;
                case MenuEnum.Log:
                    CurrMenuCtrl(lblUser, picLogCurr, conForm, siteMapList);
                    break;
                case MenuEnum.User:
                    CurrMenuCtrl(lblUser, picLogCurr, conForm, siteMapList);
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
            picOtherCurr.Visible = false;
            lblOther.Font = new Font(lblOther.Font, FontStyle.Regular);
            picLogCurr.Visible = false;
            lblUser.Font = new Font(lblUser.Font, FontStyle.Regular);
            picNormalTrendCurr.Visible = false;
            lblNormalTrend.Font = new Font(lblUser.Font, FontStyle.Regular);

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
            lblCanada.BackColor = Color.LightGray;
            Header.SiteSourceSysNo = Convert.ToInt32(lblBJ.Tag);
            RefreshPage();
        }

        private void lblCanada_Click(object sender, EventArgs e)
        {
            lblBJ.BackColor = Color.LightGray;
            lblCanada.BackColor = Color.White;
            Header.SiteSourceSysNo = Convert.ToInt32(lblCanada.Tag);
            RefreshPage();
        }

        private void lbl71_Click(object sender, EventArgs e)
        {
            lbl71.BackColor = Color.White;
            lbl53.BackColor = Color.LightGray;
            lblZM.BackColor = Color.LightGray;
            Header.GameSourceSysNo = Convert.ToInt32(lbl71.Tag);
            RefreshPage();
        }

        private void lbl53_Click(object sender, EventArgs e)
        {
            lbl71.BackColor = Color.LightGray;
            lbl53.BackColor = Color.White;
            lblZM.BackColor = Color.LightGray;
            Header.GameSourceSysNo = Convert.ToInt32(lbl53.Tag);
            RefreshPage();
        }

        private void lblZM_Click(object sender, EventArgs e)
        {
            lbl71.BackColor = Color.LightGray;
            lbl53.BackColor = Color.LightGray;
            lblZM.BackColor = Color.White;
            Header.GameSourceSysNo = Convert.ToInt32(lblZM.Tag);
            RefreshPage();
        }

        public void RefreshPage()
        {
            var page = this.ActiveMdiChild as IPage;
            if (page != null)
            {
                page.QueryData(1);
            }
        }

        # endregion Title Tab Click Event
    }
}
