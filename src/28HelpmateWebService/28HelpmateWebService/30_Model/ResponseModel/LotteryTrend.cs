using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Model;

namespace Model.ResponseModel
{
    public class LotteryTrend
    {
        public List<LotteryTimes> LotteryTimeses { get; set; }
        public PageList<LotteryExtByBJ> PageList { get; set; }
    }
}
