using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class OmissionLottery
    {
        public virtual int Number { get; set; }
        public virtual int NearPeriod { get; set; }
        public virtual int Interval { get; set; }
    }
}
