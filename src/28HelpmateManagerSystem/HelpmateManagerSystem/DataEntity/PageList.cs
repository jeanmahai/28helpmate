using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity
{
    public class PageList<T>
    {
        public T DataList { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount
        {
            get
            {
                int n = this.TotalCount / this.PageSize;
                return this.TotalCount % this.PageSize != 0 ? n + 1 : n;
            }
        }
        public int TotalCount { get; set; }

        public PageList(T data, int pageIndex, int pageSize, int totalCount)
        {
            this.PageIndex = pageIndex;
            this.DataList = data;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
        }
    }
}
