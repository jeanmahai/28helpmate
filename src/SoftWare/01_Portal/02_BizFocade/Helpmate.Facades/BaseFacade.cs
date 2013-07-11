using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.RequestMsg;
using Helpmate.Facades.LotteryWebSvc;

namespace Helpmate.Facades
{
    public class BaseFacade
    {
        public LotteryWebService ClientService { get; set; }

        public TokenHeader TokenHeader
        {
            get
            {
                return new TokenHeader()
                {
                    GameSourceSysNo = Header.GameSourceSysNo,
                    RegionSourceSysNo = Header.RegionSourceSysNo,
                    SiteSourceSysNo = Header.SiteSourceSysNo,
                    UserSysNo = Header.UserSysNo,
                    Token = ""
                };
            }
        }

        public BaseFacade()
        {
            ClientService = new LotteryWebService();
        }
    }
}
