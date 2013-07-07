using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services.Protocols;

namespace WebService
{
    public class TokenHeader:SoapHeader
    {
        /// <summary>
        /// 网站来源,龙虎,芝麻豆豆
        /// </summary>
        public string SiteSource { get; set; }
        /// <summary>
        /// 游戏来源,28,16
        /// </summary>
        public string GameSource { get; set; }
        /// <summary>
        /// 区域来源,加拿大,北京
        /// </summary>
        public string RegionSource { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 用户系统编号
        /// </summary>
        public int UserSysNo { get; set; }
    }
}