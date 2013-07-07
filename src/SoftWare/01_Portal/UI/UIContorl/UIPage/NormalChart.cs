using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.BizEntity;

namespace Helpmate.UI.Forms.UIContorl.UIPage
{
    public partial class NormalChart : UserControl
    {
        public List<SiteModel> SiteMapList { get; set; }
        private static NormalChart _conCtrl;
        public static NormalChart Initialize()
        {
            if (_conCtrl == null)
            {
                _conCtrl = new NormalChart();
            }
            return _conCtrl;
        }

        public NormalChart()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel(){ Text="本期统计"},
                new SiteModel(){ Text="一般走势"}
            };
            InitializeComponent();
        }

        private void picNum_Paint(object sender, PaintEventArgs e)
        {
            if (((PictureBox)sender).BackgroundImage == null)
            {
                string num = ((PictureBox)sender).Tag.ToString();
                int numLeft = Convert.ToInt32(num) < 10 ? 49 : 45;
                e.Graphics.DrawString(num, new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.White), numLeft, 5);
            }
        }

        private void NormalChart_Load(object sender, EventArgs e)
        {
            
        }
    }
}
