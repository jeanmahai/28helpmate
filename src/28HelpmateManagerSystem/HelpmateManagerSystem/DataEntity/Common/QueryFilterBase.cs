using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.Common
{
    [Serializable]
    [DataContract]
    public class QueryFilterBase
    {
        [DataMember]
        public int PageIndex { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public int TotalCount { get; set; }

        [DataMember]
        public int PageCount { get; set; }

        [DataMember]
        public string SortBy { get; set; }

        private List<SortItem> m_SortList = new List<SortItem>();

        [DataMember]
        public List<SortItem> SortList
        {
            get { return m_SortList; }
            set
            {
                if (value == null)
                {
                    m_SortList.Clear();
                }
                else
                {
                    m_SortList = value;
                }
            }
        }
        public string SortListToString()
        {
            string sbs = "";
            foreach (SortItem si in m_SortList)
            {
                if (!string.IsNullOrEmpty(si.SortFeild))
                {
                    sbs += si.SortFeild + " " + si.SortType.ToString() + ",";
                }
            }
            if (sbs.Length > 1)
            {
                sbs = sbs.TrimEnd(",".ToCharArray());
            }
            return sbs;
        }
    }
}







