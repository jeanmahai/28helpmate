using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpmate.DataService.Utility
{
    public class GetNowTime
    {
        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public DateTime NowTime(ConfigSource source)
        {
            switch (source)
            {
                case ConfigSource.Beijing:
                    return DateTime.Now;
                default:
                    return DateTime.Now;
            }
        }
    }
}
