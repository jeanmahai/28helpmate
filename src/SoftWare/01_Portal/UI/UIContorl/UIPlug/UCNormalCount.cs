using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.UI.Forms.Properties;

namespace Helpmate.UI.Forms.UIContorl.UIPlug
{
    public partial class UCNormalCount : UserControl
    {
        public UCNormalCount()
        {
            InitializeComponent();
        }

        private void UCNormalCount_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Num");
            dt.Columns.Add("Type1");
            dt.Columns.Add("Type2");
            dt.Columns.Add("Type3");

            for (int i = 0; i < 20; i++)
            {
                dt.Rows.Add(i, "大", "中", "边");
            }

            lblRemark.Text = "大：60%     小：40%     中：60%     边：40%     单：60%     双：40%";


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var item = dt.Rows[i];
                var paddingStyle = new Padding(0, 5, 0, 0);

                PictureBox picNum = new PictureBox();
                picNum.Image = Resources.nobg;
                picNum.Name = item["Num"].ToString();
                picNum.SizeMode = PictureBoxSizeMode.CenterImage;
                picNum.Width = 30;
                picNum.Height = 27;
                picNum.Paint += new PaintEventHandler(picNum_Paint);
                tlpNuming.Controls.Add(picNum, i, 1);

                Label lblTypeOne = new Label();
                lblTypeOne.TextAlign = ContentAlignment.MiddleCenter;
                lblTypeOne.Text = item["Type1"].ToString();
                lblTypeOne.Padding = paddingStyle;
                tlpNuming.Controls.Add(lblTypeOne, i, 2);

                Label lblTypeTwo = new Label();
                lblTypeTwo.TextAlign = ContentAlignment.MiddleCenter;
                lblTypeTwo.Text = item["Type2"].ToString();
                lblTypeTwo.Padding = paddingStyle;
                tlpNuming.Controls.Add(lblTypeTwo, i, 3);

                Label lblTypeThree = new Label();
                lblTypeThree.TextAlign = ContentAlignment.MiddleCenter;
                lblTypeThree.Text = item["Type3"].ToString();
                lblTypeThree.Padding = paddingStyle;
                tlpNuming.Controls.Add(lblTypeThree, i, 4);
            }
        }

        private void picNum_Paint(object sender, PaintEventArgs e)
        {
            if (((PictureBox)sender).BackgroundImage == null)
            {
                string num = ((PictureBox)sender).Name.ToString();
                int numLeft = Convert.ToInt32(num) < 10 ? 8 : 4;
                e.Graphics.DrawString(num, new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.White), numLeft, 5);
            }
        }
    }
}
