using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity;
using System.Data;
using DataEntity.QueryFilter;
using DataAccess;
using DataEntity.Common;

namespace Logic
{
    public class NoticesLogic
    {

        /// <summary>
        /// 修改公告状态
        /// </summary>
        /// <param name="sysNo">编号</param>
        /// <param name="status">状态</param>
        public static QueryResult<Notices> QueryNotices(NoticesQueryFilter queryFilter)
        {
            return NoticesDA.QueryNotices(queryFilter);
        }

        /// <summary>
        /// 修改公告状态
        /// </summary>
        /// <param name="sysNo">编号</param>
        /// <param name="status">状态</param>
        public static bool ChangeNoticesStatus(int sysNo, NoticesStatus status)
        {
            return NoticesDA.ChangeNoticesStatus(sysNo, status);
        }

        /// <summary>
        /// 创建公告
        /// </summary>
        /// <param name="notices">公告信息</param>
        public static void CreateNotices(Notices notices)
        {
            NoticesDA.CreateNotices(notices);
        }

        /// <summary>
        /// 更新公告
        /// </summary>
        /// <param name="notices">公告信息</param>
        public static void UpdateNotices(Notices notices)
        {
            NoticesDA.UpdateNotices(notices);
        }

        /// <summary>
        /// 加载公告
        /// </summary>
        /// <param name="notices">公告信息</param>
        public static Notices LoadNotices(int sysNo)
        {
            return NoticesDA.LoadNotices(sysNo);
        }

    }
}
