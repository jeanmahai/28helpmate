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
    public partial class OmissionCtrl : UserControl
    {
        public List<SiteModel> SiteMapList { get; set; }
        private static OmissionCtrl _conCtrl;
        public static OmissionCtrl Initialize()
        {
            if (_conCtrl == null)
            {
                _conCtrl = new OmissionCtrl();
            }
            return _conCtrl;
        }
        public OmissionCtrl()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel(){ Text="本期统计"},
                new SiteModel(){ Text="遗漏分析"}
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
    }
}
