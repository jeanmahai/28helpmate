using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUI.Utility;
using System.Web.UI.HtmlControls;
using Logic;
using DataEntity.QueryFilter;
using DataEntity;

namespace WebUI.Pages
{
    public partial class NoticesQuery : RequiredLogin
    {
        public NoticesQueryFilter QueryFilter { get; set; }

        public override void PageLoad()
        {
            base.PageLoad();
            ucPager.PageSize = 10;
            QueryFilter = new NoticesQueryFilter();

            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void rptData_DataBound(object sender, RepeaterItemEventArgs e)
        {
            var data = e.Item.DataItem as DataEntity.Notices;
            if (data == null) return;
            var btn = e.Item.FindControl("btnEnabled") as HtmlButton;
            if (btn != null)
            {
                btn.Attributes["key"] = data.SysNo.ToString();
                if (data.Status == NoticesStatus.Valid) btn.Visible = false;
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
                if (data.Status == NoticesStatus.Invalid) btn.Visible = false;
            }
        }

        protected void btnEnabled_ServerClick(object sender, EventArgs e)
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

        private void BindData()
        {
            QueryFilter.PageSize = ucPager.PageSize;
            QueryFilter.PageIndex = ucPager.PageIndex;

            var result = NoticesLogic.QueryNotices(QueryFilter);
            rptData.DataSource = result.ResultList;
            rptData.DataBind();

            ucPager.RecordCount = result.PagingInfo.TotalCount;
            ucPager.PageCount = result.PagingInfo.PageCount;
        }
    }
}