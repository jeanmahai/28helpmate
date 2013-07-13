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
                var result = ClientService.Login(userName, UtilsTool.MD5(userPwd), code);
                Header.Key = result.Key;
                return result;
            }
        }


        public ResultRMOfString UserRegister(User user)
        {
            lock (Header.obj)
            {
                user.UserPwd = UtilsTool.MD5(user.UserPwd);
                var result = ClientService.Register(user);
                return result;
            }
        }

        public string LoadCode()
        {
            lock (Header.obj)
            {
                var result = ClientService.GenerateCode();
                return result;
            }
        }
    }
}
