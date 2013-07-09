using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class DateSlt : Form
    {
        public string tDateTime
        {
            get;
            set;
        }
        public DateSlt()
        {
            InitializeComponent();
        }
        public string GetNewWindowDateTime()
        {
            switch (ShowDialog())
            {
                case DialogResult.OK:
                    return this.tDateTime;
                default:
                    break;
            }
            return null;
        }
        private void dateControl_DateSelected(object sender, DateRangeEventArgs e)
        {
            string tDate = this.dateControl.SelectionStart.ToString("yyyy-MM-dd");
            this.tDateTime = tDate.Replace("-", "/");
            this.DialogResult = DialogResult.OK;
        }
    }
}
