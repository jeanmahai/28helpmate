using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Helpmate.BizEntity;
using Helpmate.BizEntity.Enum;

namespace Helpmate.UI.Forms.UserContorl.Common
{
    public partial class SiteMapCtrl : UserControl
    {
        private int TextLeft = 10;
        private int TextTop = 5;

        private int SplitLeft = 100;
        private int SplitTop = 5;

        public SiteMapCtrl()
        {
            InitializeComponent();
        }

        public void LoadPageConfig(List<SiteModel> siteList)
        {
            for (int i = 0; i < siteList.Count; i++)
            {
                var item = siteList[i];
                Label lblText = new Label();
                lblText.Text = item.Text;
                lblText.Left = TextLeft;
                lblText.Top = TextTop;
                lblText.Width = 90;
                lblText.TextAlign = ContentAlignment.MiddleLeft;
                this.Controls.Add(lblText);


                if (i < siteList.Count - 1)
                {
                    Label lblSplit = new Label();
                    lblSplit.Text = ">";
                    lblSplit.Left = SplitLeft;
                    lblSplit.Top = SplitTop;
                    lblSplit.Width = 20;
                    lblSplit.TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblSplit);
                }

                TextLeft += (SplitLeft + 20);
                SplitLeft += 100;
            }
        }
    }
}
