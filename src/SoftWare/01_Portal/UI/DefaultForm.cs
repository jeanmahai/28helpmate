using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.UI.Forms.UserContorl;
using System.Diagnostics;
using System.Threading;
using Helpmate.UI.Forms.UIContorl.Common;
using Helpmate.BizEntity.Enum;
using Helpmate.UI.Forms.UserContorl.Common;
using Common.Utility;
using Helpmate.UI.Forms.UIContorl.UIPage;
using Helpmate.BizEntity;
using Helpmate.UI.Forms.FormUI;

namespace Helpmate.UI.Forms
{
    public partial class DefaultForm : Form
    {
        private static DefaultForm DefaultFrm;
        private static Control CurrPage;
        private static int CurrPageWidth;

        public static DefaultForm Initialize()
        {
            if (DefaultFrm == null)
            {
                DefaultFrm = new DefaultForm();
            }
            return DefaultFrm;
        }

        private DefaultForm()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);//解决闪烁
            this.SetStyle(ControlStyles.Opaque, true);//解决背景重绘问题(设置不绘制窗口背景，因为重绘窗口背景会导致性能底下)
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//解决闪烁 

            InitializeComponent();
        }

        private void DefaultForm_Load(object sender, EventArgs e)
        {
            //lblTime.Text = string.Format("{0:D}", DateTime.Now);
            //var conCtrl = IndexCtrl.Initialize();

            //var childForm = new Index();
            //childForm.MdiParent = this;
            //childForm.Show();

            //CurrMenu(MenuEnum.Home, conCtrl.SiteMapList, conCtrl);
        }

        private void pnlHome_Click(object sender, EventArgs e)
        {
            //var conCtrl = IndexCtrl.Initialize();
            //CurrMenu(MenuEnum.Home, conCtrl.SiteMapList, conCtrl);
        }

        private void pnlPrediction_Click(object sender, EventArgs e)
        {
            //var conCtrl = PredictionCtrl.Initialize();
            //CurrMenu(MenuEnum.Prediction, conCtrl.SiteMapList, conCtrl);
        }

        private void pnlOmission_Click(object sender, EventArgs e)
        {
            var conCtrl = OmissionCtrl.Initialize();
            CurrMenu(MenuEnum.Email, conCtrl.SiteMapList, conCtrl);
        }

        private void pnlNormalChart_Click(object sender, EventArgs e)
        {
            var conCtrl = NormalChart.Initialize();
            CurrMenu(MenuEnum.Movie, conCtrl.SiteMapList, conCtrl);
        }

        private void pnlOther_Click(object sender, EventArgs e)
        {
            // CurrMenu(MenuEnum.Tools, "Page_MtvVideo", MtvSharpCtrl.Initialize());
        }

        private void pnlLog_Click(object sender, EventArgs e)
        {
            //  CurrMenu(MenuEnum.Log, "Page_MtvVideo", AppLogCtrl.Initialize());
        }

        public void CurrMenu(MenuEnum menuEnum, List<SiteModel> siteMapList, UserControl conCtrl)
        {
            switch (menuEnum)
            {
                case MenuEnum.Home:
                    CurrMenuCtrl(lblHome, picHomeCurr, conCtrl, siteMapList);
                    break;
                case MenuEnum.Prediction:
                    CurrMenuCtrl(lblMtv, picMtvCurr, conCtrl, siteMapList);
                    break;
                case MenuEnum.Movie:
                    CurrMenuCtrl(lblMovie, picMovieCurr, conCtrl, siteMapList);
                    break;
                case MenuEnum.Email:
                    CurrMenuCtrl(lblEmail, picEmailCurr, conCtrl, siteMapList);
                    break;
                case MenuEnum.Tools:
                    CurrMenuCtrl(lblOther, picOtherCurr, conCtrl, siteMapList);
                    break;
                case MenuEnum.Log:
                    CurrMenuCtrl(lblLog, picLogCurr, conCtrl, siteMapList);
                    break;
            }
        }

        private void CurrMenuCtrl(Label currLbl, PictureBox currPic, UserControl conCtrl, List<SiteModel> siteMapList)
        {
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

            pnlCon.Controls.Clear();
            pnlCon.Controls.Add(conCtrl);
            currLbl.Font = new Font(lblMtv.Font, FontStyle.Bold);
            currPic.Visible = true;
            pnlSiteMap.Controls.Clear();
            var siteMap = new SiteMapCtrl();
            siteMap.LoadPageConfig(siteMapList);
            pnlSiteMap.Controls.Add(siteMap);

            if (CurrPage != null)
            {
                CurrPage.Width = CurrPageWidth;//还原Control宽度
            }
            CurrPage = conCtrl;
            CurrPageWidth = conCtrl.Width;
            ChangeControlSize();//调整Control宽度
        }

        private void DefaultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsExiteApplication)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private bool IsExiteApplication = false;
        private void tsmExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == UtilsTool.ShowMsg("确定要退出系统吗?"))
            {
                this.Close();
                IsExiteApplication = true;
                Application.Exit();
            }
        }

        private void tsmHome_Click(object sender, EventArgs e)
        {
            //CurrMenu(MenuEnum.Home, "Page_AppIndex", MainDefaultCtrl.Initialize());
            ShowWindForm();
        }

        private void ntiDefault_DoubleClick(object sender, EventArgs e)
        {
            ShowWindForm();
        }

        private void ShowWindForm()
        {
            if (this.Visible)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Visible = true;
            }
        }

        private void tsmMtv_Click(object sender, EventArgs e)
        {
            //CurrMenu(MenuEnum.Mtv, "Page_MtvVideo", MtvSharpCtrl.Initialize());
            ShowWindForm();
        }

        private void ntiDefault_MouseClick(object sender, MouseEventArgs e)
        {
            ShowWindForm();
        }

        private void DefaultForm_SizeChanged(object sender, EventArgs e)
        {
            ChangeControlSize();
        }

        private void ChangeControlSize()
        {
            if (this.WindowState == FormWindowState.Maximized && CurrPage != null)
            {
                if (CurrPageWidth < (pnlCon.Width - 20))
                {
                    CurrPage.Width = (pnlCon.Width - 20);
                }
            }
            if (this.WindowState == FormWindowState.Normal && CurrPage != null)
            {
                if (CurrPageWidth < (pnlCon.Width - 20))
                {
                    CurrPage.Width = CurrPageWidth;
                }
            }
        }
    }
}
