using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataEntity;
using DataAccess;
using Framework.Util.Encryption;

namespace Logic
{
    public class SystemUserLogic
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginName">登录用户名</param>
        /// <param name="loginPwd">登录密码</param>
        /// <param name="IP">登录IP</param>
        /// <returns></returns>
        public static string Login(string loginName, string loginPwd, string IP)
        {
            string result = "";
            loginPwd = MD5Encrypt.MD5Encrypt32(loginPwd);
            var data = SystemUserDA.Login(loginName, loginPwd);
            if (data != null && data.SysNo > 0)
            {
                if (data.Status != SystemUserStatus.Valid)
                {
                    result = "登录失败，帐号无效。";
                }
                else
                {
                    SystemUserDA.UpdateLoginInfo(data.SysNo, IP);
                }
            }
            else
            {
                result = "登录失败，用户名或密码错误。";
            }
            return result;
        }
    }
}
