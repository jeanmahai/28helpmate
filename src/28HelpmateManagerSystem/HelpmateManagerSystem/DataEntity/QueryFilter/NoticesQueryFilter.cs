using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.Common;

namespace DataEntity.QueryFilter
{
    public class NoticesQueryFilter : QueryFilterBase
    {

        /// <summary>
        /// 编号
        /// </summary>
        public int? SysNo { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 公告状态
        /// </summary>
        public NoticesStatus? Status { get; set; }
    }
}
