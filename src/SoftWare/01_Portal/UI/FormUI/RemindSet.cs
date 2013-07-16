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
    public partial class RemindSet : Form, IPage
    {
        public CustomerFacade serviceFacade = new CustomerFacade();
        public List<SiteModel> SiteMapList { get; set; }
        public OpaqueCommand cmd = new OpaqueCommand();

        public RemindSet()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel() { Text = "提醒设置" }
            };
            InitializeComponent();
        }
        public List<SiteModel> GetSiteModelList()
        {
            return SiteMapList = new List<SiteModel>()
            {
                new SiteModel(){ Text="提醒设置"}
            };
        }
        private void RemindSet_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
            //加载列表
            ddlGame.DataSource = UtilsTool.GameList();
            ddlGame.SelectedIndex = 0;
            ddlSource.DataSource = UtilsTool.SourceList();
            ddlSource.SelectedIndex = 0;
            ddlSite.DataSource = UtilsTool.SiteList();
            ddlSite.SelectedIndex = 0;
            ddlResult.DataSource = UtilsTool.RetNumCategoryList();
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
                List<RemindStatisticsHeaderModel> headerData = (new RemindStatisticsHeaderModel()).GetHeader();
                headerList.DataSource = headerData;
                SetHeaderStyle(headerList);
                //数据
                dataList.Columns.Clear();
                List<RemindStatisticsModel> listData = (new RemindStatisticsModel()).GetDataList(result.Data.List);
                //List<RemindStatisticsModel> listData = (new RemindStatisticsModel()).GetDefaultList();
                dataList.DataSource = listData;
                SetDataStyle(dataList);
                #region 添加删除按钮
                DataGridViewImageColumn btnImageDel = new DataGridViewImageColumn(false);
                Image imgDel = new Bitmap(Properties.Resources.del, new Size(16, 16));
                btnImageDel.Image = imgDel;
                btnImageDel.Width = 150;
                btnImageDel.HeaderText = "";
                btnImageDel.Name = "btnImageDel";
                btnImageDel.DefaultCellStyle.BackColor = Color.White;
                btnImageDel.DefaultCellStyle.SelectionBackColor = Color.White;
                dataList.Columns.Insert(6, btnImageDel);
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
        private void SetHeaderStyle(object obj)
        {
            DataGridView dgv = obj as DataGridView;
            //设置为不可编辑
            dgv.ReadOnly = true;
            //设置单元格宽高
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 150;
                dgv.Columns[i].DefaultCellStyle.BackColor = UtilsTool.ToColor("#E5E5E5");
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[i].DefaultCellStyle.SelectionBackColor = UtilsTool.ToColor("#E5E5E5");
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
        private void dataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int colIdx = e.ColumnIndex;
            if (colIdx == 6)
            {
                string sysNo = dataList["SysNo", e.RowIndex].Value.ToString();
                if (MessageBox.Show("您确认要删除此条提醒设置吗？", "此删除不可恢复", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!bgworkerDel.IsBusy)
                    {
                        cmd.ShowOpaqueLayer(this, 125, true);
                        bgworkerDel.RunWorkerAsync(sysNo);
                    }
                }
            }
        }
        #endregion

        #region 添加
        private void btnAdd_Click(object sender, EventArgs e)
        {
            RemindStatistics item = new RemindStatistics();
            item.GameSysNo = int.Parse(ddlGame.SelectedValue.ToString());
            item.SourceSysNo = int.Parse(ddlSource.SelectedValue.ToString());
            item.SiteSysNo = int.Parse(ddlSite.SelectedValue.ToString());
            item.RetNum = ddlResult.SelectedValue.ToString();
            int cnt = 0;
            if (!int.TryParse(tbxCnt.Text.Trim(), out cnt))
            {
                MessageBox.Show("请输入正确的次数！");
            }
            else if (cnt <= 1)
            {
                MessageBox.Show("次数必须大于1！");
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
                WriteLog.Write("AddRemindLottery", e.Error.Message);
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

        #region 删除
        private void bgworkerDel_DoWork(object sender, DoWorkEventArgs e)
        {
            int sysNo = int.Parse(e.Argument.ToString());
            e.Result = serviceFacade.DelRemindLottery(sysNo);
        }
        private void bgworkerDel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmd.HideOpaqueLayer();
            var result = e.Result as ResultRMOfBoolean;

            if (e.Error != null)
            {
                WriteLog.Write("DelRemindLottery", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result))
            {
                QueryData(1);
                MessageBox.Show("删除成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
