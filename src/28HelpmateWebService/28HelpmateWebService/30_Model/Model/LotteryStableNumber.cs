using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    /// <summary>
    /// 稳定号码
    /// </summary>
    public class LotteryStableNumber
    {
        public virtual int RetNum { get; set; }
        public virtual int Days { get; set; }
        public virtual int Cnt { get; set; }
    }
    public class LotteryStableNumberVM
    {
        public virtual int RetNum1 { get; set; }
        public string DayAndCnt1 { get; set; }
        public virtual int RetNum2 { get; set; }
        public string DayAndCnt2 { get; set; }
        public virtual int RetNum3 { get; set; }
        public string DayAndCnt3 { get; set; }
    }
}
