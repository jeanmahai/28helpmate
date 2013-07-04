﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using CsQuery;
using Helpmate.DataService.Entity;
using Helpmate.DataService.Utility;

namespace Helpmate.DataService.Logic
{
    /// <summary>
    /// 采集北京数据实现类
    /// </summary>
    public class CollectBeijingData
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

        #region 采集北京数据

        /// <summary>
        /// 采集北京数据
        /// </summary>
        /// <param name="periodNum">期号</param>
        /// <returns></returns>
        public CollectResultEntity Collect(long periodNum)
        {
            CollectResultEntity result = new CollectResultEntity();
            string urlType = GetConfig.GetXMLValue(ConfigSource.Beijing, "UrlType");
            switch (urlType)
            {
                //使用地址1
                case "1":
                    result = CollectBeijingData.Instance().CollectUrl1(periodNum);
                    break;
                //使用地址2
                case "2":
                    result = CollectBeijingData.Instance().CollectUrl2(periodNum);
                    break;
                //两个地址都使用，先使用地址1，地址1失败使用地址2
                case "3":
                    result = CollectBeijingData.Instance().CollectUrl1(periodNum);
                    if (result == null || result.Group == null || result.Group.Length != 20)
                        result = CollectBeijingData.Instance().CollectUrl2(periodNum);
                    break;
                default:
                    result = new CollectResultEntity();
                    break;
            }
            return result;
        }
        /// <summary>
        /// 采集北京地址1数据
        /// </summary>
        /// <param name="periodNum">期号</param>
        /// <returns></returns>
        private CollectResultEntity CollectUrl1(long periodNum)
        {
            CollectResultEntity result = new CollectResultEntity();

            int tryTimes = 3;
            while (tryTimes > 0)
            {
                try
                {
                    string url = string.Empty;
                    string resultData = string.Empty;

                    url = GetConfig.GetXMLValue(ConfigSource.Beijing, "PeriodNumUrl");
                    url = string.Format(url, periodNum);
                    resultData = HttpHelper.GetHttpDataUTF8(url);
                    if (string.IsNullOrEmpty(resultData))
                    {
                        tryTimes--;
                        Thread.Sleep(5000);
                        continue;
                    }
                    CQ cq = resultData;

                    CQ val = cq["li"];
                    resultData = "";
                    for (int i = 0; i < val.Length; i++)
                    {
                        if (i == val.Length - 1)
                            resultData += val[i].TextContent.Trim();
                        else
                            resultData += string.Format("{0}|", val[i].TextContent.Trim());
                    }
                    result.Result = resultData;
                    result.Group = Array.ConvertAll<string, int>(resultData.Split('|'), delegate(string s) { return int.Parse(s); });
                    tryTimes = 0;
                }
                catch (Exception ex)
                {
                    WriteLog.Write(ex.ToString());
                    tryTimes--;
                    Thread.Sleep(5000);
                }
            }

            return result;
        }
        /// <summary>
        /// 采集北京地址2数据
        /// </summary>
        /// <param name="periodNum">期号</param>
        /// <returns></returns>
        private CollectResultEntity CollectUrl2(long periodNum)
        {
            CollectResultEntity result = new CollectResultEntity();

            int tryTimes = 3;
            while (tryTimes > 0)
            {
                try
                {
                    string url = string.Empty;
                    string resultData = string.Empty;

                    url = GetConfig.GetXMLValue(ConfigSource.Beijing, "PeriodNumUrl2");
                    url = string.Format(url, periodNum);
                    resultData = HttpHelper.GetHttpDataUTF8(url);
                    if (string.IsNullOrEmpty(resultData))
                    {
                        tryTimes--;
                        Thread.Sleep(5000);
                        continue;
                    }
                    CQ cq = resultData;
                    resultData = cq["div #gameListItem-2"].Find("tr.dataBack1:eq(0)>td:eq(1)").Text().Trim();
                    resultData = resultData.Replace(',', '|');
                    result.Result = resultData;
                    result.Group = Array.ConvertAll<string, int>(resultData.Split('|'), delegate(string s) { return int.Parse(s); });
                    tryTimes = 0;
                }
                catch (Exception ex)
                {
                    WriteLog.Write(ex.ToString());
                    tryTimes--;
                    Thread.Sleep(5000);
                }
            }

            return result;
        }

        #endregion

        #region 采集期号

