using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class Notices
    {
        public virtual int SysNo { get; set; }
        public virtual string Contents { get; set; }
        public virtual int Status { get; set; }
        public virtual int Rank { get; set; }
        public virtual DateTime InDate { get; set; }
        public virtual string PublishUser { get; set; }
    }
}
