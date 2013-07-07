using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services.Protocols;

namespace WebService
{
    public class TokenHeader:SoapHeader
    {
        public string UserName { get; set; }
        public string Key { get; set; }
        public string[] Params { set; get; }
        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append(UserName);
            str.Append(Key);
            str.Append(string.Join("",Params));
            return str.ToString();
        }
        public string ToString(string userName, string key)
        {
            var str = new StringBuilder();
            str.Append(userName);
            str.Append(key);
            str.Append(string.Join("",Params));
            return str.ToString();
        }
    }
}