using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Utility;
using Helpmate.BizEntity.Enum;
using Helpmate.Facades;

namespace Helpmate.UI.Forms.Code
{
    public class PageUtils
    {
        public static bool CheckError(dynamic result)
        {
            if (!result.Success)
            {
                if (result.Code == ConsoleConst.ERROR_VALIDATE_TOKEN_CODE)
                {
                    AppMessage.AlertErrMessage(ConsoleConst.ERROR_VALIDATE_TOKEN_MSG);
                }
                else
                {
                    AppMessage.AlertErrMessage(result.Message);
                }
                return false;
            }
            return true;
        }
    }
}
