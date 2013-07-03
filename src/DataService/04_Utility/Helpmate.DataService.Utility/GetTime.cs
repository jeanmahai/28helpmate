using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpmate.DataService.Utility
{
    public class GetTime
    {
        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <param name="source">配置的源类型</param>
        /// <returns></returns>
        public DateTime NowTime(ConfigSource source)
        {
            switch (source)
            {
                case ConfigSource.Beijing:
                    return DateTime.Now;
                case ConfigSource.Canadan:
                    return DateTime.Now;
                default:
                    return DateTime.Now;
            }
        }

        /// <summary>
        /// 北京时间转换为加拿大时间
        /// </summary>
        /// <param name="dt">需要转换的时间</param>
        /// <returns></returns>
        public DateTime ConvertBeijingToCanadan(DateTime dt)
        {
            return dt.AddHours(-15);
        }

        /// <summary>
        /// 加拿大时间转换为北京时间
        /// </summary>
        /// <param name="dt">需要转换的时间</param>
        /// <returns></returns>
        public DateTime ConvertCanadanToBeijing(DateTime dt)
        {
            return dt.AddHours(15);
        }

        /// <summary>
        /// 格式化加拿大采集日期
        /// </summary>
        /// <returns></returns>
        public string FormatCanadanCollectDate()
        {
            string result = "{0}-{1}-{2}";

            DateTime dtNow = ConvertBeijingToCanadan(DateTime.Now);
            int year = dtNow.Year;
            string month = dtNow.Month < 10 ? string.Format("0{0}", dtNow.Month) : dtNow.Month.ToString();
            string day = dtNow.Day < 10 ? string.Format("0{0}", dtNow.Day) : dtNow.Day.ToString();
            result = string.Format(result, year, month, day);

            return result;
        }
    }
}
