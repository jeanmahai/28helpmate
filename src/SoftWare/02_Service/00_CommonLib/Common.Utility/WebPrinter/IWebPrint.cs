using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Common.Utility
{
    public interface IWebPrint
    {
        void RenderHtmlForPrint(HttpContext context, string templateFileFullPath, KeyValueVariables variables, KeyTableVariables tableVariables);
    }
}
