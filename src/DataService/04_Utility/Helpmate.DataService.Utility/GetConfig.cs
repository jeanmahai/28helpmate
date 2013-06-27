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
        /// <param name="nodeName">节点名称</param>
        /// <returns></returns>
        public static string GetXMLValue(string nodeName)
        {
            string nodeValue = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "\\SvcConfig.xml");
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
