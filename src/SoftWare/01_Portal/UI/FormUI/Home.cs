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

namespace Helpmate.UI.Forms.FormUI
{
    public partial class Home : Form
    {
        public CommonFacade serviceFacade = new CommonFacade();
        public List<SiteModel> SiteMapList { get; set; }

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

        private void QueryData()
        {
            cmd.ShowOpaqueLayer(this, 125, true);
            serviceFacade.GetCustomeModule(result =>
            {
                cmd.HideOpaqueLayer();
                if (result.Error != null || !result.Result.Success)
                {
                    string message = result.Error != null ? "无法连接服务器，请稍后重试！" : result.Result.Message;
                    MessageBox.Show(message);
                    return;
                }

                //picNuming.Image = UtilsModel.LoadNumImage(result.Result.Data.M1);

                ucLotteryM1.LoadBindData(result.Result.Data.M1);
                ucLotteryM2.LoadBindData(result.Result.Data.M2);
                ucLotteryM3.LoadBindData(result.Result.Data.M3);
                ucLotteryM4.LoadBindData(result.Result.Data.M4);
            });
        }

        public OpaqueCommand cmd = new OpaqueCommand();
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            QueryData();

        }
    }
}
