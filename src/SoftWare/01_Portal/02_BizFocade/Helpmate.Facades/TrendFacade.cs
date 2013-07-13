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
            try
            {
                lock (Header.obj)
                {
                    Client.Service.TokenHeaderValue = TokenHeader;
                    var result = Client.Service.QueryTrend(pageIndex);
                    if (!result.Success && result.Code != ERROR_VALIDATE_TOKEN_CODE) AppMessage.AlertErrMessage(result.Message);
                    else if (result.Success) Header.Key = result.Key;
                    return result;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Write("QueryTrend", ex.ToString());
                AppMessage.AlertErrMessage(400);
            }
            return null;
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
            try
            {
                lock (Header.obj)
                {
                    Client.Service.TokenHeaderValue = TokenHeader;
                    var result = Client.Service.QuerySupperTrend(pageIndex, 20, date, hour, minute);
                    if (!result.Success && result.Code != ERROR_VALIDATE_TOKEN_CODE) AppMessage.AlertErrMessage(result.Message);
                    else if (result.Success) Header.Key = result.Key;
                    return result;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Write("QuerySuperTrend", ex.ToString());
                AppMessage.AlertErrMessage(400);
            }
            return null;
        }
    }
}
