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

        /// <summary>
        /// 根据编号获取用户
        /// </summary>
        /// <param name="sysNo">用户编号</param>
        /// <returns></returns>
        public static SystemUser GetBySysNo(int sysNo)
        {
            DbCommand cmd = new DbCommand("SystemUsers_GetBySysNo");
            cmd.SetParameterValue("@SysNo", sysNo);

            return cmd.ExecuteEntity<SystemUser>();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sysNo">用户编号</param>
        /// <param name="loginPwd">密码</param>
        /// <returns></returns>
        public static bool ChangePwd(int sysNo, string loginPwd)
        {
            DbCommand cmd = new DbCommand("SystemUsers_ChangePwd");
            cmd.SetParameterValue("@SysNo", sysNo);
            cmd.SetParameterValue("@LoginPwd", loginPwd);
            cmd.ExecuteNonQuery();

            return true;
        }
    }
}
