using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.BizEntity;
using Helpmate.Facades.LotteryWebSvc;
using Helpmate.UI.Forms.Models;
using Helpmate.UI.Forms.UIContorl.Common;
using Helpmate.Facades;
using Common.Utility;
using Helpmate.BizEntity.Enum;
using Helpmate.UI.Forms.Code;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class Omission : Form, IPage
    {
        public CommonFacade serviceFacade = new CommonFacade();
        public OpaqueCommand cmd = new OpaqueCommand();
        public List<SiteModel> SiteMapList { get; set; }

        public Omission()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel() { Text = UtilsModel.GetTotalNav() },
                new SiteModel(){ Text="遗漏号码统计"}
            };
            InitializeComponent();
        }

        public List<SiteModel> GetSiteModelList()
        {
            return SiteMapList = new List<SiteModel>()
            {
                new SiteModel() { Text = UtilsModel.GetTotalNav() },
                new SiteModel(){ Text="遗漏号码统计"}
            };
        }
        private void Omission_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();

            lblRemark.Text = "各位会员：本统计表内若期数用“红色”显示代表这个号码当前所遗漏的期数已超过他的标准遗漏几率，若用“紫色”显示则表示\r\n\r\n此号码当前遗漏的期数已超过最高遗漏期数。";
            QueryData();
        }

        public void QueryData(int? pageIndex = null)
        {
            if (!bgwApp.IsBusy)
            {
                cmd.ShowOpaqueLayer(this, 125, true);
                bgwApp.RunWorkerAsync();
            }
        }

        private void bgwApp_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = serviceFacade.QueryOmission();
        }

        private void bgwApp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmd.HideOpaqueLayer();
            var result = e.Result as ResultRMOfListOfOmitStatistics;

            if (e.Error != null)
            {
                WriteLog.Write("QueryOmission", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result) && result.Data != null)
            {
                foreach (OmitStatistics item in result.Data)
                {
                    var lblNow = tlpNuming.Controls.Find("lblNow" + item.RetNum, true).First() as Label;
                    lblNow.Text = item.OmitCnt.ToString();

                    var lblMax = tlpNuming.Controls.Find("lblLen" + item.RetNum, true).First() as Label;
                    lblMax.Text = item.MaxOmitCnt.ToString();

                    var lblStandard = tlpNuming.Controls.Find("lblBZ" + item.RetNum, true).First() as Label;
                    lblStandard.Text = item.StandardCnt.ToString();

                    if (item.OmitCnt > item.StandardCnt)
                    {
                        lblNow.ForeColor = Color.Red;
                    }
                    else if (item.OmitCnt > item.MaxOmitCnt)
                    {
                        lblNow.ForeColor = Color.Purple;
                    }
                    else
                    {
                        lblNow.ForeColor = Color.Black;
                    }
                }
            }
        }
    }
}
