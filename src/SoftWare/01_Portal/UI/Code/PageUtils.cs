using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Utility;
using Helpmate.BizEntity.Enum;
using Helpmate.Facades;
using System.Windows.Forms;

namespace Helpmate.UI.Forms.Code
{
    public class PageUtils
    {
        public static bool CheckError(dynamic result)
        {
            if (!result.Success)
            {
                if (result.Code == ConsoleConst.ERROR_VALIDATE_TOKEN_CODE)
                {
                    AppMessage.AlertErrMessage(ConsoleConst.ERROR_VALIDATE_TOKEN_MSG);
                    var openForm = Application.OpenForms[0];
                    openForm.Hide();
                    var login = new LoginForm();
                    var diaLog = login.ShowDialog();
                    if (diaLog == DialogResult.OK)
                    {
                        openForm.Show();
                    }
                    else
                    {
                        openForm.Close();
                    }
                }
                else
                {
                    AppMessage.AlertErrMessage(result.Message);
                }
                return false;
            }
            return true;
        }


        /// <summary>
        /// 加载区域名称
        /// </summary>
        /// <returns></returns>
        public static string LoadGameName()
        {
            string game = string.Empty;
            switch (Header.RegionSourceSysNo)
            {
                case 10001:
                    game = "北京";
                    break;
                case 10002:
                    game = "加拿大";
                    break;
            }
            return game;
        }

        /// <summary>
        /// 加载网站名称
        /// </summary>
        /// <returns></returns>
        public static string LoadSiteName()
        {
            string site = string.Empty;
            switch (Header.SiteSourceSysNo)
            {
                case 10001:
                    site = "53游";
                    break;
                case 10002:
                    site = "71豆";
                    break;
                case 10003:
                    site = "芝麻西西";
                    break;
            }
            return site;
        }
    }
}
