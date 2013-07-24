using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.UI.Forms.UIContorl.Common;
using Helpmate.Facades;
using Helpmate.BizEntity;
using Helpmate.UI.Forms.Code;
using Helpmate.UI.Forms.Models;
using Common.Utility;
using Helpmate.QueryFilter;
using Helpmate.BizEntity.Enum;
using Helpmate.Facades.LotteryWebSvc;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class SpecialAnalysis : Form, IPage
    {
        public TrendFacade serviceFacade = new TrendFacade();
        public List<SiteModel> SiteMapList { get; set; }
        public OpaqueCommand cmd = new OpaqueCommand();
        public SpecialAnalysisFilter filter = new SpecialAnalysisFilter();

        public SpecialAnalysis()
        {
            GetSiteModelList();
            InitializeComponent();
        }

        public List<SiteModel> GetSiteModelList()
        {
            return SiteMapList = new List<SiteModel>()
            {
                new SiteModel() { Text = UtilsModel.GetTotalNav() },
                new SiteModel(){ Text="特殊分析"}
            };
        }

        private void SpecialAnalysis_Load(object sender, EventArgs e)
        {
            BindGridHead();
            BindGridFoot();
            QueryData();
        }

        public int regionSourceSysNo = 0;
        public void QueryData(int? pageIndex = null)
        {
            if (!bgwApp.IsBusy)
            {
                if (regionSourceSysNo != Header.RegionSourceSysNo)
                {
                    regionSourceSysNo = Header.RegionSourceSysNo;
                    ddlHour.DataSource = UtilsTool.LotteryHours(Header.RegionSourceSysNo);
                    ddlHour.SelectedIndex = 0;
                }

                var strArray = ddlHour.SelectedValue.ToString().Split('-');
                if (strArray.Length == 2)
                {
                    filter.BeginHour = Convert.ToInt32(strArray[0]);
                    filter.EndHour = Convert.ToInt32(strArray[1]);
                }
                else
                {
                    filter.BeginHour = Convert.ToInt32(strArray[0]);
                    filter.EndHour = Convert.ToInt32(strArray[0]);
                }

                cmd.ShowOpaqueLayer(this, 125, true);
                bgwApp.RunWorkerAsync();
            }
        }

        public void BindGridHead()
        {
            List<SpecialHeadModel> listTemp = new List<SpecialHeadModel>();
            listTemp.Add(new SpecialHeadModel());
            dgvHead.DataSource = listTemp;
            dgvHead.Rows[0].Height = 29;

            for (int i = 0; i < dgvHead.Columns.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvHead.Columns[i].Width = 95;
                        break;
                    case 7:
                        dgvHead.Columns[i].Width = 350;
                        break;
                    case 8:
                        dgvHead.Columns[i].Width = 95;
                        break;
                    default:
                        dgvHead.Columns[i].Width = 52;
                        break;
                }
                if (i == dgvHead.Columns.Count - 1) dgvHead.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvHead.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvHead.Columns[i].DefaultCellStyle.BackColor = Color.White;
                dgvHead.Columns[i].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvHead.Columns[i].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        public void BindGridFoot()
        {
            var listTemp = new List<RmarkFootModel>();
            //另属“未出现号码”栏目的统计区间是4—24，“极品号”栏目的统计区间是0—3和25—27请大家注意区分。
            listTemp.Add(new RmarkFootModel("各位会员注意：本表所统计得开奖数据为15天（包括当日）。"));
            dgvFoot.DataSource = listTemp;
            dgvFoot.Rows[0].Height = 39;
            dgvFoot.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvFoot.Columns[0].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
            dgvFoot.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFoot.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvFoot.Columns[0].DefaultCellStyle.BackColor = Color.White;
            dgvFoot.Columns[0].DefaultCellStyle.SelectionBackColor = Color.White;
            dgvFoot.Columns[0].DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryData();
        }

        private void bgwApp_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = serviceFacade.GetSpecial(filter.BeginHour, filter.EndHour);
        }

        private void bgwApp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmd.HideOpaqueLayer();
            if (e.Error != null)
            {
                WriteLog.Write("QueryOmission", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            var result = e.Result as ResultRMOfSpecialLottery;
            if (PageUtils.CheckError(result) && result.Data != null)
            {
                BindGridNumber(result.Data);
                BindGridTrend(result.Data);
                BindGridData(result.Data);
            }
        }

        public void BindGridNumber(SpecialLottery result)
        {
            List<SpecialNumberModel> listTemp = new List<SpecialNumberModel>();
            var temp = new SpecialNumberModel()
            {
                NumberOne = string.Format("{0}次", result.LotteryTypeAvg.AvgBig),
                NumberTwo = string.Format("{0}次", result.LotteryTypeAvg.AvgSmall),
                NumberThree = string.Format("{0}次", result.LotteryTypeAvg.AvgOdd),
                NumberFour = string.Format("{0}次", result.LotteryTypeAvg.AvgDual),
                NumberFive = string.Format("{0}次", result.LotteryTypeAvg.AvgMiddle),
                NumberSix = string.Format("{0}次", result.LotteryTypeAvg.AvgSide),
                StableNumberOne = UtilsModel.LoadNumImage(result.LotteryStableNumber.RetNum1),
                StableNumberTwo = UtilsModel.LoadNumImage(result.LotteryStableNumber.RetNum2),
                StableNumberThree = UtilsModel.LoadNumImage(result.LotteryStableNumber.RetNum3)
            };
            listTemp.Add(temp);
            dgvNumber.DataSource = listTemp;
            dgvNumber.Rows[0].Height = 26;
            for (int i = 0; i < dgvNumber.Columns.Count; i++)
            {
                if (i == 0 || i == 7)
                {
                    dgvNumber.Columns[i].Width = 95;
                }
                else if (i > 7)
                {
                    dgvNumber.Columns[i].Width = 128;
                }
                else
                {
                    dgvNumber.Columns[i].Width = 52;
                }
                if (i == dgvNumber.Columns.Count - 1) dgvNumber.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvNumber.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvNumber.Columns[i].DefaultCellStyle.BackColor = Color.White;
                dgvNumber.Columns[i].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvNumber.Columns[i].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        public void BindGridTrend(SpecialLottery result)
        {
            List<SpecialTrendModel> listTemp = new List<SpecialTrendModel>();

            var temp = new SpecialTrendModel()
            {
                NumberOne = Convert.ToString(result.LotteryTypeAvg.PBig),
                NumberTwo = Convert.ToString(result.LotteryTypeAvg.PSmall),
                NumberThree = Convert.ToString(result.LotteryTypeAvg.POdd),
                NumberFour = Convert.ToString(result.LotteryTypeAvg.PDual),
                NumberFive = Convert.ToString(result.LotteryTypeAvg.PMiddle),
                NumberSix = Convert.ToString(result.LotteryTypeAvg.PSide),
                AriseNumberOne = Convert.ToString(result.LotteryStableNumber.DayAndCnt1),
                AriseNumberTwo = Convert.ToString(result.LotteryStableNumber.DayAndCnt2),
                AriseNumberThree = Convert.ToString(result.LotteryStableNumber.DayAndCnt3)
            };
            listTemp.Add(temp);
            dgvTrend.DataSource = listTemp;
            dgvTrend.Rows[0].Height = 26;
            for (int i = 0; i < dgvTrend.Columns.Count; i++)
            {
                if (i == 0 || i == 7)
                {
                    dgvTrend.Columns[i].Width = 95;
                }
                else if (i > 7)
                {
                    dgvTrend.Columns[i].Width = 128;
                }
                else
                {
                    dgvTrend.Columns[i].Width = 52;
                }
                if (i == dgvTrend.Columns.Count - 1) dgvTrend.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTrend.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTrend.Columns[i].DefaultCellStyle.BackColor = Color.White;
                dgvTrend.Columns[i].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvTrend.Columns[i].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        public void BindGridData(SpecialLottery result)
        {
            var dataList = new List<SpecialDataModel>();
            foreach (LotteryTypeCount item in result.LotteryTypeCount)
            {
                var data = new SpecialDataModel()
                {
                    Date = item.Date,
                    Small = string.Format("{0}次", item.Small),
                    Big = string.Format("{0}次", item.Big),
                    Middle = string.Format("{0}次", item.Middle),
                    Side = string.Format("{0}次", item.Side),
                    Odd = string.Format("{0}次", item.Odd),
                    Dual = string.Format("{0}次", item.Dual),
                    NoAppearNum = item.NoAppearNum,
                    BestNum = item.BestNum
                };
                dataList.Add(data);
            }

            dgvData.DataSource = dataList;

            for (int i = 0; i < dgvData.Columns.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        dgvData.Columns[i].Width = 95;
                        break;
                    case 7:
                        dgvData.Columns[i].Width = 350;
                        break;
                    case 8:
                        dgvData.Columns[i].Width = 95;
                        break;
                    default:
                        dgvData.Columns[i].Width = 52;
                        break;
                }
                if (i == dgvData.Columns.Count - 1) dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvData.Columns[i].DefaultCellStyle.BackColor = Color.White;
                dgvData.Columns[i].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView)) return;
            DataGridView dgvList = (DataGridView)sender;
            if (dgvList.Columns[e.ColumnIndex].DataPropertyName == "LookTitle")
            {
                e.CellStyle.ForeColor = Color.Blue;
                e.CellStyle.Font = new Font(this.Font, FontStyle.Underline);
                dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = dgvList.Rows[e.RowIndex].DataBoundItem as SpecialDataModel;
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e == null || !(sender is DataGridView)) return;
            DataGridView dgvList = (DataGridView)sender;
            if (e.ColumnIndex == 9)
            {
                var cell = dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var data = cell.Tag as SpecialDataModel;
                SpecialAnalysisDetail sadform = new SpecialAnalysisDetail();
                sadform.strDate = data.Date;
                sadform.ShowDialog();
            }
        }

        private void dgvTrend_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView)) return;
            DataGridView dgvList = (DataGridView)sender;
            if (e.ColumnIndex > 0 && e.ColumnIndex < 7)
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.SelectionForeColor = Color.Red;// UtilsTool.ToColor("#0C0");
            }
            else
            {
                e.CellStyle.ForeColor = Color.Black;
            }
        }
    }
}
