using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.QueryFilter
{
    public class NoticesQueryFilter
    {

        public PagingInfo PagingInfo { get; set; }

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
