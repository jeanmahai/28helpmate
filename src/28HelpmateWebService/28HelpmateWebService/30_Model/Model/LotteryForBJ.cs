using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Enum;

namespace Model.Model
{
    [Serializable]
    public class LotteryForBJ
    {
        public virtual int PeriodNum { get; set; }
        public virtual DateTime RetTime { get; set; }
        public virtual int SiteSysNo { get; set; }
        public virtual int RetOddNum { get; set; }
        public virtual int RetNum { get; set; }
        public virtual string RetMidNum { get; set; }
        public virtual string CollectRet { get; set; }
        public virtual DateTime CollectTime { get; set; }
        public virtual int Status { get; set; }
        public virtual LotteryType type { get; set; }
    }
}
