using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class SpecialLottery
    {
        public List<LotteryTypeCount> LotteryTypeCount { get; set; }
        public LotteryTypeAvg LotteryTypeAvg { get; set; }
        public LotteryStableNumberVM LotteryStableNumber { get; set; }
    }
}
