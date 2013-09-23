using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;
using Framework.Util.Database.MSSQL;
using System.Data;

namespace DataAccess
{
    /// <summary>
    /// 充值记录
    /// </summary>
    public class PayLogDA
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
            int startRows = (pageIndex - 1) * pageSize;
            DbCommand cmd = new DbCommand("PayCard_GetByUserSysNo");
            cmd.SetParameterValue("@StartRow", startRows);
            cmd.SetParameterValue("@PageSize", pageSize);
            cmd.SetParameterValue("@UserSysNo", userSysNo);
            DataSet ds = cmd.ExecuteDataSet();
            var data = Util.FillModelList<PayLog>(ds.Tables[0]);
            int totalCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            return new PageList<List<PayLog>>(data, pageIndex, pageSize, totalCount);
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
            int startRows = (pageIndex - 1) * pageSize;
            DbCommand cmd = new DbCommand("PayLog_GetByBatch");
            cmd.SetParameterValue("@StartRow", startRows);
            cmd.SetParameterValue("@PageSize", pageSize);
            cmd.SetParameterValue("@BeginTime", beginTime);
            cmd.SetParameterValue("@EndTime", endTime);
            DataSet ds = cmd.ExecuteDataSet();
            var data = Util.FillModelList<PayLog>(ds.Tables[0]);
            int totalCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            return new PageList<List<PayLog>>(data, pageIndex, pageSize, totalCount);
        }
    }
}
