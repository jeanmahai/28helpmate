using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 新闻公告
    /// </summary>
    public class Notices
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long SysNo { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public NoticesStatus Status { get; set; }

        /// <summary>
        /// 展示优先级 数字越大越靠前
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? InDate { get; set; }

        /// <summary>
        /// 发布人
        /// </summary>
        public string PublishUser { get; set; }
    }
}
