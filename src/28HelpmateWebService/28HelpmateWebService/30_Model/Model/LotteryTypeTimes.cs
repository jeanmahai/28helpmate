using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class LotteryTypeTimes
    {
        public virtual int SmallTimes { get; set; }
        public virtual int BigTimes { get; set; }
        public virtual int SideTimes { get; set; }
        public virtual int CenterTimes { get; set; }
        public virtual int OddTimes { get; set; }
        public virtual int EvenTimes { get; set; }
    }
}
