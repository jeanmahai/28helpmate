﻿using System;
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
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
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
            var result = e.Result as ResultRMOfCustomModules;

            if (e.Error != null)
            {
                WriteLog.Write("GetCustomeModule", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result) && result.Data != null)
            {
                //lblNuming.Text = result.Data.M1.Forecast;
                //lblMinute.Text = result.Data.M2.Forecast;
                //lblTime.Text = result.Data.M3.Forecast;
                DateTime time = DateTime.Parse(result.Data.M3.Forecast);
                string hour = time.Hour < 10 ? string.Format("0{0}", time.Hour) : time.Hour.ToString();
                string minute = time.Minute < 10 ? string.Format("0{0}", time.Minute) : time.Minute.ToString();
                string strTime = string.Format("{0}:{1}", hour, minute);
                label17.Text = string.Format("提示：此图是统计当前竞猜期的开奖时间（{0}）之前每小时这个时间所开之号，显示20期。", strTime);
                label19.Text = string.Format("提示：此图是统计当前竞猜期的开奖时间（{0}）之前每天这个时间所开之号，显示20期。", strTime);

                ucLotteryM1.LoadBindData(result.Data.M1);
                ucLotteryM2.LoadBindData(result.Data.M2);
                ucLotteryM3.LoadBindData(result.Data.M3);
                ucLotteryM4.LoadBindData(result.Data.M4);

                tmRefresh.Enabled = true;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
