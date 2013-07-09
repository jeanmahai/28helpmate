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
using Helpmate.BizEntity;
using Helpmate.UI.Forms.UIContorl.Common;
using Helpmate.Facades.LotteryWebService;
using Helpmate.UI.Forms.Models;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class SuperTrend : Form, IPage
    {
        public TrendFacade serviceFacade = new TrendFacade();
        public List<SiteModel> SiteMapList { get; set; }

        public SuperTrend()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel(){ Text="本期预测分析"},
                new SiteModel(){ Text="超级开奖走势"}
            };
            InitializeComponent();
            QueryData(1);
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

        #region 异步调用Service
        public OpaqueCommand cmd = new OpaqueCommand();
        public void QueryData(int? pageIndex = null)
        {
            cmd.ShowOpaqueLayer(this, 125, true);
            QueryDataDelegate dn = new QueryDataDelegate(AsyncWaysQueryData);
            AsyncCallback acb = new AsyncCallback(CallBackMethod);
            IAsyncResult iar = dn.BeginInvoke(pageIndex.Value, acb, dn);
        }
        public delegate ResultRMOfLotteryTrend QueryDataDelegate(int pageIndex);
        private ResultRMOfLotteryTrend AsyncWaysQueryData(int pageIndex)
        {
            return serviceFacade.QueryTrend(pageIndex);
        }
        public void CallBackMethod(IAsyncResult ar)
        {
            QueryDataDelegate dn = (QueryDataDelegate)ar.AsyncState;
            var data = dn.EndInvoke(ar);
            this.LoadData(data.Data.DataList, data.Data.LotteryTimeses);
        }
        #endregion
        #region 异步Bind
        public delegate void LoadDataCallback(LotteryExtByBJ[] list, LotteryTimes[] count);
        private void LoadData(LotteryExtByBJ[] list, LotteryTimes[] count)
        {
            if (this.lblPage.InvokeRequired)
            {
                LoadDataCallback d = new LoadDataCallback(LoadData);
                this.Invoke(d, new object[] { list, count });
            }
            else
            {
                //统计
                List<TrendCountModel> countData = (new TrendCountModel()).GetCountList(count);
                countList.DataSource = countData;
                SetCountStyle(countList, countData.Count);
                //头
                List<TrendHeaderModel> headerData = (new TrendHeaderModel()).GetHeader();
                headerList.DataSource = headerData;
                SetHeaderStyle(headerList, 1);
                //数据
                List<TrendDataModel> listData = (new TrendDataModel()).GetDataList(list);
                dataList.DataSource = listData;
                SetDataStyle(dataList, listData.Count);
            }
            cmd.HideOpaqueLayer();
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
                dgv.Columns[i].Width = 25;
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
                dgv.Columns[i].Width = 25;
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
        #endregion
    }
}
