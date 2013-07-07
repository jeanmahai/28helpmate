using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;

namespace Helpmate.Facades
{
    public class RestClient
    {
        public LotteryWebServiceSoapClient ClientService { get; set; }

        public RestClient()
        {
            ClientService = new LotteryWebServiceSoapClient("LotteryWebServiceSoap");
        }
    }
}
