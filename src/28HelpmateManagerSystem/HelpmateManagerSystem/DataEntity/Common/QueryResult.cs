using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.Common
{
    [Serializable]
    [DataContract]
    public class QueryResult<T>
    {
        [DataMember]
        public List<T> ResultList { get; set; }

        [DataMember]
        public PagingInfo PagingInfo { get; set; }


    }

    [DataContract]
    public class PagingInfo
    {
        [DataMember]
        public int PageIndex { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public int TotalCount { get; set; }
         
        public int PageCount
        {
            get
            {
                int pc = TotalCount / PageSize;
                if (TotalCount % PageSize > 0)
                {
                    pc = +1;
                }
                return pc;
            }
        }

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

    }

    [Serializable]
    public enum SortType
    {
        [EnumMember]
        DESC,
        [EnumMember]
        ASC
    }

    [Serializable]
    [DataContract]
    public class SortItem
    {
        [DataMember]
        public string SortFeild { get; set; }

        [DataMember]
        public SortType SortType { get; set; }
         
        public override string ToString()
        {
            return String.Format("{0} {1}", SortFeild, SortType.ToString());
        }
    }
}
