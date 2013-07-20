using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Utility;
using Helpmate.Facades;
using Helpmate.UI.Forms.UIContorl.Common;
using Helpmate.BizEntity.Enum;
using Helpmate.Facades.LotteryWebSvc;
using Helpmate.UI.Forms.Code;
using Helpmate.UI.Forms.Models;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class SpecialAnalysisDetail : Form
    {
        public OpaqueCommand cmd = new OpaqueCommand();
        public TrendFacade serviceFacade = new TrendFacade();
        public string strDate = "";

        public SpecialAnalysisDetail()
        {
            InitializeComponent();
        }
        private void SpecialAnalysisDetail_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.Text = string.Format("{0}详情", strDate);
            QueryData();
        }

        public void QueryData()
        {
            if (!bgwLoad.IsBusy)
            {
                cmd.ShowOpaqueLayer(this, 125, true);
                bgwLoad.RunWorkerAsync();
            }
        }
        private void bgwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            string date = DateTime.Now.ToShortDateString();
            int year = 0;
            int month = 0;
            int day = 0;
            int beginHour = 10;
            int endHour = 10;
            if (!string.IsNullOrEmpty(strDate))
            {
                //7月20日9时
                //7月20日9时-12时
                strDate = strDate.Replace("月", "|");
                strDate = strDate.Replace("日", "|");
                strDate = strDate.Replace("时", "|");
                if (strDate.Contains('-'))
                {
                    strDate = strDate.Replace("-", "");
                    strDate = strDate.Substring(0, strDate.Length - 1);
                    month = int.Parse(strDate.Split('|')[0]);
                    day = int.Parse(strDate.Split('|')[1]);
                    beginHour = int.Parse(strDate.Split('|')[2]);
                    endHour = int.Parse(strDate.Split('|')[3]);
                }
                else
                {
                    strDate = strDate.Substring(0, strDate.Length - 1);
                    month = int.Parse(strDate.Split('|')[0]);
                    day = int.Parse(strDate.Split('|')[1]);
                    beginHour = int.Parse(strDate.Split('|')[2]);
                    endHour = int.Parse(strDate.Split('|')[2]);
                }
                int nowMonth = DateTime.Now.Month;
                if (month == nowMonth || month + 1 == nowMonth)
                    year = DateTime.Now.Year;
                else
                    year = DateTime.Now.Year - 1;
                date = string.Format("{0}-{1}-{2}", year, month, day);
            }
            e.Result = serviceFacade.QuerySpecialAnalysisDetail(date, beginHour, endHour);
        }
        private void bgwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmd.HideOpaqueLayer();
            if (e.Error != null)
            {
                WriteLog.Write("QuerySpecialAnalysisDetail", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            var result = e.Result as ResultRMOfLotteryTrend;

            if (PageUtils.CheckError(result) && result.Data != null)
            {
                if (result.Data.LotteryTimeses != null && result.Data.DataList != null)
                {
                    //统计
                    List<TrendCountModel> countData = (new TrendCountModel()).GetCountList(result.Data.LotteryTimeses);
                    countList.DataSource = countData;
                    SetCountStyle(countList, countData.Count);
                    //头
                    List<TrendHeaderModel> headerData = (new TrendHeaderModel()).GetHeader();
                    headerList.DataSource = headerData;
                    SetHeaderStyle(headerList, 1);
                    //数据
                    List<TrendDataModel> listData = (new TrendDataModel()).GetDataList(result.Data.DataList);
                    gvList.DataSource = listData;
                    SetDataStyle(gvList, listData.Count);
                }
            }
        }
        private void SetHeaderStyle(object obj, int rows)
        {
            DataGridView dgv = obj as DataGridView;
            //设置为不可编辑
            dgv.ReadOnly = true;
            //设置单元格宽高
            dgv.Columns[0].Width = 60;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].DefaultCellStyle.BackColor = UtilsTool.ToColor("#c6e2ff");
            dgv.Columns[0].DefaultCellStyle.SelectionBackColor = UtilsTool.ToColor("#c6e2ff");
            dgv.Columns[0].DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.Columns[1].Width = 80;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].DefaultCellStyle.BackColor = UtilsTool.ToColor("#c6e2ff");
            dgv.Columns[1].DefaultCellStyle.SelectionBackColor = UtilsTool.ToColor("#c6e2ff");
            dgv.Columns[1].DefaultCellStyle.SelectionForeColor = Color.Black;
            for (int i = 2; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 28;
                dgv.Columns[i].DefaultCellStyle.BackColor = UtilsTool.ToColor("#c6e2ff");
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[i].DefaultCellStyle.SelectionBackColor = UtilsTool.ToColor("#c6e2ff");
                dgv.Columns[i].DefaultCellStyle.SelectionForeColor = Color.Black;
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
        private void SetCountStyle(object obj, int rows)
        {
            DataGridView dgv = obj as DataGridView;
            //设置为不可编辑
            dgv.ReadOnly = true;
            //设置单元格宽高
            dgv.Columns[0].Width = 140;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].DefaultCellStyle.BackColor = UtilsTool.ToColor("#fffde3");
            dgv.Columns[0].DefaultCellStyle.SelectionBackColor = UtilsTool.ToColor("#fffde3");
            dgv.Columns[0].DefaultCellStyle.SelectionForeColor = Color.Black;
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 28;
                dgv.Columns[i].DefaultCellStyle.BackColor = UtilsTool.ToColor("#fffde3");
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[i].DefaultCellStyle.SelectionBackColor = UtilsTool.ToColor("#fffde3");
                dgv.Columns[i].DefaultCellStyle.SelectionForeColor = Color.Black;
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
                dgv.Columns[i].Width = 28;
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
        private void gvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
