using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.UI.Forms.UIContorl.UIPage;
using Helpmate.BizEntity;
using Helpmate.BizEntity.Enum;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class Home : Form
    {
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
           
        }

       
    }
}
