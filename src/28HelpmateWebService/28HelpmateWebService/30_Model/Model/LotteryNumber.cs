using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    /// <summary>
    /// 未出现号码,极品号码
    /// </summary>
    public class LotteryNumber
    {
        public virtual int Idx { get; set; }
        public virtual string Date { get; set; }
        public virtual int RetNum { get; set; }
    }
}
