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

namespace Helpmate.UI.Forms.FormUI
{
    public partial class SpecialAnalysis : Form, IPage
    {
        public CommonFacade serviceFacade = new CommonFacade();
        public List<SiteModel> SiteMapList { get; set; }
        public OpaqueCommand cmd = new OpaqueCommand();

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
            ddlHour.DataSource = UtilsTool.LotteryHours();
            ddlHour.SelectedIndex = 0;
            BindGridHead();
            BindGridFoot();
            BindGridNumber();
            BindGridTrend();
        }

        public void QueryData(int? pageIndex = null)
        {

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
                        dgvHead.Columns[i].Width = 190;
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
            listTemp.Add(new RmarkFootModel("各位会员注意：本表所统计得开奖数据为15天（包括当日）。另属“未出现号码”栏目的统计区间是4—24，“极品号”栏目的统计区间是0—3和25—27请大家注意区分。"));
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

        public void BindGridNumber()
        {
            List<SpecialNumberModel> listTemp = new List<SpecialNumberModel>();
            listTemp.Add(new SpecialNumberModel());
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
                    dgvNumber.Columns[i].Width = 75;
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

        public void BindGridTrend()
        {
            List<SpecialTrendModel> listTemp = new List<SpecialTrendModel>();
            listTemp.Add(new SpecialTrendModel());
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
                    dgvTrend.Columns[i].Width = 75;
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
    }
}
