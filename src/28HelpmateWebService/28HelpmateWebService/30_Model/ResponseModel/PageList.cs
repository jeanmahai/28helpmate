using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.ResponseModel
{
    [Serializable]
    public class PageList<T> where T :class ,new ()
    {
        public int Total { get; set; }
        public List<T> List { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
