using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;

namespace Common.Utility
{
    public class LogSection : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            LogSetting setting = new LogSetting();
            if (section != null)
            {
                setting.WebServiceParam = GetParams(section, "webservice", "param");
                setting.TextParam = GetParams(section, "text", "param");
                setting.MsmqParam = GetParams(section, "msmq", "param");
                setting.CustomParam = GetCustomParams(section, "custom", "type", "param");
                setting.GlobalRegionName = GetNodeAttribute(section, "globalRegionName");
                setting.LocalRegionName = GetNodeAttribute(section, "localRegionName");
            }
            return setting;
        }

        private XmlNode[] GetChildrenNodes(XmlNode node, string nodeName)
        {
            return GetChildrenNodes(node, delegate(XmlNode child)
            {
                return child.Name == nodeName;
            });
        }

        private XmlNode[] GetChildrenNodes(XmlNode node, Predicate<XmlNode> match)
        {
            if (node == null || node.ChildNodes == null || node.ChildNodes.Count <= 0)
            {
                return new XmlNode[0];
            }
            List<XmlNode> nodeList = new List<XmlNode>(node.ChildNodes.Count);
            foreach (XmlNode child in node.ChildNodes)
            {
                if (match(child))
                {
                    nodeList.Add(child);
                }
            }
            return nodeList.ToArray();
        }

        private string GetNodeAttribute(XmlNode node, string attributeName)
        {
            if (node.Attributes == null
                        || node.Attributes[attributeName] == null
                        || node.Attributes[attributeName].Value == null
                        || node.Attributes[attributeName].Value.Trim() == string.Empty)
            {
                return string.Empty;
            }
            return node.Attributes[attributeName].Value.Trim();
        }

        private string GetParams(XmlNode node, string nodeName, string paramName)
        {
            string paramStr = string.Empty;
            XmlNode[] nodeList = GetChildrenNodes(node, nodeName);
            foreach (var n in nodeList)
            {
                if(paramStr.Length > 0)
                {
                    paramStr = paramStr + ",";
                }
                paramStr = paramStr + GetNodeAttribute(n, paramName);
            }
            return paramStr;
        }

        private Dictionary<Type, string> GetCustomParams(XmlNode node, string nodeName, string typeAttrName, string paramName)
        {
            Dictionary<Type, string> rst = new Dictionary<Type, string>();
            XmlNode[] nodeList = GetChildrenNodes(node, nodeName);
            foreach (var n in nodeList)
            {
                string typeName = GetNodeAttribute(n, typeAttrName);
                string paramStr = GetNodeAttribute(n, paramName);
                if (typeName == null || typeName.Trim().Length <= 0)
                {
                    continue;
                }
                Type type = Type.GetType(typeName.Trim(), false);
                if (type == null || !typeof(ILogEmitter).IsAssignableFrom(type) || type.IsAbstract || type.IsInterface
                    || type.GetConstructor(Type.EmptyTypes) == null)
                {
                    continue;
                }
                if (rst.ContainsKey(type))
                {
                    rst[type] = rst[type] + "," + paramStr;
                }
                else
                {
                    rst.Add(type, paramStr);
                }
            }
            return rst;
        }

        private static LogSetting s_LogSetting = null;
        private static bool s_HasInit = false;
        private static object s_SyncObj = new object();
        public static LogSetting GetSetting()
        {
            if (s_HasInit == false)
            {
                lock (s_SyncObj)
                {
                    if (s_HasInit == false)
                    {
                        s_LogSetting = ConfigurationManager.GetSection("log") as LogSetting;
                        s_HasInit = true;
                    }
                }
            }
            return s_LogSetting;
        }
    }

    public class LogSetting
    {
        public string WebServiceParam
        {
            get;
            set;
        }

        public string TextParam
        {
            get;
            set;
        }

        public string MsmqParam
        {
            get;
            set;
        }

        public Dictionary<Type, string> CustomParam
        {
            get;
            set;
        }

        public string GlobalRegionName
        {
            get;
            set;
        }

        public string LocalRegionName
        {
            get;
            set;
        }
    }
}
