using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Enum;

namespace Model.ResponseModel
{
    [Serializable]
    public class LotteryRM
    {
        public int Period { get; set; }
        public int Number { get; set; }
        public BigSmallEnum BigSmall { get; set; }
        public CenterSideEnum CenterSide { get; set; }
        public OddEvenEnum OddEven { get; set; }
    }
}
