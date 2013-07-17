using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpmate.BizEntity;
using Helpmate.Facades.LotteryWebSvc;
using Helpmate.UI.Forms.Models;
using Helpmate.UI.Forms.UIContorl.Common;
using Helpmate.Facades;
using Common.Utility;
using Helpmate.BizEntity.Enum;
using Helpmate.UI.Forms.Code;

namespace Helpmate.UI.Forms.FormUI
{
    public partial class Omission : Form, IPage
    {
        public CommonFacade serviceFacade = new CommonFacade();
        public OpaqueCommand cmd = new OpaqueCommand();
        public List<SiteModel> SiteMapList { get; set; }

        public Omission()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel() { Text = UtilsModel.GetTotalNav() },
                new SiteModel(){ Text="遗漏号码统计"}
            };
            InitializeComponent();
        }

        public List<SiteModel> GetSiteModelList()
        {
            return SiteMapList = new List<SiteModel>()
            {
                new SiteModel() { Text = UtilsModel.GetTotalNav() },
                new SiteModel(){ Text="遗漏号码统计"}
            };
        }
        private void Omission_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
            QueryData();
        }

        public void QueryData(int? pageIndex = null)
        {
            if (!bgwApp.IsBusy)
            {
                cmd.ShowOpaqueLayer(this, 125, true);
                bgwApp.RunWorkerAsync();
            }
        }

        private void bgwApp_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = serviceFacade.QueryOmission();
        }

        private void bgwApp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmd.HideOpaqueLayer();
            var result = e.Result as ResultRMOfListOfOmitStatistics;

            if (e.Error != null)
            {
                WriteLog.Write("QueryOmission", e.Error.Message);
                AppMessage.AlertErrMessage(ConsoleConst.ERROR_SERVER);
                return;
            }

            if (PageUtils.CheckError(result) && result.Data != null)
            {

                BindGridHead();
                BindGridFoot();

                var listOne = new List<OmissionNumModel>();
                for (int i = 0; i < 14; i++)
                {
                    var item = new OmissionNumModel() { Num = UtilsModel.LoadNumImage(i) };
                    var itemTemp = result.Data.FirstOrDefault(temp => temp.RetNum == i);
                    if (itemTemp != null)
                    {
                        item.MaxOmitCnt = itemTemp.MaxOmitCnt;
                        item.OmitCnt = itemTemp.OmitCnt;
                        item.StandardCnt = itemTemp.StandardCnt;
                    }
                    listOne.Add(item);
                }

                var listTwo = new List<OmissionNumModel>();
                for (int i = 27; i > 13; i--)
                {
                    var item = new OmissionNumModel() { Num = UtilsModel.LoadNumImage(i) };
                    var itemTemp = result.Data.FirstOrDefault(temp => temp.RetNum == i);
                    if (itemTemp != null)
                    {
                        item.MaxOmitCnt = itemTemp.MaxOmitCnt;
                        item.OmitCnt = itemTemp.OmitCnt;
                        item.StandardCnt = itemTemp.StandardCnt;
                    }
                    listTwo.Add(item);
                }

                dgvDataOne.DataSource = listOne;
                BindGridData(dgvDataOne);
                dgvDataTwo.DataSource = listTwo;
                BindGridData(dgvDataTwo);
            }
        }


        public void BindGridHead()
        {
            List<OmissionHeadModel> listTemp = new List<OmissionHeadModel>();
            listTemp.Add(new OmissionHeadModel());
            dgvHead.DataSource = listTemp;
            dgvHead.Rows[0].Height = 30;
            for (int i = 0; i < dgvHead.Columns.Count; i++)
            {
                dgvHead.Columns[i].Width = i == 0 || i == 4 ? 60 : 95;
                if (i == dgvHead.Columns.Count - 1) dgvHead.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvHead.Columns[i].DefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
                dgvHead.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvHead.Columns[i].DefaultCellStyle.BackColor = Color.White;
                dgvHead.Columns[i].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvHead.Columns[i].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        public void BindGridFoot()
        {
            var listTemp = new List<RmarkFootModel>();
            listTemp.Add(new RmarkFootModel("各位会员：本统计表内若期数用“红色”显示代表这个号码当前所遗漏的期数已超过他的标准遗漏几率，若用“紫色”显示则表示\r\n\r\n此号码当前遗漏的期数已超过最高遗漏期数。"));
            dgvFoot.DataSource = listTemp;
            dgvFoot.Columns[0].Width = 720;
            dgvFoot.Rows[0].Height = 40;
            dgvFoot.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFoot.Columns[0].DefaultCellStyle.BackColor = Color.White;
            dgvFoot.Columns[0].DefaultCellStyle.SelectionBackColor = Color.White;
            dgvFoot.Columns[0].DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        public void BindGridData(object obj)
        {
            DataGridView dgv = obj as DataGridView;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = i == 0 ? 60 : 95;
                if (i == dgv.Columns.Count - 1) dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns[i].DefaultCellStyle.BackColor = Color.White;
                dgv.Columns[i].DefaultCellStyle.SelectionBackColor = Color.White;
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Height = 28;
            }
        }
    }
}
