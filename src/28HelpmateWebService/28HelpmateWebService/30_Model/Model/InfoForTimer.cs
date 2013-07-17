using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class InfoForTimer
    {
        public LotteryForBJ Lottery { get; set; }

        public List<RemindStatistics> Remind { get; set; }
    }
}
