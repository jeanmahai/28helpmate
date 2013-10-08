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
        public DateTime? From
        {
            get
            {
                DateTime date;
                if (DateTime.TryParse(Request.QueryString["from"],out date)) return date;
                return null;
            }
        }
        public DateTime? To
        {
            get
            {
                DateTime date;
                if (DateTime.TryParse(Request.QueryString["to"],out date)) return date;
                return null;
            }
        }
        public int CardType
        {
            get
            {
                int cardType;
                if (int.TryParse(Request.QueryString["type"],out cardType)) return cardType;
                return -1;
            }
        }
        public int CardStatus
        {
            get
            {
                int cardType;
                if (int.TryParse(Request.QueryString["status"],out cardType)) return cardType;
                return -1;
            }
        }

        public override void PageLoad()
        {
            base.PageLoad();
            btnSave.ServerClick += new EventHandler(btnSave_ServerClick);

            UCPager1.PageSize = 10;

            if (!IsPostBack)
            {
                BindData();
            }
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

            var datas = PayCardLogic.QueryPayCard(UCPager1.PageIndex,
                UCPager1.PageSize,CardType == -1 ? null : (PayCardCategory?)CardType,CardStatus == -1 ? null : (PayCardStatus?)CardStatus,From,To);
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
                if (data.Status == PayCardStatus.Valid) btn.Visible = false;
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
                if (data.Status == PayCardStatus.Invalid) btn.Visible = false;
            }
        }
    }
}