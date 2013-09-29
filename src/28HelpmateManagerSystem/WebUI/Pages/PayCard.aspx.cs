using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DataEntity;
using Logic;
using WebUI.Utility;

namespace WebUI.Pages
{
    public partial class PayCard:RequiredLogin
    {
        public override void PageLoad()
        {
            base.PageLoad();
            btnSave.ServerClick += new EventHandler(btnSave_ServerClick);
            btnSearch.ServerClick += new EventHandler(btnSearch_ServerClick);
            
            UCPager1.PageSize = 10;

            if (!IsPostBack)
            {
                BindData();
            }
        }

        void btnSearch_ServerClick(object sender,EventArgs e)
        {
            BindData();
        }

        void btnSave_ServerClick(object sender,EventArgs e)
        {
            var message = PayCardLogic.CreatePayCard(PayCardCategory.Month,int.Parse(numCount.Value),
                                                     DateTime.Parse(dateFrom.Value),DateTime.Parse(dateTo.Value));
            if (string.IsNullOrEmpty(message))
            {
                Alert("创建成功");
                BindData();
            }
            else
            {
                Alert(message);
            }

        }

        private void BindData()
        {
            var status = int.Parse(sStatus.Value);
            var type = int.Parse(sCate2.Value);
            DateTime? from ;
            try
            {
                from = DateTime.Parse(dateFrom2.Value);
            }
            catch
            {
                from = null;
            }
            DateTime? to;
            try
            {
                to = DateTime.Parse(dateTo2.Value);
            }catch
            {
                to = null;
            }

            var datas = PayCardLogic.QueryPayCard(UCPager1.PageIndex,
                UCPager1.PageSize,type == -1 ? null : (PayCardCategory?)type,status == -1 ? null : (PayCardStatus?)status,null,null);
            rptData.DataSource = datas.DataList;
            rptData.DataBind();
            UCPager1.RecordCount = datas.TotalCount;
            UCPager1.PageCount = datas.PageCount;
        }

        protected void btnEnabled_ServerClick(object sender,EventArgs e)
        {
            var me = sender as HtmlButton;
            if (me == null) return;
            var sysno = int.Parse(me.Attributes["key"]);
            if (PayCardLogic.EnablePayCard(sysno))
            {
                Alert("启用成功");
                BindData();
            }
            else
            {
                Alert("启用失败");
            }
        }

        protected void btnDisabled_ServerClick(object sender,EventArgs e)
        {
            var me = sender as HtmlButton;
            if (me == null) return;
            var sysno = int.Parse(me.Attributes["key"]);
            if (PayCardLogic.DisablePayCard(sysno))
            {
                Alert("禁用成功");
                BindData();
            }
            else
            {
                Alert("禁用失败");
            }
        }

        protected void btnDelete_serverClick(object sender,EventArgs e)
        {
            var me = sender as HtmlButton;
            if (me == null) return;
            var sysno = int.Parse(me.Attributes["key"]);
            if (PayCardLogic.DeletePayCard(sysno))
            {
                Alert("删除成功");
                BindData();
            }
            else
            {
                Alert("删除失败");
            }
        }

        protected void rptData_DataBound(object sender,RepeaterItemEventArgs e)
        {
            var data = e.Item.DataItem as DataEntity.PayCard;
            if (data == null) return;
            var btn = e.Item.FindControl("btnEnabled") as HtmlButton;
            if (btn != null)
            {
                btn.Attributes["key"] = data.SysNo.ToString();
            }
            btn = e.Item.FindControl("btnDelete") as HtmlButton;
            if (btn != null)
            {
                btn.Attributes["key"] = data.SysNo.ToString();
            }
            btn = e.Item.FindControl("btnDisabled") as HtmlButton;
            if (btn != null)
            {
                btn.Attributes["key"] = data.SysNo.ToString();
            }
        }
    }
}