using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpmate.UI.Forms.Code
{
    public class ConstValue
    {
        public const int WM_QUERYENDSESSION = 0x0011;
    }

    public enum PageForm
    {
        /// <summary>
        /// 本期预测
        /// </summary>
        Forecast,
        /// <summary>
        /// 超级走势
        /// </summary>
        Super,
        /// <summary>
        /// 特殊分析
        /// </summary>
        Special,
        /// <summary>
        /// 遗漏分析
        /// </summary>
        Omission,
        /// <summary>
        /// 近期走势
        /// </summary>
        Recent,
        /// <summary>
        /// 个人中心
        /// </summary>
        Customer,
        /// <summary>
        /// 提醒
        /// </summary>
        Remind
    }
}
