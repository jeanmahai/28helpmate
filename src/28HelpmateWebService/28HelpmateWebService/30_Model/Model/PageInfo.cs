using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Model
{
    public class PageInfo
    {
        public virtual int Total { get; set; }
        public virtual int PageIndex { get; set; }
        public virtual int PageSize { get; set; }
        public virtual int PageCount { get; set; }
    }
}
