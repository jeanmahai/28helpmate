using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Utility
{
    public class RequiredLogin:PageBase
    {
        public override void PageLoad()
        {
#if DEBUG
            
#else
            if (string.IsNullOrEmpty(SessionVal.UserId))
            {
                //throw new Exception("你还没有登录");
                Response.Redirect("/Login.aspx");
            }
#endif
        }
    }
}