using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace WebService
{
    public class TokenHeader:SoapHeader
    {
        public string Token { get; set; }
        public bool ValidateToken()
        {
            return true;
        }
    }
}