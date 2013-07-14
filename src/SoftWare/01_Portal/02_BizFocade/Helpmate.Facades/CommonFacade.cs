using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebSvc;
using System.Windows.Forms;
using Common.Utility;
using System.Threading;

namespace Helpmate.Facades
{
    public class CommonFacade : BaseFacade
    {
        public ResultRMOfCustomModules GetCustomeModule()
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.GetCustomeModule();
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }

        public ResultRMOfListOfOmitStatistics QueryOmission()
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.QueryOmission();
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }

        /// <summary>
        /// 从Service获取用户信息
        /// </summary>
        /// <returns></returns>
        public ResultRMOfUser GetUserInfo()
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.GetUserInfo();
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }

        /// <summary>
        /// 从Service修改密码
        /// </summary>
        /// <param name="question1">密保问题1</param>
        /// <param name="answer1">密码问题1答案</param>
        /// <param name="question2">密保问题2</param>
        /// <param name="answer2">密保问题2答案</param>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <returns></returns>
        public ResultRMOfObject ChangePwd(string question1, string question2, string answer1, string answer2, string oldPwd, string newPwd)
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.ChangePsw(UtilsTool.MD5(oldPwd), UtilsTool.MD5(newPwd), question1, answer1, question2, answer2);
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }
        /// <summary>
        /// 从Service充值
        /// </summary>
        /// <param name="cardID">卡号</param>
        /// <param name="cardPwd">密码</param>
        /// <returns></returns>
        public ResultRMOfBoolean Pay(string cardID, string cardPwd)
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.Recharge(cardID, cardPwd);
                if (result.Success) Header.Key = result.Key;
                return result;
            }
        }

        /// <summary>
        /// 从Service获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerDate()
        {
            var data = Client.Service.GetServerDate();
            return data;
        }

        /// <summary>
        /// 首页获取提醒+当前期 
        /// </summary>
        /// <returns></returns>
        public ResultRMOfInfoForTimer GetInfoForTimer()
        {
            Client.Service.TokenHeaderValue = TokenHeader;
            var data = Client.Service.GetInfoForTimer();
            return data;
        }
    }
}
