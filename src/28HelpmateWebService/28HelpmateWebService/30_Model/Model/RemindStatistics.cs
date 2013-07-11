using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class RemindStatistics
    {
        public virtual int SysNo { get; set; }
        public virtual int UserSysNo { get; set; }
        public virtual int GameSysNo { get; set; }
        public virtual int SourceSysNo { get; set; }
        public virtual int SiteSysNo { get; set; }
        public virtual int RetNum { get; set; }
        public virtual int Cnt { get; set; }
        public virtual int Status { get; set; }
    }
}
