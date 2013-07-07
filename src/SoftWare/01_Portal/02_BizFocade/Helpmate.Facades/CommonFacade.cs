using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;
using System.Windows.Forms;

namespace Helpmate.Facades
{
    public class CommonFacade
    {
        private readonly RestClient restClient = new RestClient();

        public void GetCustomeModule(Action<QueryCompletedEventArgs> callback)
        {
            TokenHeader tokenHeader = new TokenHeader();

            restClient.ClientService.GetCustomeModuleAsync(tokenHeader, "1001");
            EventHandler<QueryCompletedEventArgs> callbackHandler = (obj, args) =>
            {
                callback(args);
            };
            restClient.ClientService.QueryCompleted += callbackHandler;
        }


        internal static string LoadCode()
        {
            throw new NotImplementedException();
        }
    }
}
