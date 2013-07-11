using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.UI.Forms.Properties;
using Helpmate.Facades.LotteryWebSvc;
using Helpmate.UI.Forms.Code;

namespace Helpmate.UI.Forms.UIContorl.UIPlug
{
    public partial class UCNormalCount : UserControl
    {
        public UCNormalCount()
        {
            InitializeComponent();
        }

        public void LoadBindData(LotteryByTwentyPeriod lottery)
        {
            if (lottery != null)
            {
                lblRemark.Text = string.Format("大：{0}　小：{1}　中：{2}　边：{3}　单：{4}　双：{5}", lottery.BigP.ToString("P"), lottery.SmallP.ToString("P"), lottery.CenterP.ToString("P"), lottery.OddP.ToString("P"), lottery.OddP.ToString("P"), lottery.SideP.ToString("P"));
                lblNoNum.Text = string.Format("未出现的号码：{0}", string.Join(",", lottery.NotAppearNumber));


                for (int i = 0; i < lottery.Lotteries.Length; i++)
                {
                    var item = lottery.Lotteries[i];
                    PictureBox pic = tlpNuming.Controls.Find("picNum_" + i, true).First() as PictureBox;
                    pic.Image = UtilsModel.LoadNumImage(item.RetNum);

                    var lblType1 = tlpNuming.Controls.Find("lblType1_" + i, true).First() as Label;
                    lblType1.Text = item.type.BigOrSmall;

                    var lblType2 = tlpNuming.Controls.Find("lblType2_" + i, true).First() as Label;
                    lblType2.Text = item.type.MiddleOrSide;

                    var lblType3 = tlpNuming.Controls.Find("lblType3_" + i, true).First() as Label;
                    lblType3.Text = item.type.MantissaBigOrSmall;


                    //var item = lottery.Lotteries[i];
                    //var paddingStyle = new Padding(0, 5, 0, 0);

                    //PictureBox picNum = new PictureBox();
                    //picNum.Image = Resources.nobg;
                    //picNum.Name = item.RetNum.ToString();//数字
                    //picNum.SizeMode = PictureBoxSizeMode.CenterImage;
                    //picNum.Width = 30;
                    //picNum.Height = 27;
                    //picNum.Paint += new PaintEventHandler(picNum_Paint);
                    //tlpNuming.Controls.Add(picNum, i, 1);

                    //Label lblTypeOne = new Label();
                    //lblTypeOne.TextAlign = ContentAlignment.MiddleCenter;
                    //lblTypeOne.Text = item.type.BigOrSmall;//类型一
                    //lblTypeOne.Padding = paddingStyle;
                    //tlpNuming.Controls.Add(lblTypeOne, i, 2);

                    //Label lblTypeTwo = new Label();
                    //lblTypeTwo.TextAlign = ContentAlignment.MiddleCenter;
                    //lblTypeTwo.Text = item.type.MiddleOrSide;//类型二
                    //lblTypeTwo.Padding = paddingStyle;
                    //tlpNuming.Controls.Add(lblTypeTwo, i, 3);

                    //Label lblTypeThree = new Label();
                    //lblTypeThree.TextAlign = ContentAlignment.MiddleCenter;
                    //lblTypeThree.Text = item.type.MantissaBigOrSmall;//类型三
                    //lblTypeThree.Padding = paddingStyle;
                    //tlpNuming.Controls.Add(lblTypeThree, i, 4);
                }
            }
        }



        private void UCNormalCount_Load(object sender, EventArgs e)
        {

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
