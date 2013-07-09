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
<<<<<<< Updated upstream
        //public void GetCustomeModule(Action<GetCustomeModuleCompletedEventArgs> callback)
        //{
        //    TokenHeader tokenHeader = new TokenHeader();

        //    restClient.ClientService.GetCustomeModuleAsync(tokenHeader, "1001");
        //    restClient.ClientService.GetCustomeModuleCompleted += (obj, args) =>
        //    {
        //        try
        //        {
        //            callback(args);
        //        }
        //        catch (Exception ex)
        //        {
        //            string msg = ex.Message;
        //        }
        //    };
        //}
=======
        public void GetCustomeModule(Action<GetCustomeModule_28BJCompletedEventArgs> callback)
        {
            TokenHeader tokenHeader = new TokenHeader() { SiteSourceSysNo = 10002 };
            ClientService.GetCustomeModule_28BJAsync(tokenHeader, "1001");
            ClientService.GetCustomeModule_28BJCompleted += (obj, args) =>
            {
                callback(args);
            };
        }
>>>>>>> Stashed changes

        internal static string LoadCode()
        {
            throw new NotImplementedException();
        }
    }
}
