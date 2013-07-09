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
<<<<<<< Updated upstream
        public string Key { get; set; }

        //protected readonly BaseFacade restClient = new BaseFacade();
=======
>>>>>>> Stashed changes
        public LotteryWebServiceSoapClient ClientService { get; set; }

        public BaseFacade()
        {
            ClientService = new LotteryWebServiceSoapClient("LotteryWebServiceSoap");
        }
    }
}
