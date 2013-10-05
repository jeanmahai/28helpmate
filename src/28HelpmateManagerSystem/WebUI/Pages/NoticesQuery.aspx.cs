using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUI.Utility;

namespace WebUI.Pages
{
    public partial class NoticesQuery : RequiredLogin
    {
        public override void PageLoad()
        {
            base.PageLoad();

            UCPager1.PageSize = 10;

            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void rptData_DataBound(object sender, RepeaterItemEventArgs e)
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

        protected void btnDelete_serverClick(object sender, EventArgs e)
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

        protected void btnDisabled_ServerClick(object sender, EventArgs e)
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
    }
}