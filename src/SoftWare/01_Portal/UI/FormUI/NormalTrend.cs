using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.BizEntity;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class NormalTrend : Form
    {
        public List<SiteModel> SiteMapList { get; set; }

        public NormalTrend()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel(){ Text="本期预测分析"},
                new SiteModel(){ Text="近期开奖走势"}
            };
            InitializeComponent();
        }
    }
}
