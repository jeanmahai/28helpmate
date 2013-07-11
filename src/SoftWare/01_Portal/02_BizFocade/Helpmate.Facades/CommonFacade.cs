using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebSvc;
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
                    ClientService.TokenHeaderValue = TokenHeader;
                    var result = ClientService.GetCustomeModule();
                    Header.Key = result.Key;
                    if (!result.Success) AppMessage.AlertMessage(result.Message);
                    return result;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Write("GetCustomeModule", ex.ToString());
                AppMessage.AlertMessage(400);
            }
            return null;
        }

        public ResultRMOfListOfOmitStatistics QueryOmission()
        {
            try
            {
                lock (Header.obj)
                {
                    ClientService.TokenHeaderValue = TokenHeader;
                    var result = ClientService.QueryOmission();
                    Header.Key = result.Key;
                    if (!result.Success) AppMessage.AlertMessage(result.Message);
                    return result;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Write("QueryOmission", ex.ToString());
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
