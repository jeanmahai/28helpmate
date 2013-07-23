using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    /// <summary>
    /// 类型的平均次数
    /// </summary>
    public class LotteryTypeAvg
    {
        public virtual int AvgBig { get; set; }
        public virtual int PBig { get; set; }
        public virtual int AvgSmall { get; set; }
        public virtual int PSmall { get; set; }
        public virtual int AvgMiddle { get; set; }
        public virtual int PMiddle { get; set; }
        public virtual int AvgSide { get; set; }
        public virtual int PSide { get; set; }
        public virtual int AvgOdd { get; set; }
        public virtual int POdd { get; set; }
        public virtual int AvgDual { get; set; }
        public virtual int PDual { get; set; }
    }
}
