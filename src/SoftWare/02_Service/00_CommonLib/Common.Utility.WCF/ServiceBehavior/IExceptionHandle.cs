using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Service.Utility.WCF
{
    public interface IExceptionHandle
    {
        void Handle(Exception error, object[] methodArguments);
    }
}
