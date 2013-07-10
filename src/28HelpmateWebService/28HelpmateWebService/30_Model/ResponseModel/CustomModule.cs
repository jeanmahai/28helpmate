using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Model;

namespace Model.ResponseModel
{
    public class CustomModules
    {
        public LotteryByTwentyPeriod M1 { get; set; }
        public LotteryByTwentyPeriod M2 { get; set; }
        public LotteryByTwentyPeriod M3 { get; set; }
        public LotteryByTwentyPeriod M4 { get; set; }
        public LotteryForBJ CurrentLottery { get; set; }
        public LotteryForBJ NextLottery { get; set; }
    }
}
