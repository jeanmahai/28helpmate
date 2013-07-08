using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;

namespace Helpmate.Facades
{
    public class BaseFacade
    {
        public string Key { get; set; }

        //protected readonly BaseFacade restClient = new BaseFacade();
        public LotteryWebServiceSoapClient ClientService { get; set; }

        public BaseFacade()
        {
            ClientService = new LotteryWebServiceSoapClient("LotteryWebServiceSoap");
        }
    }
}
