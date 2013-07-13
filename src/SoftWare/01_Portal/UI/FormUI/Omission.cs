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

namespace Helpmate.UI.Forms.FormUI
{
    public partial class Omission : Form, IPage
    {
        public delegate ResultRMOfListOfOmitStatistics QueryDataDelegate();
        public delegate void BindDataCallback(ResultRMOfListOfOmitStatistics result);
        BaseFacade bf = new BaseFacade();
        public CommonFacade serviceFacade = new CommonFacade();
        public OpaqueCommand cmd = new OpaqueCommand();
        public List<SiteModel> SiteMapList { get; set; }
        public Omission()
        {
            SiteMapList = new List<SiteModel>()
            {
                new SiteModel(){ Text="本期统计"},
                new SiteModel(){ Text="遗漏分析"}
            };
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        private void Omission_Load(object sender, EventArgs e)
        {
            lblRemark.Text = "各位会员：本统计表内若期数用“红色”显示代表这个号码当前所遗漏的期数已超过他的标准遗漏几率，若用“紫色”显示则表示\r\n\r\n此号码当前遗漏的期数已超过最高遗漏期数。";
            QueryData();
        }

        public void QueryData(int? pageIndex = null)
        {
            cmd.ShowOpaqueLayer(this, 125, true);
            QueryDataDelegate dele = new QueryDataDelegate(QueryOmission);
            AsyncCallback callBack = new AsyncCallback(CallBackMethod);
            IAsyncResult iar = dele.BeginInvoke(callBack, dele);
        }

        public void CallBackMethod(IAsyncResult ar)
        {
            QueryDataDelegate dn = (QueryDataDelegate)ar.AsyncState;
            var result = dn.EndInvoke(ar);

            if (this.InvokeRequired)
            {
                BindDataCallback bind = new BindDataCallback(BindDataAsync);
                this.Invoke(bind, result);
            }
            else
            {
                BindDataAsync(result);
            }
        }

        private void BindDataAsync(ResultRMOfListOfOmitStatistics result)
        {
            if (result != null && result.Data != null)
            {
                foreach (OmitStatistics item in result.Data)
                {
                    var lblNow = tlpNuming.Controls.Find("lblNow" + item.RetNum, true).First() as Label;
                    lblNow.Text = item.OmitCnt.ToString();

                    var lblMax = tlpNuming.Controls.Find("lblLen" + item.RetNum, true).First() as Label;
                    lblMax.Text = item.MaxOmitCnt.ToString();

                    var lblStandard = tlpNuming.Controls.Find("lblBZ" + item.RetNum, true).First() as Label;
                    lblStandard.Text = item.StandardCnt.ToString();

                    if (item.OmitCnt > item.StandardCnt)
                    {
                        lblNow.ForeColor = Color.Red;
                    }
                    else if (item.OmitCnt > item.MaxOmitCnt)
                    {
                        lblNow.ForeColor = Color.Purple;
                    }
                    else
                    {
                        lblNow.ForeColor = Color.Black;
                    }
                }
            }
            cmd.HideOpaqueLayer();
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

        private ResultRMOfListOfOmitStatistics QueryOmission()
        {
            return serviceFacade.QueryOmission();
        }
    }
}
