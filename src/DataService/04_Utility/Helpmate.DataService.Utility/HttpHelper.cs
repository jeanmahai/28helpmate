using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Helpmate.DataService.Utility
{
    /// <summary>
    /// HTTP工具类
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// 采集数据
        /// </summary>
        /// <param name="url">http请求地址</param>
        /// <returns></returns>
        public static string GetHttpData(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding(936));
            string result = sr.ReadToEnd();
            sr.Close();
            res.Close();
            return result;
        }
    }
}
