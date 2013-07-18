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
using Common.Utility;
using Helpmate.UI.Forms.Models;

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

                BindGridHead(lottery);
                BindGridFoot(lottery);

                List<NormalCountNumModel> numList = new List<NormalCountNumModel>();
                List<NormalCountTypeModel> typeList = new List<NormalCountTypeModel>();

                var numObj = new NormalCountNumModel();
                Type num = numObj.GetType();

                var typeOneObj = new NormalCountTypeModel();
                Type typeOne = typeOneObj.GetType();

                var typeTwoObj = new NormalCountTypeModel();
                Type typeTwo = typeTwoObj.GetType();

                var typeThreeObj = new NormalCountTypeModel();
                Type typeThree = typeThreeObj.GetType();

                for (int i = 0; i < lottery.Lotteries.Length; i++)
                {
                    var item = lottery.Lotteries[i];
                    num.GetProperty("T" + i).SetValue(numObj, UtilsModel.LoadNumImage(item.RetNum), null);
                    typeOne.GetProperty("T" + i).SetValue(typeOneObj, item.type.BigOrSmall, null);
                    typeTwo.GetProperty("T" + i).SetValue(typeTwoObj, item.type.MiddleOrSide, null);
                    typeThree.GetProperty("T" + i).SetValue(typeThreeObj, item.type.MantissaBigOrSmall, null);
                }

                numList.Add(numObj);
                dgvDataNum.DataSource = numList;
                BindGridData(dgvDataNum);


                typeList.Add(typeOneObj);
                typeList.Add(typeTwoObj);
                typeList.Add(typeThreeObj);
                dgvDataType.DataSource = typeList;
                BindGridData(dgvDataType);
            }
        }

        public void BindGridHead(LotteryByTwentyPeriod lottery)
        {
            var listTemp = new List<RmarkFootModel>();
            listTemp.Add(new RmarkFootModel(string.Format("大：{0}　小：{1}　中：{2}　边：{3}　单：{4}　双：{5}", lottery.BigP.ToString("P"), lottery.SmallP.ToString("P"), lottery.CenterP.ToString("P"), lottery.SideP.ToString("P"), lottery.OddP.ToString("P"), lottery.EvenP.ToString("P"))));
            dgvHead.DataSource = listTemp;
            dgvHead.Rows[0].Height = 29;
            dgvHead.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHead.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHead.Columns[0].DefaultCellStyle.BackColor = Color.White;
            dgvHead.Columns[0].DefaultCellStyle.SelectionBackColor = Color.White;
            dgvHead.Columns[0].DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        public void BindGridFoot(LotteryByTwentyPeriod lottery)
        {
            var listTemp = new List<RmarkFootModel>();
            listTemp.Add(new RmarkFootModel(string.Format("未出现的号码：{0}", string.Join(",", lottery.NotAppearNumber))));
            dgvFoot.DataSource = listTemp;
            dgvFoot.Rows[0].Height = 29;
            dgvFoot.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFoot.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFoot.Columns[0].DefaultCellStyle.BackColor = Color.White;
            dgvFoot.Columns[0].DefaultCellStyle.SelectionBackColor = Color.White;
            dgvFoot.Columns[0].DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        public void BindGridData(object obj)
        {
            DataGridView dgv = obj as DataGridView;

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 33;
                if (i == dgv.Columns.Count - 1) dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns[i].DefaultCellStyle.BackColor = Color.White;
                dgv.Columns[i].DefaultCellStyle.SelectionBackColor = Color.White;
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Height = 30;
            }
        }

        private void dgvDataType_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView)) return;

            if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                DataGridView dgvList = sender as DataGridView;
                switch (e.Value.ToString())
                {
                    case "单":
                        e.CellStyle.ForeColor = UtilsTool.ToColor("#03C");
                        e.CellStyle.SelectionForeColor = UtilsTool.ToColor("#03C");
                        break;
                    case "双":
                        e.CellStyle.ForeColor = UtilsTool.ToColor("#F33");
                        e.CellStyle.SelectionForeColor = UtilsTool.ToColor("#F33");
                        break;
                    case "中":
                        e.CellStyle.ForeColor = UtilsTool.ToColor("#609");
                        e.CellStyle.SelectionForeColor = UtilsTool.ToColor("#609");
                        break;
                    case "边":
                        e.CellStyle.ForeColor = UtilsTool.ToColor("#F90");
                        e.CellStyle.SelectionForeColor = UtilsTool.ToColor("#F90");
                        break;
                    case "大":
                        e.CellStyle.ForeColor = UtilsTool.ToColor("#F09");
                        e.CellStyle.SelectionForeColor = UtilsTool.ToColor("#F09");
                        break;
                    case "小":
                        e.CellStyle.ForeColor = UtilsTool.ToColor("#0C0");
                        e.CellStyle.SelectionForeColor = UtilsTool.ToColor("#0C0");
                        break;
                }
            }
        }
    }
}
