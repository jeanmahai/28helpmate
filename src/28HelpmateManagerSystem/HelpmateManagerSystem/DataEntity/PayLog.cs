using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 充值记录
    /// </summary>
    public class PayLog
    {
        /// <summary>
        /// 充值记录编号
        /// </summary>
        public int SysNo { get; set; }
        /// <summary>
        /// 充值卡编号
        /// </summary>
        public long CardSysNo { get; set; }
        /// <summary>
        /// 充值卡卡号
        /// </summary>
        public string PayCardID { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserSysNo { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime InDate { get; set; }
        /// <summary>
        /// 充值时间文本
        /// </summary>
        public string StrInDate
        {
            get
            {
                return this.InDate.ToString();
            }
        }
        /// <summary>
        /// 充值IP
        /// </summary>
        public string IP { get; set; }
    }
}
