﻿using System;
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
using Helpmate.Facades.LotteryWebSvc;
using Helpmate.UI.Forms.Models;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class SuperTrend : Form, IPage
    {
        BaseFacade bf = new BaseFacade();
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
        }
        public void QueryData(int? pageIndex = null)
        {
            #region 初始化小时选择数据
            ddlHour.Items.Clear();
            if (Header.RegionSourceSysNo == 10001)
            {
                //北京，9-23
                int hour = 9;
                this.ddlHour.Items.Add(" 请选择 ");
                while (hour < 24)
                {
                    this.ddlHour.Items.Add(string.Format(" {0} 时 ", hour));
                    hour++;
                }
                this.ddlHour.SelectedIndex = 0;
            }
            else if (Header.RegionSourceSysNo == 10002)
            {
                //加拿大，全部小时
                int hour = 0;
                this.ddlHour.Items.Add(" 请选择 ");
                while (hour < 24)
                {
                    this.ddlHour.Items.Add(string.Format(" {0} 小时 ", hour));
                    hour++;
                }
                this.ddlHour.SelectedIndex = 0;
            }
            #endregion
            #region 初始化分钟选择数据
            this.ddlMinute.Items.Clear();
            if (Header.RegionSourceSysNo == 10001)
            {
                //北京，5分钟一期
                int minute = 0;
                this.ddlMinute.Items.Add(" 请选择 ");
                while (minute < 60)
                {
                    this.ddlMinute.Items.Add(string.Format(" {0} 分钟 ", minute));
                    minute += 5;
                }
                this.ddlMinute.SelectedIndex = 0;
            }
            else if (Header.RegionSourceSysNo == 10002)
            {
                //加拿大，4分钟一期
                int minute = 0;
                this.ddlMinute.Items.Add(" 请选择 ");
                while (minute < 60)
                {
                    if (Header.SiteSourceSysNo == 10001)
                    {
                        //龙虎
                        this.ddlMinute.Items.Add(string.Format(" {0} 分钟 ", minute));
                    }
                    else if (Header.SiteSourceSysNo == 10002 || Header.SiteSourceSysNo == 10003)
                    {
                        //71豆，芝麻西西
                        this.ddlMinute.Items.Add(string.Format(" {0} 分钟 ", minute + 1));
                    }
                    minute += 4;
                }
                this.ddlMinute.SelectedIndex = 0;
            }
            #endregion            
            tbxDate.Text = DateTime.Now.ToShortDateString();
            LoadData(1, DateTime.Now.ToShortDateString(), "", "");
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
        public void LoadData(int pageIndex, string date, string hour, string minute)
        {
            cmd.ShowOpaqueLayer(this, 125, true);
            QueryDataDelegate dn = new QueryDataDelegate(AsyncWaysQueryData);
            AsyncCallback acb = new AsyncCallback(CallBackMethod);
            IAsyncResult iar = dn.BeginInvoke(pageIndex, date, hour, minute, acb, dn);
        }
        public delegate ResultRMOfLotteryTrend QueryDataDelegate(int pageIndex, string date, string hour, string minute);
        private ResultRMOfLotteryTrend AsyncWaysQueryData(int pageIndex, string date, string hour, string minute)
        {
            return serviceFacade.QuerySuperTrend(pageIndex, date, hour, minute);
        }
        public void CallBackMethod(IAsyncResult ar)
        {
            QueryDataDelegate dn = (QueryDataDelegate)ar.AsyncState;
            var result = dn.EndInvoke(ar);
            if (result != null && result.Data != null
                && result.Data.DataList != null && result.Data.LotteryTimeses != null)
                this.LoadResultData(result.Data.DataList, result.Data.LotteryTimeses, result.Data.PageIndex, result.Data.PageCount);
            else
                this.LoadResultData(null, null, 0, 0);
            if (result.Code == bf.ERROR_VALIDATE_TOKEN_CODE)
            {
                DialogResult dr = MessageBox.Show(bf.ERROR_VALIDATE_TOKEN_MSG, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    Form loginForm = new LoginForm();
                    loginForm.Show();
                }
            }
        }
        #endregion
        #region 异步Bind
        public delegate void LoadResultDataCallback(LotteryExtByBJ[] list, LotteryTimes[] count, int currPageIndex, int pageCount);
        private void LoadResultData(LotteryExtByBJ[] list, LotteryTimes[] count, int currPageIndex, int pageCount)
        {
            if (this.lblPage.InvokeRequired)
            {
                LoadResultDataCallback d = new LoadResultDataCallback(LoadResultData);
                this.Invoke(d, new object[] { list, count, currPageIndex, pageCount });
            }
            else
            {
                if (count != null && list != null)
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
                    //页码信息
                    lnkFirst.Enabled = true;
                    lnkPrev.Enabled = true;
                    lnkLast.Enabled = true;
                    lnkNext.Enabled = true;
                    if (currPageIndex <= 1)
                    {
                        lnkFirst.Enabled = false;
                        lnkPrev.Enabled = false;
                    }
                    if (currPageIndex >= pageCount)
                    {
                        lnkLast.Enabled = false;
                        lnkNext.Enabled = false;
                    }
                    lblPage.Text = string.Format("{0}/{1}", currPageIndex, pageCount);
                }
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
        #endregion

        #region 分页
        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkLast_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            if (!string.IsNullOrEmpty(tbxDate.Text.Trim())
                   && !DateTime.TryParse(tbxDate.Text.Trim(), out dtTime))
            {
                MessageBox.Show("请选择正确的日期！");
            }
            else
            {
                int pageIndex = int.Parse(lblPage.Text.Trim().Split('/')[1]);
                string date = tbxDate.Text.Trim();
                string hour = ddlHour.Text.Replace("时", "").Trim();
                string minute = ddlMinute.Text.Replace("分钟", "").Trim();
                hour = hour == "请选择" ? "" : hour;
                minute = minute == "请选择" ? "" : minute;
                LoadData(pageIndex, date, hour, minute);
            }
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkFirst_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            if (!string.IsNullOrEmpty(tbxDate.Text.Trim())
                   && !DateTime.TryParse(tbxDate.Text.Trim(), out dtTime))
            {
                MessageBox.Show("请选择正确的日期！");
            }
            else
            {
                string date = tbxDate.Text.Trim();
                string hour = ddlHour.Text.Replace("时", "").Trim();
                string minute = ddlMinute.Text.Replace("分钟", "").Trim();
                hour = hour == "请选择" ? "" : hour;
                minute = minute == "请选择" ? "" : minute;
                LoadData(1, date, hour, minute);
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            if (!string.IsNullOrEmpty(tbxDate.Text.Trim())
                   && !DateTime.TryParse(tbxDate.Text.Trim(), out dtTime))
            {
                MessageBox.Show("请选择正确的日期！");
            }
            else
            {
                int pageIndex = int.Parse(lblPage.Text.Trim().Split('/')[0]) - 1;
                pageIndex = pageIndex < 1 ? 1 : pageIndex;
                string date = tbxDate.Text.Trim();
                string hour = ddlHour.Text.Replace("时", "").Trim();
                string minute = ddlMinute.Text.Replace("分钟", "").Trim();
                hour = hour == "请选择" ? "" : hour;
                minute = minute == "请选择" ? "" : minute;
                LoadData(pageIndex, date, hour, minute);
            }
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            if (!string.IsNullOrEmpty(tbxDate.Text.Trim())
                   && !DateTime.TryParse(tbxDate.Text.Trim(), out dtTime))
            {
                MessageBox.Show("请选择正确的日期！");
            }
            else
            {
                int pageIndex = int.Parse(lblPage.Text.Trim().Split('/')[0]) + 1;
                int pageCount = int.Parse(lblPage.Text.Trim().Split('/')[1]);
                pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
                string date = tbxDate.Text.Trim();
                string hour = ddlHour.Text.Replace("时", "").Trim();
                string minute = ddlMinute.Text.Replace("分钟", "").Trim();
                hour = hour == "请选择" ? "" : hour;
                minute = minute == "请选择" ? "" : minute;
                LoadData(pageIndex, date, hour, minute);
            }
        }
        #endregion

        #region 选择日期
        private void tbxDate_Click(object sender, EventArgs e)
        {
            string dtSltDate = string.Empty;
            OpenWindow(ref dtSltDate);
            if (dtSltDate != null)
                this.tbxDate.Text = dtSltDate;
        }
        public static void OpenWindow(ref string dtSltDate)
        {
            DateSlt frmDate = new DateSlt();
            dtSltDate = frmDate.GetNewWindowDateTime();
        }
        #endregion

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.Now;
            if (string.IsNullOrEmpty(tbxDate.Text.Trim())
                && ddlHour.Text.Trim() == "请选择"
                && ddlMinute.Text.Trim() == "请选择")
            {
                MessageBox.Show("请选择一个条件进行查询！");
            }
            else if (!string.IsNullOrEmpty(tbxDate.Text.Trim()) 
                && !DateTime.TryParse(tbxDate.Text.Trim(), out dtTime))
            {
                MessageBox.Show("请选择正确的日期！");
            }
            else
            {
                string date = tbxDate.Text.Trim();
                string hour = ddlHour.Text.Replace("时", "").Trim();
                string minute = ddlMinute.Text.Replace("分钟", "").Trim();
                hour = hour == "请选择" ? "" : hour;
                minute = minute == "请选择" ? "" : minute;
                LoadData(1, date, hour, minute);
            }
        }
    }
}
