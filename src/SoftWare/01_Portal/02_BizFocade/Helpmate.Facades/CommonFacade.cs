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
                return Client.Service.GetCustomeModule();
            }
        }

        public ResultRMOfListOfOmitStatistics QueryOmission()
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                return Client.Service.QueryOmission();
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
                return Client.Service.GetUserInfo();
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
                var result = Client.Service.ChangePsw(oldPwd, newPwd);
                return result;
            }
        }
        /// <summary>
        /// 从Service充值
        /// </summary>
        /// <param name="cardID">卡号</param>
        /// <param name="cardPwd">密码</param>
        /// <returns></returns>
        public ResultRMOfObject Pay(string cardID, string cardPwd)
        {
            lock (Header.obj)
            {
                Client.Service.TokenHeaderValue = TokenHeader;
                var result = Client.Service.ChangePsw(cardID, cardPwd);
                return result;
            }
        }

        /// <summary>
        /// 从Service获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerDate()
        {
            lock (Header.obj)
            {
                var data = Client.Service.GetServerDate();
                return data;
            }
        }
    }
}
