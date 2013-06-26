using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace Common.Service.Utility.WCF
{
    [DataContract]
    public class QueryResult
    {
        [DataMember]
        public DataTable Data
        {
            get;
            set;
        }

        [DataMember]
        public int TotalCount
        {
            get;
            set;
        }
    }

    public class QueryResultList : List<QueryResult>
    {

    }
}
