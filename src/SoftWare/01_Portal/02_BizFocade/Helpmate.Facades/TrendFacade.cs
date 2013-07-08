using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;

namespace Helpmate.Facades
{
    public class TrendFacade : BaseFacade
    {
        public void QueryTrend(int pageIndex, Action<QueryCompletedEventArgs> callback)
        {
            restClient.ClientService.QueryTrendAsync(DateTime.Now.AddDays(-1), DateTime.Now, 1000, pageIndex);
            EventHandler<QueryCompletedEventArgs> callbackHandler = (obj, args) =>
            {
                callback(args);
            };
            restClient.ClientService.QueryCompleted += callbackHandler;
        }
        public LotteryTrend QueryTrend(int pageIndex)
        {
            LotteryWebServiceSoapClient svc = new LotteryWebServiceSoapClient("LotteryWebServiceSoap");
            var data = svc.QueryTrend(DateTime.Now.AddDays(-1), DateTime.Now, 100, pageIndex);
            return data;
        }
    }
}
