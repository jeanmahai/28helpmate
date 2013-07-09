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
        public List<LotteryExtByBJ> DataList { get; set; }
        //public PageInfo PageInfo { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
    }
}
