using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using DataEntity;
using Common.Utility.DataAccess;

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
            PagingInfoEntity page = new PagingInfoEntity();
            page.MaximumRows = pageSize;
            page.StartRowIndex = pageIndex * pageSize;
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("Users_Query");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "SysNo DESC"))
            {
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "UserID", DbType.String, "@UserID", QueryConditionOperatorType.Like, userID);
                if (status >= 0)
                    sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Status", DbType.Int32, "@Status", QueryConditionOperatorType.Equal, status);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "PayUseBeginTime", DbType.DateTime, "@PayUseBeginTime", QueryConditionOperatorType.MoreThanOrEqual, payUserBeginTime);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "PayUseEndTime", DbType.DateTime, "@PayUseEndTime", QueryConditionOperatorType.LessThanOrEqual, payUseEndTime);

                cmd.CommandText = sqlBuilder.BuildQuerySql();
                List<User> result = cmd.ExecuteEntityList<User>();

                int totalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));
                return new PageList<List<User>>(result, pageIndex, pageSize, totalCount);
            }
        }

        /// <summary>
        /// 获取单个用户
        /// </summary>
        /// <param name="sysNo">用户编号</param>
        /// <returns></returns>
        public static User GetBySysNo(int sysNo)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("Users_GetBySysNo");
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
            DataCommand cmd = DataCommandManager.GetDataCommand("Users_UpdateStatus");
            cmd.SetParameterValue("@Status", (int)status);
            cmd.SetParameterValue("@SysNo", sysNo);
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
            DataCommand cmd = DataCommandManager.GetDataCommand("Users_Delete");
            cmd.SetParameterValue("@SysNo", sysNo);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
