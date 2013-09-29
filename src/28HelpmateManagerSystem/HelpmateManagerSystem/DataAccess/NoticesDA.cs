using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;
using DataEntity.QueryFilter;
using Framework.Util.Database.MSSQL;
using System.Data;

namespace DataAccess
{
    /// <summary>
    /// 公告
    /// </summary>
    public class NoticesDA
    {
        /// <summary>
        /// 修改公告状态
        /// </summary>
        /// <param name="sysNo">编号</param>
        /// <param name="status">状态</param>
        public static PageList<List<Notices>> QueryNotices(NoticesQueryFilter queryFilter)
        {
            int startRows = (queryFilter.PagingInfo.PageIndex.Value - 1) * queryFilter.PagingInfo.PageSize.Value;
            DbCommand cmd = new DbCommand("PayCard_Query", System.Data.CommandType.StoredProcedure);
            cmd.SetParameterValue("@StartRows", startRows);
            cmd.SetParameterValue("@PageSize", queryFilter.PagingInfo.PageSize);
            cmd.SetParameterValue("@SysNo", queryFilter.SysNo);
            cmd.SetParameterValue("@Contents", queryFilter.Contents);
            cmd.SetParameterValue("@Status", queryFilter.Status);

            DataSet ds = cmd.ExecuteDataSet();
            List<Notices> result = Util.FillModelList<Notices>(ds.Tables[0]);
            int totalCount = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            var pageList = new PageList<List<Notices>>(result, queryFilter.PagingInfo.PageIndex.Value, queryFilter.PagingInfo.PageIndex.Value, totalCount);
            return pageList;
        }

        /// <summary>
        /// 修改公告状态
        /// </summary>
        /// <param name="sysNo">编号</param>
        /// <param name="status">状态</param>
        public static void ChangeNoticesStatus(int sysNo, NoticesStatus status)
        {
            DbCommand cmd = new DbCommand("ChangeNoticesStatus");
            cmd.SetParameterValue("@SysNo", sysNo);
            cmd.SetParameterValue("@Status", Convert.ToInt32(status));
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 创建公告
        /// </summary>
        /// <param name="notices">公告信息</param>
        public static void CreateNotices(Notices notices)
        {
            DbCommand cmd = new DbCommand("CreateNotices");
            cmd.SetParameterValue("@Contents", notices.Contents);
            cmd.SetParameterValue("@Status", Convert.ToInt32(notices.Status));
            cmd.SetParameterValue("@Rank", notices.Rank);
            cmd.SetParameterValue("@PublishUser", notices.PublishUser);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 更新公告
        /// </summary>
        /// <param name="notices">公告信息</param>
        public static void UpdateNotices(Notices notices)
        {
            DbCommand cmd = new DbCommand("UpdateNotices");
            cmd.SetParameterValue("@SysNo", notices.SysNo);
            cmd.SetParameterValue("@Contents", notices.Contents);
            cmd.SetParameterValue("@Status", Convert.ToInt32(notices.Status));
            cmd.SetParameterValue("@Rank", notices.Rank);
            cmd.SetParameterValue("@PublishUser", notices.PublishUser);
            cmd.ExecuteNonQuery();
        }
    }
}
