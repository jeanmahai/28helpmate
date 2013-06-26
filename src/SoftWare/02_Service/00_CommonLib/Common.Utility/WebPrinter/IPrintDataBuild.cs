using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace Common.Utility
{
    public interface IPrintDataBuild
    {
        void BuildData(NameValueCollection requestPostData, out KeyValueVariables variables, out KeyTableVariables tableVariables);
    }
}
