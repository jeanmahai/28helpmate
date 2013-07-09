using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;
using System.Windows.Forms;
using Common.Utility;
using System.Threading;

namespace Helpmate.Facades
{
    public class CommonFacade : BaseFacade
    {
        public ResultRMOfCustomModules GetCustomeModule()
        {
            try
            {
                lock (Header.obj)
                {
                    TokenHeader.Key = Header.Key;
                    var result = ClientService.GetCustomeModule_28BJ(TokenHeader);
                    Header.Key = result.Key;
                    if (!result.Success) AppMessage.AlertMessage(result.Message);
                    return result;
                }
            }
            catch (Exception ex)
            {
                AppMessage.AlertMessage(400);
            }
            return null;
        }

        internal static string LoadCode()
        {
            throw new NotImplementedException();
        }
    }
}
