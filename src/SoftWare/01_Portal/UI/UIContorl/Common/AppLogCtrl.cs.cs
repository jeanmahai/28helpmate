using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Helpmate.BizEntity;

namespace Helpmate.UI.Forms.UIContorl.Common
{
    public partial class AppLogCtrl : UserControl
    {
        private static AppLogCtrl _appLogCtrl;
        private PageModel _pageModel = new PageModel();


        public AppLogCtrl()
        {
            InitializeComponent();
        }

        private void AppLogCtrl_Load(object sender, EventArgs e)
        {
            InitPageModel();
            LoadLogData(_pageModel);
            SimplePageCtrl simplePageCtrl = SimplePageCtrl.Initialize();
            simplePageCtrl.InvokeLoadData = new SimplePageCtrl.LoadData(LoadLogData);
            pnlPage.Controls.Add(simplePageCtrl);
        }

        private void InitPageModel()
        {
            _pageModel.Index = 1;
            _pageModel.Size = 10;
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            LoadLogData(_pageModel);
        }

        private void LoadLogData(PageModel pageModel)
        {
            //LoadingMsg(pnlLoading, AppMessage.Loading, "正在加载...");
            //this.Invoke(InvokeBindData, pageModel);
        }

        public void ImpBindData(PageModel pageModel)
        {
            //DataTable dt = CommonDAL.ListByPageAppLog(string.Empty, pageModel);
            //dgvItems.AutoGenerateColumns = false;
            //dgvItems.DataSource = dt;
            //SimplePageCtrl.Initialize().LoadPageCtr(pageModel);
            //ClearLoadingMsg(pnlLoading);
        }
    }
}
