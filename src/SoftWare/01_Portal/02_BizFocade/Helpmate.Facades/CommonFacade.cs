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
            try
            {
                lock (Header.obj)
                {
                    ClientService.TokenHeaderValue = TokenHeader;
                    var result = ClientService.GetCustomeModule();
                    Header.Key = result.Key;
                    if (!result.Success) AppMessage.AlertMessage(result.Message);
                    return result;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Write("GetCustomeModule", ex.ToString());
                AppMessage.AlertMessage(400);
            }
            return null;
        }

        public ResultRMOfListOfOmitStatistics QueryOmission()
        {
            try
            {
                lock (Header.obj)
                {
                    ClientService.TokenHeaderValue = TokenHeader;
                    var result = ClientService.QueryOmission();
                    Header.Key = result.Key;
                    if (!result.Success) AppMessage.AlertMessage(result.Message);
                    return result;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Write("QueryOmission", ex.ToString());
                AppMessage.AlertMessage(400);
            }
            return null;
        }

        internal static string LoadCode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 从Service获取用户信息
        /// </summary>
        /// <returns></returns>
        public ResultRMOfUser GetUserInfo()
        {
            try
            {
                lock (Header.obj)
                {
                    ClientService.TokenHeaderValue = TokenHeader;
                    var data = ClientService.GetUserInfo();
                    Header.Key = data.Key;
                    if (!data.Success) AppMessage.AlertMessage(data.Message);
                    return data;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Write("GetUserInfo", ex.ToString());
                AppMessage.AlertMessage(400);
            }
            return null;
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
            try
            {
                lock (Header.obj)
                {
                    ClientService.TokenHeaderValue = TokenHeader;
                    var data = ClientService.ChangePsw(oldPwd, newPwd);
                    Header.Key = data.Key;
                    //if (!data.Success) AppMessage.AlertMessage(data.Message);
                    return data;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Write("ChangePwd", ex.ToString());
                AppMessage.AlertMessage(400);
            }
            return null;
        }
        /// <summary>
        /// 从Service充值
        /// </summary>
        /// <param name="cardID">卡号</param>
        /// <param name="cardPwd">密码</param>
        /// <returns></returns>
        public ResultRMOfObject Pay(string cardID, string cardPwd)
        {
            try
            {
                lock (Header.obj)
                {
                    ClientService.TokenHeaderValue = TokenHeader;
                    var data = ClientService.ChangePsw(cardID, cardPwd);
                    Header.Key = data.Key;
                    //if (!data.Success) AppMessage.AlertMessage(data.Message);
                    return data;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Write("Pay", ex.ToString());
                AppMessage.AlertMessage(400);
            }
            return null;
        }

        /// <summary>
        /// 从Service获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerDate()
        {
            try
            {
                lock (Header.obj)
                {
                    //ClientService.TokenHeaderValue = TokenHeader;
                    var data = ClientService.GetServerDate();
                    return data;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Write("GetServerDate", ex.ToString());
                AppMessage.AlertMessage(400);
            }
            return DateTime.Now;
        }
    }
}
