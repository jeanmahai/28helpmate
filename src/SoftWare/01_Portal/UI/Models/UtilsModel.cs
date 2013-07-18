using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Helpmate.UI.Forms.Properties;
using Helpmate.Facades;
using Common.Utility;

namespace Helpmate.UI.Forms.Code
{
    public class UtilsModel
    {
        /// <summary>
        /// 根据RetNum获取Num图片
        /// </summary>
        /// <param name="retNum">彩票球数</param>
        /// <returns>Num对应图片</returns>
        public static Image LoadNumImage(int retNum)
        {
            switch (retNum)
            {
                case 0:
                    return Resources.number_0x;
                case 1:
                    return Resources.number_1x;
                case 2:
                    return Resources.number_2x;
                case 3:
                    return Resources.number_3x;
                case 4:
                    return Resources.number_4x;
                case 5:
                    return Resources.number_5x;
                case 6:
                    return Resources.number_6x;
                case 7:
                    return Resources.number_7x;
                case 8:
                    return Resources.number_8x;
                case 9:
                    return Resources.number_9x;
                case 10:
                    return Resources.number_10x;
                case 11:
                    return Resources.number_11x;
                case 12:
                    return Resources.number_12x;
                case 13:
                    return Resources.number_13x;
                case 14:
                    return Resources.number_14x;
                case 15:
                    return Resources.number_15x;
                case 16:
                    return Resources.number_16x;
                case 17:
                    return Resources.number_17x;
                case 18:
                    return Resources.number_18x;
                case 19:
                    return Resources.number_19x;
                case 20:
                    return Resources.number_20x;
                case 21:
                    return Resources.number_21x;
                case 22:
                    return Resources.number_22x;
                case 23:
                    return Resources.number_23x;
                case 24:
                    return Resources.number_24x;
                case 25:
                    return Resources.number_25x;
                case 26:
                    return Resources.number_26x;
                case 27:
                    return Resources.number_27x;
            }
            return Resources.number_0x;
        }
        /// <summary>
        /// 获取总导航
        /// </summary>
        /// <returns></returns>
        public static string GetTotalNav()
        {
            string result = UtilsTool.GetSourceName(Header.RegionSourceSysNo) + "28";
            result += string.Format("—{0}", UtilsTool.GetSiteName(Header.SiteSourceSysNo));
            return result;
        }
    }
}
