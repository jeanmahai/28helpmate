using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
        }

        void btnSave_ServerClick(object sender,EventArgs e)
        {
            var message = PayCardLogic.CreatePayCard(PayCardCategory.Month, int.Parse(numCount.Value),
                                                     DateTime.Parse(dateFrom.Value), DateTime.Parse(dateTo.Value));
            if(string.IsNullOrEmpty(message))
            {
                Alert("创建成功");
            }
            else
            {
                Alert(message);
            }
        }

        private void BindData()
        {
            var datas = PayCardLogic.QueryPayCard(1, 10, null, null, null, null);

        }
    }
}