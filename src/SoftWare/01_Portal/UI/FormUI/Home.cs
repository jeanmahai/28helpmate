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
        BaseFacade bf = new BaseFacade();
        public CommonFacade serviceFacade = new CommonFacade();
        public List<SiteModel> SiteMapList { get; set; }
        public OpaqueCommand cmd = new OpaqueCommand();

        public Home()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel(){ Text="本期统计"}
            };
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
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

        private ResultRMOfCustomModules GetCustomeModule()
        {
            return serviceFacade.GetCustomeModule();
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
            var result = e.Result as ResultRMOfCustomModules;

            if (e.Error != null)
            {
                WriteLog.Write("GetCustomeModule", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result) && result.Data != null)
            {
                AppMessage.AlertErrMessage(result.Message);
                //picNuming.Image = UtilsModel.LoadNumImage(result.Result.Data.M1);
                ucLotteryM1.LoadBindData(result.Data.M1);
                ucLotteryM2.LoadBindData(result.Data.M2);
                ucLotteryM3.LoadBindData(result.Data.M3);
                ucLotteryM4.LoadBindData(result.Data.M4);

                cmd.HideOpaqueLayer();
                tmRefresh.Enabled = true;
            }
        }
    }
}
