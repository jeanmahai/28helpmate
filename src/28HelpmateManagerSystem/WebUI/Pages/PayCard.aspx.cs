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
            if(!IsPostBack)
            {
                BindData();
            }
        }

        void btnSave_ServerClick(object sender,EventArgs e)
        {
            var message = PayCardLogic.CreatePayCard(PayCardCategory.Month, int.Parse(numCount.Value),
                                                     DateTime.Parse(dateFrom.Value), DateTime.Parse(dateTo.Value));
            if(string.IsNullOrEmpty(message))
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
            var datas = PayCardLogic.QueryPayCard(1, 10, null, null, null, null);
            rptData.DataSource = datas.DataList;
            rptData.DataBind();
        }

        protected void btnEnabled_ServerClick(object sender, EventArgs e)
        {
            var me = sender as HtmlButton;
            if (me == null) return;
            var sysno = int.Parse(me.Attributes["title"]);
            if(PayCardLogic.EnablePayCard(sysno))
            {
                Alert("启用成功");
            }
            else
            {
                Alert("启用失败");
            }
        }

        protected void btnDisabled_ServerClick(object sender, EventArgs e)
        {
            
        }

        protected void btnDelete_serverClick(object sender, EventArgs e)
        {
            
        }
    }
}