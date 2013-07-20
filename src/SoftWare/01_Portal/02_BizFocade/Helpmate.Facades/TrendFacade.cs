using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Utility;
using System.Net;
using Helpmate.Facades.LotteryWebSvc;

namespace Helpmate.Facades
{
    public class TrendFacade : BaseFacade
    {
        /// <summary>
        /// 从Service获取一般走势数据
        /// </summary>
        /// <param name="pageIndex">取第几页</param>
        /// <returns></returns>
        public ResultRMOfLotteryTrend QueryTrend(int pageIndex)
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.QueryTrend(pageIndex);
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }

        /// <summary>
        /// 从Service获取超级走势数据
        /// </summary>
        /// <param name="pageIndex">取第几页</param>
        /// <param name="date">日期</param>
        /// <param name="hour">小时</param>
        /// <param name="minute">分钟</param>
        /// <returns></returns>
        public ResultRMOfLotteryTrend QuerySuperTrend(int pageIndex, string date, string hour, string minute)
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.QuerySupperTrend(pageIndex, 20, date, hour, minute);
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }

        /// <summary>
        /// 从Service获取特殊分析详情数据
        /// </summary>
        /// <param name="beginHour"></param>
        /// <param name="endHour"></param>
        /// <returns></returns>
        public ResultRMOfLotteryTrend QuerySpecialAnalysisDetail(string date, int beginHour, int endHour)
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.GetSpecialDetail(date, beginHour, endHour);
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }

        /// <summary>
        /// 特殊统计
        /// </summary>
        /// <param name="beginHour"></param>
        /// <param name="endHour"></param>
        /// <returns></returns>
        public ResultRMOfSpecialLottery GetSpecial(int beginHour, int endHour)
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.GetSpecial(beginHour, endHour);
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }
    }
}
