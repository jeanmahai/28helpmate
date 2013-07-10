﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;
using Common.Utility;

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
                    var data = ClientService.QueryTrend(TokenHeader, pageIndex);
                    Header.Key = data.Key;
                    if (!data.Success) AppMessage.AlertMessage(data.Message);
                    return data;
                }
            }
            catch (Exception ex)
            {
                AppMessage.AlertMessage(400);
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
                    var data = ClientService.QuerySupperTrend(TokenHeader, pageIndex, 20, date, hour, minute);
                    Header.Key = data.Key;
                    if (!data.Success) AppMessage.AlertMessage(data.Message);
                    return data;
                }
            }
            catch (Exception ex)
            {
                AppMessage.AlertMessage(400);
            }
            return null;
        }
    }
}
