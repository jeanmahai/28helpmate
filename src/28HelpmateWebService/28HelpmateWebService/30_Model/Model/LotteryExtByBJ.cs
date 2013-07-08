using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class LotteryExtByBJ
    {
        public virtual int PeriodNum { get; set; }
        public virtual int RetNum { get; set; }
        public virtual string BigOrSmall { get; set; }
        public virtual string MiddleOrSide { get; set; }
        public virtual string OddOrDual { get; set; }
        public virtual DateTime RetTime { get; set; }
    }
}
