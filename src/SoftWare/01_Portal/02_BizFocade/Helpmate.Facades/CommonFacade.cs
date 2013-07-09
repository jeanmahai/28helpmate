using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;
using System.Windows.Forms;
using Common.Utility;

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
                    TokenHeader.SiteSourceSysNo = 1001;
                    var result = ClientService.GetCustomeModule_28BJ(TokenHeader);
                    if (!result.Success)
                    {
                        AppMessage.AlertMessage(400);
                    }
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
