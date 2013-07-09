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
using Helpmate.Facades.LotteryWebService;
using Helpmate.UI.Forms.Models;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class Home : Form, IPage
    {
        public delegate ResultRMOfCustomModules QueryDataDelegate();
        public delegate void BindDataCallback(ResultRMOfCustomModules result);

        public CommonFacade serviceFacade = new CommonFacade();
        public List<SiteModel> SiteMapList { get; set; }
        public OpaqueCommand cmd = new OpaqueCommand();

        public Home()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel(){ Text="本期统计"}
            };

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            QueryData();
        }

        public void QueryData(int? pageIndex = null)
        {
            tmRefresh.Enabled = false;
            cmd.ShowOpaqueLayer(this, 125, true);
            QueryDataDelegate dele = new QueryDataDelegate(GetCustomeModule);
            AsyncCallback callBack = new AsyncCallback(CallBackMethod);
            IAsyncResult iar = dele.BeginInvoke(callBack, dele);
        }

        public void CallBackMethod(IAsyncResult ar)
        {
            QueryDataDelegate dn = (QueryDataDelegate)ar.AsyncState;
            var result = dn.EndInvoke(ar);

            if (this.InvokeRequired)
            {
                BindDataCallback bind = new BindDataCallback(BindDataAsync);
                this.Invoke(bind, result);
            }
            else
            {
                BindDataAsync(result);
            }
        }

        private void BindDataAsync(ResultRMOfCustomModules result)
        {
            if (result != null && result.Data != null)
            {
                //picNuming.Image = UtilsModel.LoadNumImage(result.Result.Data.M1);

                ucLotteryM1.LoadBindData(result.Data.M1);
                ucLotteryM2.LoadBindData(result.Data.M2);
                ucLotteryM3.LoadBindData(result.Data.M3);
                ucLotteryM4.LoadBindData(result.Data.M4);
            }
            cmd.HideOpaqueLayer();
            tmRefresh.Enabled = true;
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
    }
}
