using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class PayCard
    {
        public virtual int SysNo { get; set; }
        public virtual string PayCardID { get; set; }
        public virtual string PayCardPwd { get; set; }
        public virtual int CategorySysNo { get; set; }
        public virtual int Status { get; set; }
        public virtual DateTime InDate { get; set; }
        public virtual DateTime BeginTime { get; set; }
        public virtual DateTime EndTime { get; set; }
    }
}
