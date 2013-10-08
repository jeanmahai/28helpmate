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
            string sysNo = Request.QueryString["sysNo"];
            if (!IsPostBack && !string.IsNullOrEmpty(sysNo))
            {
                Notices entity = NoticesLogic.LoadNotices(int.Parse(sysNo));
                txtContents.Text = entity.Contents;
                txtRank.Value = entity.Rank;
                hidSysNo.Value = sysNo;
            }
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

            string sysNo = hidSysNo.Value;
            if (!string.IsNullOrEmpty(sysNo))
            {
                notices.SysNo = int.Parse(sysNo);
                NoticesLogic.UpdateNotices(notices);
            }
            else
            {
                NoticesLogic.CreateNotices(notices);
            }
            Alert("保存成功！");
        }
    }
}