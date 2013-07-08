using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class OmitStatistics
    {
        public virtual int SysNo { get; set; }
        public virtual int GameSysNo { get; set; }
        public virtual int SourceSysNo { get; set; }
        public virtual int SiteSysNo { get; set; }
        public virtual int RetNum { get; set; }
        public virtual int OmitCnt { get; set; }
        public virtual int MaxOmitCnt { get; set; }
        public virtual int StandardCnt { get; set; }
        public virtual Int64 NowPeriodNum { get; set; }
    }
}
