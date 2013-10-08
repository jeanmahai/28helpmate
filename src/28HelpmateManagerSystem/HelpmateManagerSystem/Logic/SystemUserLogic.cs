using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataEntity;
using DataAccess;
using Common.Utility.Encryption;

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
        /// <returns>返回值为空，则登录成功；否则登录失败，返回值为失败信息。</returns>
        public static string Login(string loginName, string loginPwd, string IP, out SystemUser user)
        {
            string result = "";
            loginPwd = MD5Encrypt.MD5Encrypt32(loginPwd);
            user = SystemUserDA.Login(loginName, loginPwd);
            if (user != null && user.SysNo > 0)
            {
                if (user.Status != SystemUserStatus.Valid)
                {
                    result = "登录失败，帐号无效。";
                }
                else
                {
                    SystemUserDA.UpdateLoginInfo(user.SysNo, IP);
                }
            }
            else
            {
                result = "登录失败，用户名或密码错误。";
            }
            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sysNo">用户编号</param>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <returns>返回值为空，则修改密码成功；否则修改密码失败，返回值为失败信息。</returns>
        public static string ChangePwd(int sysNo, string oldPwd, string newPwd)
        {
            string resultMessage = "";

            oldPwd = MD5Encrypt.MD5Encrypt32(oldPwd);
            newPwd = MD5Encrypt.MD5Encrypt32(newPwd);
            var user = SystemUserDA.GetBySysNo(sysNo);
            if (user != null && user.SysNo > 0)
            {
                if (user.LoginPwd == oldPwd)
                {
                    bool result = SystemUserDA.ChangePwd(sysNo, newPwd);
                    resultMessage = result ? "" : "修改密码失败。";
                }
                else
                {
                    resultMessage = "修改密码失败，旧密码错误。";
                }
            }
            else
            {
                resultMessage = "修改密码失败，用户不存在。";
            }

            return resultMessage;
        }
    }
}
