using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic;
using DataEntity;

namespace web.utility
{
    /// <summary>
    /// DoProcess 的摘要说明
    /// </summary>
    public class DoProcess:HttpHandlerBase
    {
        public override void DoRequest(HttpContext ctx)
        {
            var action = QueryStringVal.Action;
            if(string.IsNullOrEmpty(action)) action = FormVal.Action;
            switch (action)
            {
                case "login":
                    SystemUser user = new SystemUser();
                    var message=SystemUserLogic.Login(FormVal.UserId,FormVal.Password,"127.0.0.1", out user);
                    var result = new AjaxResult();
                    if(string.IsNullOrEmpty(message))
                    {
                        result.Success = true;
                        SessionVal.UserId = FormVal.UserId;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = message;
                    }
                    ctx.Response.Write(result.ToString());
                    break;
            }
            ctx.Response.End();
        }
    }
}