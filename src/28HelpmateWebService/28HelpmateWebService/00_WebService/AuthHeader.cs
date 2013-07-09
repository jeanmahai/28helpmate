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
        public int SiteSourceSysNo { get; set; }
        /// <summary>
        /// 游戏来源,28,16
        /// </summary>
        public int GameSourceSysNo { get; set; }
        /// <summary>
        /// 区域来源,加拿大,北京
        /// </summary>
        public int RegionSourceSysNo { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 用户系统编号
        /// </summary>
        public int UserSysNo { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}{4}", Token, UserSysNo, GameSourceSysNo, RegionSourceSysNo, SiteSourceSysNo);
        }
        public string ToString(string key)
        {
            return string.Format("{0}{1}{2}{3}{4}",key,UserSysNo,GameSourceSysNo,RegionSourceSysNo,SiteSourceSysNo);
        }
    }
}