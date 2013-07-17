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
        public ResultRMOfPageListOfRemindStatistics GetRemindLottery(int pageIndex)
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.QueryRemind(pageIndex, 18);
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }
        /// <summary>
        /// 保存提醒设置
        /// </summary>
        /// <param name="remind"></param>
        /// <returns></returns>
        public ResultRMOfBoolean AddRemindLottery(RemindStatistics remind)
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                remind.UserSysNo = TokenHeader.UserSysNo;
                var result = Client.Service.SaveRemind(remind);
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }
        /// <summary>
        /// 删除提醒设置
        /// </summary>
        /// <param name="remindSysNo"></param>
        /// <returns></returns>
        public ResultRMOfBoolean DelRemindLottery(int remindSysNo)
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.DelRemind(remindSysNo);
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }

        /// <summary>
        /// 获取公告
        /// </summary>
        /// <returns></returns>
        public ResultRMOfListOfNotices GetNotice()
        {
            Client.Service.TokenHeaderValue = TokenHeader;
            var result = Client.Service.GetNotice(0);
            return result;
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="userId">用户账号</param>
        /// <param name="q1">问题1</param>
        /// <param name="a1">答案1</param>
        /// <param name="q2">问题2</param>
        /// <param name="a2">答案2</param>
        /// <returns></returns>
        public ResultRMOfString GetPwd(string userId, string q1, string a1, string q2, string a2)
        {
            var result = Client.Service.ResetPsw(userId, q1, a1, q2, a2);
            return result;
        }
    }
}
