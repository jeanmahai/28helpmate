using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpmate.DataService.Entity;
using Helpmate.DataService.Utility;

namespace Helpmate.DataService.Logic
{
    /// <summary>
    /// 采集北京数据实现类
    /// </summary>
    public class CollectBeijingData : ICollectData
    {
        #region 单例模式

        private CollectBeijingData()
        { }
        private static CollectBeijingData _Instance;
        public static CollectBeijingData Instance()
        {
            if (_Instance == null)
                _Instance = new CollectBeijingData();
            return _Instance;
        }

        #endregion

        #region ICollectData 成员

        /// <summary>
        /// 采集北京数据
        /// </summary>
        /// <param name="periodNum">期号</param>
        /// <returns></returns>
        public CollectResultEntity Collect(long periodNum)
        {
            CollectResultEntity result = new CollectResultEntity();

            string url = string.Empty;
            string resultData = string.Empty;
            int startIndex = 0;
            int endIndex = 0;

            url = GetConfig.GetXMLValue("PeriodNumUrl");
            url = url.Replace("{0}", periodNum.ToString());
            resultData = HttpHelper.GetHttpData(url);
            startIndex = resultData.IndexOf("快乐8开奖号码") + 8;
            endIndex = resultData.IndexOf("奖池");
            resultData = resultData.Substring(startIndex, endIndex - startIndex);
            startIndex = resultData.IndexOf("<ul>") + 4;
            endIndex = resultData.IndexOf("</ul>");
            resultData = resultData.Substring(startIndex, endIndex - startIndex);
            resultData = resultData.Replace("<li>", "");
            resultData = resultData.Replace("</li>", "|");
            string[] sortResultChr = resultData.Split('|');
            resultData = string.Empty;
            for (int i = 0; i < sortResultChr.Length; i++)
            {
                resultData += i == sortResultChr.Length - 1 ? sortResultChr[i].Trim() : sortResultChr[i].Trim() + "|";
            }
            result.Result = resultData;
            result.Group = Array.ConvertAll<string, int>(resultData.Split('|'), delegate(string s) { return int.Parse(s); });

            return result;
        }

        /// <summary>
        /// 采集期号
        /// </summary>
        /// <returns></returns>
        public CollectResultEntity CollectPeriodNum()
        {
            CollectResultEntity result = new CollectResultEntity();

            string str = HttpHelper.GetHttpData(GetConfig.GetXMLValue("GetNewPeriodNumUrl"));
            int startIndex = str.IndexOf("<span class=\"flow_font\">") + 24;
            int endIndex = 0;
            str = str.Substring(startIndex, str.Length - startIndex);
            endIndex = str.IndexOf("</span>");
            str = str.Substring(0, endIndex);
            long periondNum = 0;
            long.TryParse(str, out periondNum);
            result.PeriodNum = periondNum;

            DateTime dtRetTime = DateTime.Now;
            DateTime dtNow = DateTime.Now;
            int hour = dtNow.Hour;

            if (hour >= 0 && hour < 9)
            {
                dtRetTime = DateTime.Parse(string.Format("{0} 23:55:00", dtNow.AddDays(1).ToShortDateString()));
            }
            else
            {
                int minute = dtNow.Minute % 5;
                int second = dtNow.Second;
                dtRetTime = dtNow.AddMinutes(0 - minute).AddSeconds(0 - second);
            }
            result.RetTime = dtRetTime;

            return result;
        }

        #endregion
    }
}
