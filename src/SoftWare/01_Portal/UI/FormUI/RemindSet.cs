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
        BaseFacade bf = new BaseFacade();
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
            var result = e.Result as ResultRMOfRemindStatistics;

            if (e.Error != null)
            {
                WriteLog.Write("GetRemindLottery", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result) && result.Data != null)
            {
                int currPageIndex = 0;// result.Data.PageIndex;
                int pageCount = 0;// result.Data.PageCount;
                //头
                List<RemindStatisticsModel> headerData = (new RemindStatisticsModel()).GetHeader();
                headerList.DataSource = headerData;
                SetHeaderStyle(headerList, 1);
                //数据
                //List<TrendDataModel> listData = (new TrendDataModel()).GetDataList(result.Data.DataList);
                //dataList.DataSource = listData;
                //SetDataStyle(dataList, listData.Count);
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
        private void SetHeaderStyle(object obj, int rows)
        {
            DataGridView dgv = obj as DataGridView;
            //设置为不可编辑
            dgv.ReadOnly = true;
            //设置单元格宽高
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 80;
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
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 80;
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
                MessageBox.Show("添加成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
