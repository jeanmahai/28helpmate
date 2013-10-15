using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using WebUI.Utility;

namespace WebUI.Pages
{
    public partial class PayLog:RequiredLogin
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
        public override void PageLoad()
        {
            base.PageLoad();
            UCPager1.PageSize = 10;
            BindData();
        }

        private void BindData()
        {
            var f = From == null ? DateTime.Now.AddMonths(-1) : From.Value;
            var t = To == null ? DateTime.Now : To.Value;
            var data = PayLogLogic.GetPayLogByBatch(QueryStringVal.PageIndex, UCPager1.PageSize, f, t);
            UCPager1.RecordCount = data.TotalCount;
            UCPager1.PageCount = data.PageCount;
            rptDataList.DataSource = data.DataList;
            rptDataList.DataBind();

        }
    }
}