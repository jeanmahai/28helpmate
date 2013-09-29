using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.UserControls
{
    public partial class UCPager:System.Web.UI.UserControl
    {
        public int RecordCount { get; set; }
        public int PageIndex
        {
            get
            {
                int pageIndex;
                if (int.TryParse(Request.QueryString["PageIndex"],out pageIndex))
                {
                    return pageIndex;
                }
                else
                {
                    return 1;
                }
            }
        }
        public int PageSize { get; set; }
        public int PageCount { get; set; }

        private string PageUrl{get { return Request.Url.AbsolutePath+"?PageIndex={0}"; }}

        public string FirstPage { get { return string.Format(PageUrl, "1"); } }
        public string LastPage { get { return string.Format(PageUrl,PageCount.ToString()); } }
        public string PrevPage { get { return string.Format(PageUrl,PageIndex<=1?"1":(PageIndex-1).ToString()); } }
        public string NextPage { get { return string.Format(PageUrl,PageIndex == PageCount ? PageCount.ToString() : (PageIndex + 1).ToString()); } }

        protected void Page_Load(object sender,EventArgs e)
        {

        }
    }
}