﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class User
    {
        public virtual int SysNo { get; set; }
        public virtual string UserID { get; set; }
        public virtual string UserPwd { get; set; }
        public virtual string UserName { get; set; }
        public virtual int Status { get; set; }
        public virtual string RegIP { get; set; }
        public virtual DateTime RegDate { get; set; }
        public virtual DateTime RechargeUseBeginTime { get; set; }
        public virtual DateTime RechargeUseEndTime { get; set; }

        public virtual string SecurityQuestion1 { get; set; }
        public virtual string SecurityAnswer1 { get; set; }
        public virtual string SecurityQuestion2 { get; set; }
        public virtual string SecurityAnswer2 { get; set; }
        public virtual string Phone { get; set; }

        public virtual string QQ { get; set; }

    }
}
