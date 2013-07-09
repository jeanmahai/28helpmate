using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;
using Helpmate.Facades.RequestMsg;

namespace Helpmate.Facades
{
    public class BaseFacade
    {
        public LotteryWebServiceSoapClient ClientService { get; set; }

        public TokenHeader TokenHeader = new TokenHeader()
        {
            GameSourceSysNo = Header.GameSourceSysNo,
            RegionSourceSysNo = Header.RegionSourceSysNo,
            SiteSourceSysNo = Header.SiteSourceSysNo,
            UserSysNo = Header.UserSysNo
        };

        public BaseFacade()
        {
            ClientService = new LotteryWebServiceSoapClient("LotteryWebServiceSoap");
        }
    }
}
