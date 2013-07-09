using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;

namespace Helpmate.Facades
{
    public class TrendFacade// : BaseFacade
    {
        public ResultRMOfLotteryTrend QueryTrend(int pageIndex)
        {
            TokenHeader header = new TokenHeader();
            header.GameSourceSysNo = 10001;
            header.RegionSourceSysNo = 10001;
            header.SiteSourceSysNo = 10001;
            header.UserSysNo = 0;
            lock (Header.obj)
            {
                header.Key = Header.Key;
                LotteryWebServiceSoapClient svc = new LotteryWebServiceSoapClient("LotteryWebServiceSoap");
                var data = svc.QueryTrend(header, pageIndex);
                Header.Key = data.Key;
                return data;
            }
        }
        public ResultRMOfLotteryTrend QuerySuperTrend(int pageIndex)
        {
<<<<<<< Updated upstream
            TokenHeader header = new TokenHeader();
            header.GameSourceSysNo = 10001;
            header.RegionSourceSysNo = 10001;
            header.SiteSourceSysNo = 10001;
            header.UserSysNo = 0;
            lock (Header.obj)
            {
                header.Key = Header.Key;
                LotteryWebServiceSoapClient svc = new LotteryWebServiceSoapClient("LotteryWebServiceSoap");
                var data = svc.QueryTrend(header, pageIndex);
                Header.Key = data.Key;
                return data;
            }
=======
            LotteryWebServiceSoapClient svc = new LotteryWebServiceSoapClient("LotteryWebServiceSoap");
            var data = svc.QueryTrend(DateTime.Now.AddDays(-1), DateTime.Now, 100, pageIndex);
            return data;
            return null;
>>>>>>> Stashed changes
        }
    }
}
