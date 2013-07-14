using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class PayLog
    {
        public virtual int SysNo { get; set; }
        public virtual int CardSysNo { get; set; }
        public virtual int UserSysNo { get; set; }
        public virtual DateTime InDate { get; set; }
        public virtual string IP { get; set; }
    }
}
