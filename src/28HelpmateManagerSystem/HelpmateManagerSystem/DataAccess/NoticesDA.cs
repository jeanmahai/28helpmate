using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;
using DataEntity.QueryFilter;
using Framework.Util.Database.MSSQL;
using System.Data;
using DataEntity.Common;
using Common.Utility.DataAccess;

namespace DataAccess
{
    /// <summary>
    /// 公告
    /// </summary>
    public class NoticesDA
    {
        /// <summary>
        /// 查询公告
        /// </summary>
        /// <param name="filter">查询条件</param>
        public static QueryResult<Notices> QueryNotices(NoticesQueryFilter filter)
        {
            QueryResult<Notices> result = new QueryResult<Notices>();
            PagingInfoEntity page = new PagingInfoEntity();
            page.SortField = (filter.SortList == null || filter.SortList.Count == 0) ? null : filter.SortListToString();
            page.MaximumRows = filter.PageSize;
            page.StartRowIndex = filter.PageIndex * filter.PageSize;
            CustomDataCommand cmd = DataCommandManager.CreateCustomDataCommandFromConfig("PayCard_Query");
            using (var sqlBuilder = new DynamicQuerySqlBuilder(cmd.CommandText, cmd, page, "SysNo DESC"))
            {
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "SysNo", DbType.Int32, "@SysNo", QueryConditionOperatorType.Equal, filter.SysNo);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Contents", DbType.String, "@Contents", QueryConditionOperatorType.Like, filter.Contents);
                sqlBuilder.ConditionConstructor.AddCondition(QueryConditionRelationType.AND, "Status", DbType.Int32, "@Status", QueryConditionOperatorType.Equal, filter.Status);

                cmd.CommandText = sqlBuilder.BuildQuerySql();
                result.ResultList = cmd.ExecuteEntityList<Notices>();

                int totalCount = Convert.ToInt32(cmd.GetParameterValue("@TotalCount"));
                result.PagingInfo = new PagingInfo() { PageIndex = filter.PageIndex, PageSize = filter.PageSize, TotalCount = totalCount };
                return result;
            }
        }

        /// <summary>
        /// 修改公告状态
        /// </summary>
        /// <param name="sysNo">编号</param>
        /// <param name="status">状态</param>
        public static void ChangeNoticesStatus(int sysNo, NoticesStatus status)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("ChangeNoticesStatus");
            cmd.SetParameterValue("@SysNo", sysNo);
            cmd.SetParameterValue("@Status", status);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 创建公告
        /// </summary>
        /// <param name="notices">公告信息</param>
        public static void CreateNotices(Notices notices)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("CreateNotices");
            cmd.SetParameterValue<Notices>(notices);
            cmd.ExecuteNonQuery();
            var sysNo = (int)cmd.GetParameterValue("@SysNo");
        }

        /// <summary>
        /// 更新公告
        /// </summary>
        /// <param name="notices">公告信息</param>
        public static void UpdateNotices(Notices notices)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("UpdateNotices");
            cmd.SetParameterValue<Notices>(notices);
            cmd.ExecuteNonQuery();
        }
    }
}
