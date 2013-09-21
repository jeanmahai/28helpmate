using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic;

namespace web.utility
{
    /// <summary>
    /// DoProcess 的摘要说明
    /// </summary>
    public class DoProcess:HttpHandlerBase
    {
        public override void DoRequest(HttpContext ctx)
        {
            switch (QueryStringVal.Action)
            {
                case "login":
                    var message=SystemUserLogic.Login(FormVal.UserId,FormVal.Password,"127.0.0.1");
                    var result = new AjaxResult();
                    if(string.IsNullOrEmpty(message))
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = message;
                    }
                    ctx.Response.Write(result.ToString());
                    break;
            }
        }
    }
}