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
            var childForm = new Home();
            CurrMenu(MenuEnum.Home, childForm.SiteMapList, childForm);
        }

        private void pnlHome_Click(object sender, EventArgs e)
        {
            var childForm = new Home();
            CurrMenu(MenuEnum.Home, childForm.SiteMapList, childForm);
        }

        private void pnlPrediction_Click(object sender, EventArgs e)
        {
            var childForm = new Prediction();
            CurrMenu(MenuEnum.Prediction, childForm.SiteMapList, childForm);
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
                case MenuEnum.Prediction:
                    CurrMenuCtrl(lblMtv, picMtvCurr, conForm, siteMapList);
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
                    CurrMenuCtrl(lblLog, picLogCurr, conForm, siteMapList);
                    break;
            }
        }

        private void CurrMenuCtrl(Label currLbl, PictureBox currPic, Form childForm, List<SiteModel> siteMapList)
        {
            if (this.MdiChildren.Length > 0 && this.ActiveMdiChild.Name == childForm.Name) return;

            picHomeCurr.Visible = false;
            lblHome.Font = new Font(lblHome.Font, FontStyle.Regular);
            picMtvCurr.Visible = false;
            lblMtv.Font = new Font(lblMtv.Font, FontStyle.Regular);
            picMovieCurr.Visible = false;
            lblMovie.Font = new Font(lblMovie.Font, FontStyle.Regular);
            picEmailCurr.Visible = false;
            lblMovie.Font = new Font(lblMovie.Font, FontStyle.Regular);
            picOtherCurr.Visible = false;
            lblOther.Font = new Font(lblOther.Font, FontStyle.Regular);
            picLogCurr.Visible = false;
            lblLog.Font = new Font(lblLog.Font, FontStyle.Regular);

            currLbl.Font = new Font(lblMtv.Font, FontStyle.Bold);
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

        

    }
}
