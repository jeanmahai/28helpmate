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
using Helpmate.UI.Forms.Properties;
using Helpmate.UI.Forms.Models;

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
            data.T20 = Resources.number_20x;
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
            data.T10 = Resources.number_10x;
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
            data.T12 = Resources.number_12x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T15 = Resources.number_15x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T19 = Resources.number_19x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T27 = Resources.number_27x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T26 = Resources.number_26x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T11 = Resources.number_11x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T0 = Resources.number_0x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T2 = Resources.number_2x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T5 = Resources.number_5x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T8 = Resources.number_8x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T1 = Resources.number_1x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T6 = Resources.number_6x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T4 = Resources.number_4x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T11 = Resources.number_11x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T3 = Resources.number_3x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T7 = Resources.number_7x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T9 = Resources.number_9x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T13 = Resources.number_13x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T14 = Resources.number_14x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T16 = Resources.number_16x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T22 = Resources.number_22x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T17 = Resources.number_17x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T24 = Resources.number_24x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T18 = Resources.number_18x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T21 = Resources.number_21x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T23 = Resources.number_23x;
            dataList.Add(data);
            data = new TrendDataModel();
            data.PeriodNum = 575990;
            data.RetTime = UtilsTool.ConvertDateToTrendDate();
            data.T25 = Resources.number_25x;
            dataList.Add(data);
            for (int i = 0; i < 317; i++)
            {
                data = new TrendDataModel();
                data.PeriodNum = 575990;
                data.RetTime = UtilsTool.ConvertDateToTrendDate();
                data.T25 = Resources.number_25x;
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
