using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Xml;

namespace Common.Utility
{
    internal class ExporterSetting
    {
        public string BaseFolder
        {
            get;
            set;
        }

        public string VirtualPath
        {
            get;
            set;
        }

        public string Default
        {
            get;
            set;
        }

        public string Expiry
        {
            get;
            set;
        }

        public int? MaxRowCountLimit
        {
            get;
            set;
        }

        public Dictionary<string, string> FileExporterList
        {
            get;
            set;
        }

        public TimeSpan GetExpiryTime()
        {
            TimeSpan tmp;
            if (TimeSpan.TryParse(Expiry, out tmp))
            {
                return tmp;
            }
            return new TimeSpan(0, 5, 0); // 默认5分钟
        }
    }

    internal static class FileExporterConfig
    {
        private static readonly string Config_File_Path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configuration\\FileExporter.config");
        private static ExporterSetting s_ExporterSetting;
        private static object s_SyncObj = new object();

        public static ExporterSetting GetSetting()
        {
            if (s_ExporterSetting == null)
            {
                lock (s_SyncObj)
                {
                    if (s_ExporterSetting == null)
                    {
                        string tmpPath = ConfigurationManager.AppSettings["FileExporterConfigPath"];
                        if (tmpPath == null || tmpPath.Trim().Length <= 0)
                        {
                            tmpPath = Config_File_Path;
                        }
                        else if (!tmpPath.Contains(':')) // 说明配得相对路径
                        {
                            tmpPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, tmpPath);
                        }
                        ExporterSetting tmp = new ExporterSetting();
                        if (File.Exists(tmpPath))
                        {
                            XmlDocument x = new XmlDocument();
                            x.Load(tmpPath);
                            XmlNode node = x.SelectSingleNode("//fileExporter");
                            tmp.Default = GetNodeAttribute(node, "default");
                            tmp.Expiry = GetNodeAttribute(node, "expiry");
                            tmp.BaseFolder = GetNodeAttribute(node, "baseFolder");
                            tmp.VirtualPath = GetNodeAttribute(node, "virtualPath"); 
                            string max = GetNodeAttribute(node, "maxRowCountLimit");
                            int limit;
                            if (int.TryParse(max, out limit) && limit > 0)
                            {
                                tmp.MaxRowCountLimit = limit;
                            }
                            XmlNode[] list = GetChildrenNodes(node, "add");
                            tmp.FileExporterList = new Dictionary<string, string>(list.Length * 2);
                            foreach (XmlNode n in list)
                            {
                                tmp.FileExporterList.Add(GetNodeAttribute(n, "name"), GetNodeAttribute(n, "type"));
                            }
                        }
                        else
                        {
                            tmp.FileExporterList = new Dictionary<string, string>(0);
                        }
                        s_ExporterSetting = tmp;
                    }
                }
            }
            return s_ExporterSetting;
        }

        private static string GetNodeAttribute(XmlNode node, string attributeName)
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

        private static XmlNode[] GetChildrenNodes(XmlNode node, string nodeName)
        {
            if (node == null || node.ChildNodes == null || node.ChildNodes.Count <= 0)
            {
                return new XmlNode[0];
            }
            List<XmlNode> nodeList = new List<XmlNode>(node.ChildNodes.Count);
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == nodeName)
                {
                    nodeList.Add(child);
                }
            }
            return nodeList.ToArray();
        }
    }
}
