using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.RequestMsg;
using Helpmate.Facades.LotteryWebSvc;
using Common.Utility;
using System.Net;

namespace Helpmate.Facades
{
    public class BaseFacade
    {
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
                    Token = UtilsTool.MD5(string.Format("{0}{1}{2}{3}{4}", Header.Key, Header.UserSysNo, Header.GameSourceSysNo, Header.RegionSourceSysNo, Header.SiteSourceSysNo))
                };
            }
        }

        public BaseFacade()
        { }        
    }

    public class Client
    {
        private static LotteryWebSvc.LotteryWebService _Service = null;
        public static LotteryWebSvc.LotteryWebService Service
        {
            get
            {
                if (_Service == null)
                {
                    _Service = new LotteryWebSvc.LotteryWebService();
                    CookieContainer cc = new CookieContainer();
                    _Service.CookieContainer = cc;
                }
                return _Service;
            }
        }
    }
}
