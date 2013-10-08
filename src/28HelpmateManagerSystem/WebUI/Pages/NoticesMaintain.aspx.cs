using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUI.Utility;
using Logic;
using DataEntity;

namespace WebUI.Pages
{
    public partial class NoticesMaintain : RequiredLogin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.PageLoad();
            btnSave.ServerClick += new EventHandler(btnSave_ServerClick);
        }

        public void btnSave_ServerClick(object sender, EventArgs e)
        {
            string contents = txtContents.Text;
            string rank = txtRank.Value;

            if (string.IsNullOrEmpty(contents))
            {
                Alert("请输入公告内容！");
                return;
            }

            if (string.IsNullOrEmpty(rank))
            {
                Alert("请输入优先级！");
                return;
            }

            Notices notices = new Notices()
            {
                Contents = contents,
                Rank = rank,
                Status = NoticesStatus.Init
            };

            NoticesLogic.CreateNotices(notices);
            Alert("保存成功！");
        }
    }
}