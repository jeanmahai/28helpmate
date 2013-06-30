﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Enum;

namespace Model.Model
{
    [Serializable]
    public class LotteryType
    {
        public virtual int RetNum { get; set; }
        public virtual string BigOrSmall { get; set; }
        public virtual string MiddleOrSide { get; set; }
        public virtual string OddOrDual { get; set; }
        public virtual string MantissaBigOrSmall { get; set; }

        public virtual string ThreeRemainder { get; set; }
        public virtual string FourRemainder { get; set; }
        public virtual string FiveRemainder { get; set; }
    }
}
