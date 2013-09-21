using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataEntity;
using Framework.Util.Encryption;
using Framework.Util.Database.MSSQL;

namespace DataAccess
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public class SystemUserDA
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginName">登录用户名</param>
        /// <param name="loginPwd">登录密码</param>
        /// <returns></returns>
        public static SystemUser Login(string loginName, string loginPwd)
        {
            SystemUser result = new SystemUser();

            DbCommand cmd = new DbCommand("SystemUsers_Login");
            cmd.SetParameterValue("@LoginName", loginName);
            cmd.SetParameterValue("@LoginPwd", loginPwd);

            return cmd.ExecuteEntity<SystemUser>();
        }
        /// <summary>
        /// 更新登录信息
        /// </summary>
        /// <param name="sysNo">系统编号</param>
        /// <param name="ip">IP</param>
        public static void UpdateLoginInfo(int sysNo, string ip)
        {
            DbCommand cmd = new DbCommand("SystemUsers_UpdateLoginInfo");
            cmd.SetParameterValue("@IP", ip);
            cmd.SetParameterValue("@SysNo", sysNo);
            cmd.ExecuteNonQuery();
        }
    }
}
