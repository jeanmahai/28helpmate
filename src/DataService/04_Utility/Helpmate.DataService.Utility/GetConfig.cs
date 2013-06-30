using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Helpmate.DataService.Utility
{
    /// <summary>
    /// 读取配置
    /// </summary>
    public class GetConfig
    {
        /// <summary>
        /// 从XML文件中读取节点值
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="nodeName">节点名称</param>
        /// <returns></returns>
        public static string GetXMLValue(ConfigSource source, string nodeName)
        {
            string nodeValue = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\SvcConfig{0}.xml";
                switch (source)
                {
                    case ConfigSource.Beijing:
                        path = string.Format(path, "Beijing");
                        break;
                    case ConfigSource.Canadan:
                        path = string.Format(path, "Canadan");
                        break;
                    default:
                        path = string.Format(path, "");
                        break;
                }
                xmlDoc.Load(path);
                XmlNode xn = xmlDoc.SelectSingleNode("config");
                nodeValue = xn.SelectNodes(nodeName).Item(0).InnerText;
            }
            catch
            {
                throw;
            }
            return nodeValue;
        }
    }
}
