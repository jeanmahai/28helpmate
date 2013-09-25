using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;
using DataAccess;

namespace Logic
{
    /// <summary>
    /// 公告
    /// </summary>
    public class PayLogLogic
    {

        /// <summary>
        /// 获取用户充值记录
        /// </summary>
        /// <param name="pageIndex">取第几页</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="userSysNo">用户编号</param>
        /// <returns></returns>
        public static PageList<List<PayLog>> GetUserPayLog(int pageIndex, int pageSize, int userSysNo)
        {
            return PayLogDA.GetUserPayLog(pageIndex, pageSize, userSysNo);
        }

        /// <summary>
        /// 获取充值记录
        /// </summary>
        /// <param name="pageIndex">取第几页</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="beginTime">充值时间的开始时间</param>
        /// <param name="endTime">充值时间的结束时间</param>
        /// <returns></returns>
        public static PageList<List<PayLog>> GetPayLogByBatch(int pageIndex, int pageSize, DateTime beginTime, DateTime endTime)
        {
            return PayLogDA.GetPayLogByBatch(pageIndex, pageSize, beginTime, endTime);
        }
    }
}
