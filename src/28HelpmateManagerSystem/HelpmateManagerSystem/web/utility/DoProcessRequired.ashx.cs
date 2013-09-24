using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic;

namespace web.utility
{
    /// <summary>
    /// DoProcessRequired 的摘要说明
    /// </summary>
    public class DoProcessRequired:HttpHandlerBase
    {
        public override void DoRequest(HttpContext ctx)
        {
            if (string.IsNullOrEmpty(SessionVal.UserId))
            {
                ctx.Response.Write(new AjaxResult
                                   {
                                       Success = false,
                                       Message = "你还没有登录"
                                   }.ToString());
                ctx.Response.End();
            }


             var action = QueryStringVal.Action;
            if (string.IsNullOrEmpty(action)) action = FormVal.Action;
            switch (action)
            {
                case "ChangePassword":
                    var message=SystemUserLogic.ChangePwd(100000,FormVal.OldPsw,FormVal.NewPsw);
                    var result = new AjaxResult();
                    if(string.IsNullOrEmpty(message))
                    {
                        result.Success = true;
                        result.Message = "密码修改成功";
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