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
            user.UserPwd = UtilsTool.MD5(user.UserPwd);
            var result = Client.Service.Register(user);
            return result;
        }

        public string LoadCode()
        {
            var result = Client.Service.GenerateCode();
            return result;
        }

        /// <summary>
        /// 从Service获取提醒设置
        /// </summary>
        /// <returns></returns>
        public ResultRMOfRemindStatistics GetRemindLottery()
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.QueryRemindLottery();
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }
        public ResultRMOfBoolean AddRemindLottery(RemindStatistics remind)
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.SaveRemind(remind);
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }
        //public ResultRMOfBoolean DelRemindLottery()
        //{
        //    lock (Header.obj)
        //    {
        //        Client.Service.TokenHeaderValue = TokenHeader;
        //        var result = Client.Service
        //        if (result.Success) Header.Key = result.Key;
        //        return result;
        //    }
        //}
    }
}
