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
            //加载列表
            ddlGame.Items.Add("28游戏");
            ddlGame.SelectedIndex = 0;
            ddlSource.Items.Add("北京");
            ddlSource.Items.Add("加拿大");
            ddlSource.SelectedIndex = 0;
            ddlSite.Items.Add("53游");
            ddlSite.Items.Add("71豆");
            ddlSite.Items.Add("芝麻西西");
            ddlSite.SelectedIndex = 0;
            for (int i = 0; i <= 27; i++)
            {
                ddlResult.Items.Add(i.ToString());
            }
            ddlResult.SelectedIndex = 0;
        }

        private void RemindSet_Load(object sender, EventArgs e)
        {
            //QueryData();
        }

        #region 加载数据
        private void bgworkLoadData_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void bgworkLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        #endregion

        #region 添加
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        private void bgworkerAdd_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void bgworkerAdd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        #endregion
    }
}
