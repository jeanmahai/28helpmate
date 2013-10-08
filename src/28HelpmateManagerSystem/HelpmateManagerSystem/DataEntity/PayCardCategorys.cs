using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity
{
    /// <summary>
    /// 充值卡类型
    /// </summary>
    public class PayCardCategorys
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public int CategorySysNo { get; set; }
        /// <summary>
        /// 充值卡卡号
        /// </summary>
        public string CategoryName { get; set; }
    }
}