        /// <summary>
        /// 采集期号
        /// </summary>
        /// <returns></returns>
        public CollectResultEntity CollectPeriodNum()
        {
            CollectResultEntity result = new CollectResultEntity();
            string urlType = GetConfig.GetXMLValue(ConfigSource.Beijing, "UrlType");
            switch (urlType)
            {
                case "1":
                    result = CollectBeijingData.Instance().CollectPeriodNum1();
                    break;
                case "2":
                    result = CollectBeijingData.Instance().CollectPeriodNum2();
                    break;
                case "3":
                    result = CollectBeijingData.Instance().CollectPeriodNum1();
                    if(result == null || result.PeriodNum <= 0)
                        result = CollectBeijingData.Instance().CollectPeriodNum2();
                    break;
                default:
                    result.PeriodNum = 0;
                    break;
            }
            return result;
        }
        /// <summary>
        /// 采集地址1期号
        /// </summary>
        /// <returns></returns>
        public CollectResultEntity CollectPeriodNum1()
        {
            CollectResultEntity result = new CollectResultEntity();

            int tryTimes = 3;
            while (tryTimes > 0)
            {
                try
                {
                    string resultData = HttpHelper.GetHttpData(GetConfig.GetXMLValue(ConfigSource.Beijing, "GetNewPeriodNumUrl"));
                    if (string.IsNullOrEmpty(resultData))
                    {
                        tryTimes--;
                        Thread.Sleep(10000);
                        continue;
                    }
                    CQ cq = resultData;
                    resultData = cq["span:first"].Text().Trim();
                    long periondNum = 0;
                    long.TryParse(resultData, out periondNum);
                    if (periondNum <= 0)
                    {
                        tryTimes--;
                        Thread.Sleep(10000);
                        continue;
                    }
                    //期号
                    result.PeriodNum = periondNum;
                    //时间
                    DateTime dtRetTime = (new GetTime()).NowTime(ConfigSource.Beijing);
                    DateTime dtNow = (new GetTime()).NowTime(ConfigSource.Beijing);
                    int hour = dtNow.Hour;

                    if (hour >= 0 && hour < 9)
                    {
                        dtRetTime = DateTime.Parse(string.Format("{0} 23:55:00", dtNow.ToShortDateString()));
                    }
                    else
                    {
                        int minute = dtNow.Minute % 5;
                        int second = dtNow.Second;
                        dtRetTime = dtNow.AddMinutes(0 - minute).AddSeconds(0 - second);
                    }
                    result.RetTime = dtRetTime;
                    tryTimes = 0;
                }
                catch (Exception ex)
                {
                    result.PeriodNum = 0;
                    WriteLog.Write(ex.ToString());
                    tryTimes--;
                    Thread.Sleep(10000);
                }
            }

            return result;
        }
        /// <summary>
        /// 采集地址2期号
        /// </summary>
        /// <returns></returns>
        private CollectResultEntity CollectPeriodNum2()
        {
            CollectResultEntity result = new CollectResultEntity();

            int tryTimes = 10;
            while (tryTimes > 0)
            {
                try
                {
                    string url = string.Empty;
                    string resultData = string.Empty;

                    url = GetConfig.GetXMLValue(ConfigSource.Beijing, "GetNewPeriodNumUrl2");
                    resultData = HttpHelper.GetHttpDataUTF8(url);
                    if (string.IsNullOrEmpty(resultData))
                    {
                        tryTimes--;
                        Thread.Sleep(10000);
                        continue;
                    }

                    CQ cq = resultData;
                    resultData = cq["div #gameListItem-2"].Find("tr.dataBack1:eq(0)>td:eq(0)").Text().Trim();
                    long periondNum = 0;
                    long.TryParse(resultData, out periondNum);
                    if (periondNum <= 0)
                    {
                        tryTimes--;
                        Thread.Sleep(10000);
                        continue;
                    }
                    //期号
                    result.PeriodNum = periondNum;
                    //时间
                    DateTime dtRetTime = (new GetTime()).NowTime(ConfigSource.Beijing);
                    DateTime dtNow = (new GetTime()).NowTime(ConfigSource.Beijing);
                    int hour = dtNow.Hour;

                    if (hour >= 0 && hour < 9)
                    {
                        dtRetTime = DateTime.Parse(string.Format("{0} 23:55:00", dtNow.ToShortDateString()));
                    }
                    else
                    {
                        int minute = dtNow.Minute % 5;
                        int second = dtNow.Second;
                        dtRetTime = dtNow.AddMinutes(0 - minute).AddSeconds(0 - second);
                    }
                    result.RetTime = dtRetTime;
                    tryTimes = 0;
                }
                catch (Exception ex)
                {
                    result.PeriodNum = 0;
                    WriteLog.Write(ex.ToString());
                    tryTimes--;
                    Thread.Sleep(10000);
                }
            }

            return result;
        }

        #endregion
    }
}
