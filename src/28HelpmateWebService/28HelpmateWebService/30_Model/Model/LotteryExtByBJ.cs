using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class LotteryExtByBJ:LotteryForBJ
    {
        public virtual LotteryType Type { get; set; }
    }
}
