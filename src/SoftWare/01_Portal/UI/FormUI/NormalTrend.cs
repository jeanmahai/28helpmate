using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.BizEntity;
using Common.Utility;
using System.IO;

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

            //统计
            List<TrendCountModel> countData = GetCountList();
            countList.DataSource = countData;
            SetCountStyle(countList, countData.Count);
            //头
            List<TrendHeaderModel> headerData = GetHeaderList();
            headerList.DataSource = headerData;
            SetHeaderStyle(headerList, headerData.Count);
            //数据
            List<TrendDataModel> listData = GetDataList();
            dataList.DataSource = listData;
            SetDataStyle(dataList, listData.Count);
            //22
            if (listData.Count < 22)
            {
 
            }
        }
        private void SetCountStyle(object obj, int rows)
        {
            DataGridView dgv = obj as DataGridView;
            //设置为不可编辑
            dgv.ReadOnly = true;
            //设置选中不显示背景色
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = UtilsTool.ToColor("#fffde3");
            dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            //设置单元格宽高
            dgv.Columns[0].Width = 140;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].DefaultCellStyle.BackColor = UtilsTool.ToColor("#fffde3");
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 25;
                dgv.Columns[i].DefaultCellStyle.BackColor = UtilsTool.ToColor("#fffde3");
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            //不显示列头
            dgv.ColumnHeadersVisible = false;
            //不显示行头
            dgv.RowHeadersVisible = false;
            //不允许用户设置行列大小
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            //不显示边框
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
        }
        private void SetHeaderStyle(object obj, int rows)
        {
            DataGridView dgv = obj as DataGridView;
            //设置为不可编辑
            dgv.ReadOnly = true;
            //设置选中不显示背景色
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = UtilsTool.ToColor("#c6e2ff");
            dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            //设置单元格宽高
            dgv.Columns[0].Width = 60;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].DefaultCellStyle.BackColor = UtilsTool.ToColor("#c6e2ff");
            dgv.Columns[1].Width = 80;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].DefaultCellStyle.BackColor = UtilsTool.ToColor("#c6e2ff");
            for (int i = 2; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 25;
                dgv.Columns[i].DefaultCellStyle.BackColor = UtilsTool.ToColor("#c6e2ff");
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            //不显示列头
            dgv.ColumnHeadersVisible = false;
            //不显示行头
            dgv.RowHeadersVisible = false;
            //不允许用户设置行列大小
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            //不显示边框
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
        }
        private void SetDataStyle(object obj, int rows)
        {
            DataGridView dgv = obj as DataGridView;
            //设置为不可编辑
            dgv.ReadOnly = true;
            //设置单元格宽高
            dgv.Columns[0].Width = 60;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].DefaultCellStyle.BackColor = UtilsTool.ToColor("#F4F4F4");
            dgv.Columns[0].DefaultCellStyle.ForeColor = UtilsTool.ToColor("#36c");
            dgv.Columns[0].DefaultCellStyle.SelectionBackColor = UtilsTool.ToColor("#F4F4F4");
            dgv.Columns[0].DefaultCellStyle.SelectionForeColor = UtilsTool.ToColor("#36c");
            dgv.Columns[1].Width = 80;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].DefaultCellStyle.BackColor = Color.White;
            dgv.Columns[1].DefaultCellStyle.SelectionBackColor = Color.White;
            dgv.Columns[1].DefaultCellStyle.SelectionForeColor = Color.Black;
            for (int i = 2; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 25;
                if ((i >= 2 && i <= 11) || (i >= 20 && i <= 29))
                {
                    dgv.Columns[i].DefaultCellStyle.BackColor = UtilsTool.ToColor("#C1FFC1");
                    dgv.Columns[i].DefaultCellStyle.SelectionBackColor = UtilsTool.ToColor("#C1FFC1");
                    dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    dgv.Columns[i].DefaultCellStyle.BackColor = Color.White;
                    dgv.Columns[i].DefaultCellStyle.SelectionBackColor = Color.White;
                    dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            //不显示列头
            dgv.ColumnHeadersVisible = false;
            //不显示行头
            dgv.RowHeadersVisible = false;
            //不允许用户设置行列大小
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            //不显示边框
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
        }
        private List<TrendCountModel> GetCountList()
        {
            List<TrendCountModel> headerList = new List<TrendCountModel>();
            TrendCountModel count = new TrendCountModel();
            headerList.Add(count);
            return headerList;
        }
        private List<TrendHeaderModel> GetHeaderList()
        {
            List<TrendHeaderModel> headerList = new List<TrendHeaderModel>();
            TrendHeaderModel header = new TrendHeaderModel();
            headerList.Add(header);
            return headerList;
        }
        private List<TrendDataModel> GetDataList()
        {
            List<TrendDataModel> dataList = new List<TrendDataModel>();
            TrendDataModel data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T20 = File.ReadAllBytes("Resources/data/number_20x.gif");
            data.Big = "大";
            data.Small = "";
            data.Middle = "中";
            data.Side = "";
            data.Odd = "单";
            data.Dual = "";
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T10 = File.ReadAllBytes("Resources/data/number_10x.gif");
            data.Big = "";
            data.Small = "小";
            data.Middle = "";
            data.Side = "边";
            data.Odd = "";
            data.Dual = "双";
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T12 = File.ReadAllBytes("Resources/data/number_12x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T15 = File.ReadAllBytes("Resources/data/number_15x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T19 = File.ReadAllBytes("Resources/data/number_19x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T27 = File.ReadAllBytes("Resources/data/number_27x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T26 = File.ReadAllBytes("Resources/data/number_26x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T11 = File.ReadAllBytes("Resources/data/number_11x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T0 = File.ReadAllBytes("Resources/data/number_0x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T2 = File.ReadAllBytes("Resources/data/number_2x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T5 = File.ReadAllBytes("Resources/data/number_5x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T8 = File.ReadAllBytes("Resources/data/number_8x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T1 = File.ReadAllBytes("Resources/data/number_1x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T6 = File.ReadAllBytes("Resources/data/number_6x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T4 = File.ReadAllBytes("Resources/data/number_4x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T11 = File.ReadAllBytes("Resources/data/number_11x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T3 = File.ReadAllBytes("Resources/data/number_3x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T7 = File.ReadAllBytes("Resources/data/number_7x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T9 = File.ReadAllBytes("Resources/data/number_9x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T13 = File.ReadAllBytes("Resources/data/number_13x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T14 = File.ReadAllBytes("Resources/data/number_14x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T16 = File.ReadAllBytes("Resources/data/number_16x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T22 = File.ReadAllBytes("Resources/data/number_22x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T17 = File.ReadAllBytes("Resources/data/number_17x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T24 = File.ReadAllBytes("Resources/data/number_24x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T18 = File.ReadAllBytes("Resources/data/number_18x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T21 = File.ReadAllBytes("Resources/data/number_21x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T23 = File.ReadAllBytes("Resources/data/number_23x.gif");
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T25 = File.ReadAllBytes("Resources/data/number_25x.gif");
            dataList.Add(data);
            for (int i = 0; i < 317; i++)
            {
                data = new TrendDataModel();
                data.PeriodNum = 575990;
                data.RetTime = UtilsTool.ConvertDateToTrendDate();
                data.T25 = File.ReadAllBytes("Resources/data/number_25x.gif");
                dataList.Add(data);
            }
            return dataList;
        }
        private void dataList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 30:
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = UtilsTool.ToColor("#03C");
                        e.CellStyle.SelectionBackColor = UtilsTool.ToColor("#03C");
                        e.CellStyle.SelectionForeColor = Color.White;
                    }
                    break;
                case 31:
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = UtilsTool.ToColor("#F33");
                        e.CellStyle.SelectionBackColor = UtilsTool.ToColor("#F33");
                        e.CellStyle.SelectionForeColor = Color.White;
                    }
                    break;
                case 32:
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = UtilsTool.ToColor("#609");
                        e.CellStyle.SelectionBackColor = UtilsTool.ToColor("#609");
                        e.CellStyle.SelectionForeColor = Color.White;
                    }
                    break;
                case 33:
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = UtilsTool.ToColor("#F90");
                        e.CellStyle.SelectionBackColor = UtilsTool.ToColor("#F90");
                        e.CellStyle.SelectionForeColor = Color.White;
                    }
                    break;
                case 34:
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = UtilsTool.ToColor("#F09");
                        e.CellStyle.SelectionBackColor = UtilsTool.ToColor("#F09");
                        e.CellStyle.SelectionForeColor = Color.White;
                    }
                    break;
                case 35:
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = UtilsTool.ToColor("#0C0");
                        e.CellStyle.SelectionBackColor = UtilsTool.ToColor("#0C0");
                        e.CellStyle.SelectionForeColor = Color.White;
                    }
                    break;
            }
        }
    }
}
