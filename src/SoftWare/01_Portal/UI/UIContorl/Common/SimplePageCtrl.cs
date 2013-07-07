using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.BizEntity;

namespace Helpmate.UI.Forms.UIContorl.Common
{
    public partial class SimplePageCtrl : UserControl
    {
        public PageModel _pageModel;
        public delegate void LoadData(PageModel pageModel);
        public LoadData InvokeLoadData;

        private static SimplePageCtrl _simplePageCtrl;

        public static SimplePageCtrl Initialize()
        {
            if (_simplePageCtrl == null)
            {
                _simplePageCtrl = new SimplePageCtrl();
            }
            return _simplePageCtrl;
        }

        public SimplePageCtrl()
        {
            InitializeComponent();
        }

        public void LoadPageCtr(PageModel page)
        {
            if (page.Count == 0) page.Count = 1;
            _pageModel = page;
            lblPageInfo.Text = string.Format("{0}/{1}", page.Index, page.Count);

            if (page.Count == 1)
            {
                btnPageUp.Enabled = false;
                btnPageDown.Enabled = false;
            }
            else if (page.Index == page.Count)
            {
                btnPageUp.Enabled = false;
                btnPageDown.Enabled = true;
            }
            else if (page.Index == 1)
            {
                btnPageUp.Enabled = true;
                btnPageDown.Enabled = false;
            }
            else
            {
                btnPageDown.Enabled = true;
                btnPageUp.Enabled = true;
            }
        }

        private void btnPageUp_Click(object sender, EventArgs e)
        {
            _pageModel.Index++;
            InvokeLoadData(_pageModel);
        }

        private void btnPageDown_Click(object sender, EventArgs e)
        {
            _pageModel.Index--;
            InvokeLoadData(_pageModel);
        }
    }
}
