using System;
using DataEntity;
using DataAccess;
using System.Collections.Generic;

namespace Logic
{
    public class UserLogic
    {
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="pageIndex">取第几页</param>
        /// <param name="pageSize">每页显示几条</param>
        /// <param name="userID">用户登录名，全部则为null</param>
        /// <param name="status">状态，全部则为null</param>
        /// <param name="payUserBeginTime">充值使用时间起，不限制时间则为null</param>
        /// <param name="payUseEndTime">充值使用时间止，不限制时间则为null</param>
        /// <returns></returns>
        public static PageList<List<User>> QueryUser(int pageIndex, int pageSize, string userID, int? status, DateTime? payUserBeginTime, DateTime? payUseEndTime)
        {
            pageIndex -= 1;
            if (pageIndex < 0)
                pageIndex = 0;
            userID = userID == null ? "" : userID;
            int nStatus = status == null ? -1 : (int)status.Value;
            DateTime dtBegin = payUserBeginTime == null ? DateTime.Now.AddYears(-100) : payUserBeginTime.Value;
            DateTime dtEnd = payUseEndTime == null ? DateTime.Now.AddYears(100) : payUseEndTime.Value;
            return UserDA.QueryUser(pageIndex, pageSize, userID, nStatus, dtBegin, dtEnd);
        }

        /// <summary>
        /// 获取单个用户
        /// </summary>
        /// <param name="sysNo">用户编号</param>
        /// <returns></returns>
        public static User GetBySysNo(int sysNo)
        {
            return UserDA.GetBySysNo(sysNo);
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="sysNo">用户编号</param>
        /// <returns></returns>
        public static bool EnableUser(int sysNo)
        {
            return UserDA.UpdateStatus(sysNo, UserStatus.Valid);
        }

        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="sysNo">用户编号</param>
        /// <returns></returns>
        public static bool DisableUser(int sysNo)
        {
            return UserDA.UpdateStatus(sysNo, UserStatus.Invalid);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sysNo">用户编号</param>
        /// <returns></returns>
        public static bool DeleteUser(int sysNo)
        {
            return UserDA.Delete(sysNo);
        }
    }
}
