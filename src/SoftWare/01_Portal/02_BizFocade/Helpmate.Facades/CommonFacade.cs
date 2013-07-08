using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;
using System.Windows.Forms;

namespace Helpmate.Facades
{
    public class CommonFacade : BaseFacade
    {
        public void GetCustomeModule(Action<GetCustomeModuleCompletedEventArgs> callback)
        {
            TokenHeader tokenHeader = new TokenHeader();

            restClient.ClientService.GetCustomeModuleAsync(tokenHeader, "1001");
            restClient.ClientService.GetCustomeModuleCompleted += (obj, args) =>
            {
                try
                {
                    callback(args);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            };
        }


        internal static string LoadCode()
        {
            throw new NotImplementedException();
        }
    }
}
