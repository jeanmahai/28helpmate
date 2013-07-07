using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.ResponseModel
{
    [Serializable]
    public class LotteryFilterForBJ
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string SiteName { get; set; }
        public string GameName { get; set; }
    }
}
