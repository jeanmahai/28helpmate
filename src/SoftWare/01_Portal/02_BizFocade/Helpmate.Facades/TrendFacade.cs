using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;
using Common.Utility;

namespace Helpmate.Facades
{
    public class TrendFacade : BaseFacade
    {
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


        public ResultRMOfLotteryTrend QuerySuperTrend(int pageIndex, string date, string hour, string minute)
        {
            try
            {
                lock (Header.obj)
                {
                    var data = ClientService.QuerySupperTrend(TokenHeader, pageIndex, 10, date, hour, minute);
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
