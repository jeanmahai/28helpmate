using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.Facades;
using Helpmate.BizEntity;
using Helpmate.UI.Forms.UIContorl.Common;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class RemindSet : Form
    {
        BaseFacade bf = new BaseFacade();
        public CustomerFacade serviceFacade = new CustomerFacade();
        public List<SiteModel> SiteMapList { get; set; }
        public OpaqueCommand cmd = new OpaqueCommand();

        public RemindSet()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel(){ Text="提醒设置"}
            };
            InitializeComponent();
        }

        private void RemindSet_Load(object sender, EventArgs e)
        {
            //QueryData();
        }
    }
}
