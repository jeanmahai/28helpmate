using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Utility;
using Helpmate.Facades.LotteryWebSvc;

namespace Helpmate.Facades
{
    public class CustomerFacade : BaseFacade
    {
        public ResultRMOfString UserLogin(string userName, string userPwd, string code)
        {
            lock (Header.obj)
            {
                var result = Client.Service.Login(userName, UtilsTool.MD5(userPwd), code);
                Header.UserSysNo = int.Parse(string.IsNullOrEmpty(result.Data) ? "0" : result.Data);
                Header.Key = result.Key;
                return result;
            }
        }

        public ResultRMOfString UserRegister(User user)
        {
            lock (Header.obj)
            {
                user.UserPwd = UtilsTool.MD5(user.UserPwd);
                var result = Client.Service.Register(user);
                return result;
            }
        }

        public string LoadCode()
        {
            lock (Header.obj)
            {
                var result = Client.Service.GenerateCode();
                return result;
            }
        }
    }
}
