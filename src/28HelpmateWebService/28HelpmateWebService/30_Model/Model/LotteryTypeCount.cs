using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class LotteryTypeCount
    {
        public virtual string Date { get; set; }
        public virtual int Small{ get; set; }
        public virtual int Big { get; set; }
        public virtual int Middle { get; set; }
        public virtual int Side { get; set; }
        public virtual int Odd { get; set; }
        public virtual int Dual { get; set; }
        public virtual string NoAppearNum { get; set; }
        public virtual string BestNum { get; set; }
    }
}
