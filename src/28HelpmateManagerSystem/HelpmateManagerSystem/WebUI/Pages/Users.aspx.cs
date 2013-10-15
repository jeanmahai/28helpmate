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
    public partial class Users : RequiredLogin
    {
        public int? UserState
        {
            get
            {
                int state;
                if (int.TryParse(Request["state"], out state)) return state;
                return null;
            }
        }
        public string UserId { get { return Request["id"]; } }
        public DateTime? From
        {

            get
            {
                DateTime date;
                if (DateTime.TryParse(Request["from"], out date))
                    return date;
                return null;
            }
        }
        public DateTime? To
        {
            get
            {
                DateTime date;
                if (DateTime.TryParse(Request["to"], out date))
                    return date;
                return null;
            }
        }
        public int SysNo
        {
            get { return int.Parse(Request["SysNo"]); }
        }

        public override void PageLoad()
        {
            base.PageLoad();
            if (QueryStringVal.Action == "disabled")
            {
                if (UserLogic.DisableUser(SysNo))
                {
                    Response.End();
                }
                Response.Write("禁用用户失败");
                Response.End();
            }
            if (QueryStringVal.Action == "enabled")
            {
                if (UserLogic.EnableUser(SysNo))
                {
                    Response.End();
                }
                Response.Write("启用用户成功");
                Response.End();
            }
            if (QueryStringVal.Action == "delete")
            {
                if (UserLogic.DeleteUser(SysNo))
                {
                    Response.End();
                }
                Response.Write("删除用户失败");
                Response.End();
            }

            UCPager1.PageSize = 10;
            BindData();
        }

        private void BindData()
        {
            var data = UserLogic.QueryUser(QueryStringVal.PageIndex, UCPager1.PageSize, UserId, UserState, From, To);
            if (data == null) return;
            UCPager1.PageCount = data.PageCount;
            UCPager1.RecordCount = data.TotalCount;
            rptData.DataSource = data.DataList;
            rptData.DataBind();
        }
    }
}