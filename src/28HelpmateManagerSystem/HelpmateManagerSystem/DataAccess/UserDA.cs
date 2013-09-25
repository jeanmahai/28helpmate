using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using DataEntity;
using Framework.Util.Encryption;
using Framework.Util.Database.MSSQL;

namespace DataAccess
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserDA
    {
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="pageIndex">取第几页</param>
        /// <param name="pageSize">每页显示几条</param>
        /// <param name="userID">用户登录名</param>
        /// <param name="status">状态</param>
        /// <param name="payUserBeginTime">充值使用时间起</param>
        /// <param name="payUseEndTime">充值使用时间止</param>
        /// <returns></returns>
        public static PageList<List<User>> QueryUser(int pageIndex, int pageSize, string userID, int status, DateTime payUserBeginTime, DateTime payUseEndTime)
        {
            int startRows = (pageIndex - 1) * pageSize;
            DbCommand cmd = new DbCommand("Users_Query", System.Data.CommandType.StoredProcedure);
            cmd.SetParameterValue("@StartRows", startRows);
            cmd.SetParameterValue("@PageSize", pageSize);
            cmd.SetParameterValue("@UserID", userID);
            cmd.SetParameterValue("@Status", status);
            cmd.SetParameterValue("@PayUseBeginTime", payUserBeginTime);
            cmd.SetParameterValue("@PayUseEndTime", payUseEndTime);
            DataSet ds = cmd.ExecuteDataSet();

            List<User> result = Util.FillModelList<User>(ds.Tables[0]);
            int totalCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());

            return new PageList<List<User>>(result, pageIndex, pageSize, totalCount);
        }

        /// <summary>
        /// 获取单个用户
        /// </summary>
        /// <param name="sysNo">用户编号</param>
        /// <returns></returns>
        public static User GetBySysNo(int sysNo)
        {
            DbCommand cmd = new DbCommand("Users_GetBySysNo");
            cmd.SetParameterValue("@SysNo", sysNo);
            return cmd.ExecuteEntity<User>();
        }

        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="sysNo">用户编号</param>
        /// <param name="status">用户状态</param>
        /// <returns></returns>
        public static bool UpdateStatus(int sysNo, UserStatus status)
        {
            DbCommand cmd = new DbCommand("Users_UpdateStatus");
            cmd.SetParameterValue("@SysNo", sysNo);
            cmd.SetParameterValue("@Status", (int)status);
            cmd.ExecuteNonQuery();
            return true;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sysNo">用户编号</param>
        /// <returns></returns>
        public static bool Delete(int sysNo)
        {
            DbCommand cmd = new DbCommand("Users_Delete");
            cmd.SetParameterValue("@SysNo", sysNo);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
