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

        public void QuerySuperPerson(Action<QueryCompletedEventArgs> callback)
        {
            TokenHeader tokenHeader = new TokenHeader();
            LotteryFilterForBJ filterForBj = new LotteryFilterForBJ();

            restClient.ClientService.QueryAsync(tokenHeader, filterForBj);
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
