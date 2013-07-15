using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.Facades;
using Helpmate.BizEntity;
using Helpmate.UI.Forms.UIContorl.Common;
using Helpmate.Facades.LotteryWebSvc;
using Common.Utility;
using Helpmate.UI.Forms.Code;
using Helpmate.BizEntity.Enum;
using Helpmate.UI.Forms.Models;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class RemindSet : Form
    {
        public CustomerFacade serviceFacade = new CustomerFacade();
        public List<SiteModel> SiteMapList { get; set; }
        public OpaqueCommand cmd = new OpaqueCommand();

        public RemindSet()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel(){ Text="提醒设置"}
            };
            InitializeComponent();
        }

        private void RemindSet_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //加载列表
            ddlGame.DataSource = UtilsTool.GameList();
            ddlGame.SelectedIndex = 0;
            ddlSource.DataSource = UtilsTool.SourceList();
            ddlSource.SelectedIndex = 0;
            ddlSite.DataSource = UtilsTool.SiteList();
            ddlSite.SelectedIndex = 0;
            for (int i = 0; i <= 27; i++)
            {
                ddlResult.Items.Add(i.ToString());
            }
            ddlResult.SelectedIndex = 0;
            QueryData(1);
        }
        public void QueryData(int? pageIndex = null)
        {
            if (!bgworkLoadData.IsBusy)
            {
                cmd.ShowOpaqueLayer(this, 125, true);
                bgworkLoadData.RunWorkerAsync(pageIndex);
            }
        }        

        #region 加载数据
        private void bgworkLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            int pageIndex = int.Parse(e.Argument.ToString());
            e.Result = serviceFacade.GetRemindLottery(pageIndex);
        }
        private void bgworkLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmd.HideOpaqueLayer();
            var result = e.Result as ResultRMOfPageListOfRemindStatistics;

            if (e.Error != null)
            {
                WriteLog.Write("GetRemindLottery", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result) && result.Data != null)
            {
                int currPageIndex = result.Data.PageIndex;
                int pageCount = result.Data.PageCount;
                //头
                List<RemindStatisticsModel> headerData = (new RemindStatisticsModel()).GetHeader();
                headerList.DataSource = headerData;
                SetHeaderStyle(headerList);
                //数据
                List<RemindStatisticsModel> listData = (new RemindStatisticsModel()).GetDataList(result.Data.List);
                dataList.DataSource = listData;
                SetDataStyle(dataList);
                #region 添加删除按钮
        //        private void TestForm_Load(object sender, EventArgs e)
        //{
        //    List<Data> dataList = new List<Data>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Data item = new Data();
        //        item.SysNo = i;
        //        item.ID = i.ToString();
        //        item.Name = string.Format("名称{0}", i);
        //        dataList.Add(item);
        //    }
        //    gvList.DataSource = dataList;
        //    DataGridViewImageColumn btnImageDel = new DataGridViewImageColumn(false);
        //    Image imgEdit = new Bitmap(Properties.Resources.del, new Size(16, 16));
        //    btnImageDel.Image = imgEdit;
        //    btnImageDel.Width = 50;
        //    btnImageDel.HeaderText = "删除";
        //    btnImageDel.Name = "btnImageDel";
        //    gvList.Columns.Insert(3, btnImageDel);
        //}

        //private void gvList_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int colIdx = e.ColumnIndex;
        //    if (colIdx == 3)
        //    {
        //        string sysNo = gvList["SysNo", e.RowIndex].Value.ToString();
        //        if (MessageBox.Show("确认删除？", "此删除不可恢复", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //        {
        //            MessageBox.Show(string.Format("删除记录编号{0}！", sysNo));
        //        }
        //    }
        //}
                #endregion
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
        void dataList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataList[e.ColumnIndex, e.RowIndex].Value == null) return;
            MessageBox.Show(dataList[e.ColumnIndex, e.RowIndex].Value.ToString());
        }
        private void SetHeaderStyle(object obj)
        {
            DataGridView dgv = obj as DataGridView;
            //设置为不可编辑
            dgv.ReadOnly = true;
            //设置单元格宽高
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 150;
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
        private void SetDataStyle(object obj)
        {
            DataGridView dgv = obj as DataGridView;
            //设置为不可编辑
            dgv.ReadOnly = true;
            //设置单元格宽高
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 150;
                dgv.Columns[i].DefaultCellStyle.BackColor = Color.White;
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[i].DefaultCellStyle.SelectionBackColor = Color.White;
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
        #endregion

        #region 添加
        private void btnAdd_Click(object sender, EventArgs e)
        {
            RemindStatistics item = new RemindStatistics();
            item.GameSysNo = int.Parse(ddlGame.SelectedValue.ToString());
            item.SourceSysNo = int.Parse(ddlSource.SelectedValue.ToString());
            item.SiteSysNo = int.Parse(ddlSite.SelectedValue.ToString());
            item.RetNum = int.Parse(ddlResult.Text.Trim());
            int cnt = 0;
            if (!int.TryParse(tbxCnt.Text.Trim(), out cnt))
            {
                MessageBox.Show("请输入正确的次数！");
            }
            else
            {
                item.Cnt = cnt;
                item.Status = 0;
                if (!bgworkerAdd.IsBusy)
                {
                    cmd.ShowOpaqueLayer(this, 125, true);
                    bgworkerAdd.RunWorkerAsync(item);
                }
            }
        }
        private void bgworkerAdd_DoWork(object sender, DoWorkEventArgs e)
        {
            RemindStatistics remind = e.Argument as RemindStatistics;
            e.Result = serviceFacade.AddRemindLottery(remind);
        }
        private void bgworkerAdd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmd.HideOpaqueLayer();
            var result = e.Result as ResultRMOfBoolean;

            if (e.Error != null)
            {
                WriteLog.Write("GetUserInfo", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result))
            {
                tbxCnt.Text = "";
                QueryData(1);
                MessageBox.Show("添加成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            int pageIndex = int.Parse(lblPage.Text.Trim().Split('/')[1]);
            QueryData(pageIndex);
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkFirst_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QueryData(1);
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int pageIndex = int.Parse(lblPage.Text.Trim().Split('/')[0]) - 1;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            QueryData(pageIndex);
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int pageIndex = int.Parse(lblPage.Text.Trim().Split('/')[0]) + 1;
            int pageCount = int.Parse(lblPage.Text.Trim().Split('/')[1]);
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            QueryData(pageIndex);
        }
        #endregion
    }
}
