using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;

namespace Common.Utility
{
    public class MailSection : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            List<SmtpSetting> setting = new List<SmtpSetting>(3);
            if (section != null)
            {
                XmlNode[] nodeList = GetChildrenNodes(section, "smtp");
                if (nodeList != null && nodeList.Length > 0)
                {
                    foreach (XmlNode node in nodeList)
                    {
                        SmtpSetting s = new SmtpSetting();
                        s.Address = GetNodeAttribute(node, "address");
                        s.UserName = GetNodeAttribute(node, "userName");
                        s.Password = GetNodeAttribute(node, "password");
                        string portStr = GetNodeAttribute(node, "port");
                        string sslStr = GetNodeAttribute(node, "enableSsl");
                        int port;
                        if (int.TryParse(portStr, out port) && port > 0)
                        {
                            s.Port = port;
                        }
                        else
                        {
                            s.Port = 25;
                        }
                        bool ssl;
                        if (bool.TryParse(sslStr, out ssl))
                        {
                            s.EnableSsl = ssl;
                        }
                        else
                        {
                            s.EnableSsl = false;
                        }
                        setting.Add(s);
                    }
                }
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

        private static List<SmtpSetting> s_MailSetting = null;
        private static bool s_HasInit = false;
        private static object s_SyncObj = new object();
        public static List<SmtpSetting> GetSetting()
        {
            if (s_HasInit == false)
            {
                lock (s_SyncObj)
                {
                    if (s_HasInit == false)
                    {
                        s_MailSetting = ConfigurationManager.GetSection("mail") as List<SmtpSetting>;
                        s_HasInit = true;
                    }
                }
            }
            return s_MailSetting;
        }
    }

    public class SmtpSetting
    {
        public string Address
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }

        public bool EnableSsl
        {
            get;
            set;
        }
    }
}
