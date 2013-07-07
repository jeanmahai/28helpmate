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
    public partial class Omission : Form
    {
        public List<SiteModel> SiteMapList { get; set; }
        public Omission()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel(){ Text="本期统计"},
                new SiteModel(){ Text="遗漏分析"}
            };
            InitializeComponent();
        }
    }
}
