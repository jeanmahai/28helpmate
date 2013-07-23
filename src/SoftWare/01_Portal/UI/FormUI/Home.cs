using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.BizEntity;
using Helpmate.BizEntity.Enum;
using Helpmate.Facades;
using Helpmate.UI.Forms.UserContorl;
using Helpmate.UI.Forms.UIContorl.Common;
using Helpmate.Facades.LotteryWebSvc;
using Helpmate.UI.Forms.Models;
using Common.Utility;
using Helpmate.UI.Forms.Code;
using System.Threading;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class Home : Form, IPage
    {
        public CommonFacade serviceFacade = new CommonFacade();
        public List<SiteModel> SiteMapList { get; set; }
        public OpaqueCommand cmd = new OpaqueCommand();

        public Home()
        {
            GetSiteModelList();
            InitializeComponent();
        }

        public List<SiteModel> GetSiteModelList()
        {
            return SiteMapList = new List<SiteModel>()
            {
                new SiteModel() { Text = UtilsModel.GetTotalNav() },
                new SiteModel(){ Text="本期预测分析"}
            };
        }
        private void Home_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
            QueryData();
        }

        public void QueryData(int? pageIndex = null)
        {
            if (!bgwApp.IsBusy)
            {
                tmRefresh.Enabled = false;
                cmd.ShowOpaqueLayer(this, 125, true);
                bgwApp.RunWorkerAsync();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            QueryData();
        }

        private void tmRefresh_Tick(object sender, EventArgs e)
        {
            QueryData();
        }

        private void bgwApp_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = serviceFacade.GetCustomeModule();
        }

        private void bgwApp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmd.HideOpaqueLayer();
            if (e.Error != null)
            {
                WriteLog.Write("GetCustomeModule", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            var result = e.Result as ResultRMOfCustomModules;
            if (PageUtils.CheckError(result) && result.Data != null)
            {
                DateTime time = DateTime.Parse(result.Data.M3.Forecast);
                string hour = time.Hour < 10 ? string.Format("0{0}", time.Hour) : time.Hour.ToString();
                string minute = time.Minute < 10 ? string.Format("0{0}", time.Minute) : time.Minute.ToString();
                string strTime = string.Format("{0}:{1}", hour, minute);
                label17.Text = string.Format("下图统计当下竞猜期开奖时间（{0}）之前每小时相同分钟数的开奖数据，显示规则同上。", strTime);
                label19.Text = string.Format("下图统计当下竞猜期开奖时间（{0}）之前每一天这个时间的开奖数据，显示规则同上。", strTime);

                ucLotteryM1.LoadBindData(result.Data.M1);
                ucLotteryM2.LoadBindData(result.Data.M2);
                ucLotteryM3.LoadBindData(result.Data.M3);
                ucLotteryM4.LoadBindData(result.Data.M4);

                tmRefresh.Enabled = true;
                tmRefresh.Interval = UtilsTool.GetIntervalSeconds(result.ServerDate, Header.GameSourceSysNo, Header.RegionSourceSysNo, Header.SiteSourceSysNo);
            }
        }
    }
}
