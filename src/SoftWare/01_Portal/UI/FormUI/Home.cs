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
            serviceFacade.QuerySuperPerson(result =>
            {
                var c = result.Success;
                var b = result.Message;
                var d = result.Data;
            });
        }
    }
}
