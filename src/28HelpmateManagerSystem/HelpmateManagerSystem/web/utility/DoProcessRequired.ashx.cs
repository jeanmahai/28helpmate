using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                
            }
        }
    }
}