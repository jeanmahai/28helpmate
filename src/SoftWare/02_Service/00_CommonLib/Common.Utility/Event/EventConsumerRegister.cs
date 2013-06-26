using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Reflection;

namespace Common.Utility
{
    public class EventConsumerRegister : IStartup
    {
        public void Start()
        {
            string path = GetConfigPath();
            if (!File.Exists(path))
            {
                return;
            }
            XmlDocument x = new XmlDocument();
            x.Load(path);
            XmlNode node = x.SelectSingleNode(@"//subscription");
            if (node == null || node.ChildNodes == null || node.ChildNodes.Count <= 0)
            {
                return;
            }
            XmlNode[] eventList = GetChildrenNodes(node, "event");
            foreach (XmlNode ev in eventList)
            {
                string eventTypeStr = GetNodeAttribute(ev, "type");
                if (string.IsNullOrWhiteSpace(eventTypeStr))
                {
                    continue;
                }
                Type eventType = Type.GetType(eventTypeStr, false);
                if (eventType == null || !typeof(IEventMessage).IsAssignableFrom(eventType))
                {
                    continue;
                }
                XmlNode[] consumerList = GetChildrenNodes(ev, "consumer");
                if (consumerList == null || consumerList.Length <= 0)
                {
                    continue;
                }

                Type consumerBaseType = typeof(IConsumer<>).MakeGenericType(eventType);
                MethodInfo method = typeof(Subscription<>).MakeGenericType(eventType).GetMethod("AddSubscriber", BindingFlags.Static | BindingFlags.Public);
                foreach (XmlNode consumer in consumerList)
                {
                    string consumerTypeStr = GetNodeAttribute(consumer, "type");
                    if (string.IsNullOrWhiteSpace(consumerTypeStr))
                    {
                        continue;
                    }
                    Type consumerType = Type.GetType(consumerTypeStr, false);
                    if (consumerType == null || !consumerBaseType.IsAssignableFrom(consumerType))
                    {
                        continue;
                    }
                    string[] argments;
                    XmlNodeList args = consumer.SelectNodes("constructor/arg");
                    if (args == null || args.Count <= 0)
                    {
                        argments = new string[0];
                    }
                    else
                    {
                        argments = new string[args.Count];
                        for (int i = 0; i < args.Count; i++)
                        {
                            string x1 = args[i].InnerText;
                            argments[i] = x1 == null ? null : x1.Trim();
                        }
                    }
                    object obj = CreateInstance(consumerType, argments);
                    method.Invoke(null, new object[] { obj });
                }
            }
        }

        private object CreateInstance(Type type, string[] args)
        {
            ConstructorInfo[] infoArray = type.GetConstructors();
            List<ParameterInfo[]> matched = new List<ParameterInfo[]>(infoArray.Length);
            foreach (var con in infoArray)
            {
                ParameterInfo[] pArray = con.GetParameters();
                if (pArray.Length == args.Length)
                {
                    matched.Add(pArray);
                }
            }
            if (matched.Count <= 0)
            {
                throw new ApplicationException("Can't find the constructor with " + args.Length + " parameter(s) of type '" + type.AssemblyQualifiedName + "'");
            }
            StringBuilder sb = new StringBuilder();
            int j = 1;
            foreach (var paramArray in matched)
            {
                try
                {
                    object[] realArgs = new object[paramArray.Length];
                    for (int i = 0; i < paramArray.Length; i++)
                    {
                        realArgs[i] = DataConvertor.GetValueByType(paramArray[i].ParameterType, args[i], null, null);
                    }
                    return Activator.CreateInstance(type, realArgs);
                }
                catch (Exception ex)
                {
                    sb.AppendLine(j + ". " + ex.Message);
                }
                j++;
            }
            throw new ApplicationException("There are " + matched.Count + " matched constructor(s), but all failed to construct instance for type '" + type.AssemblyQualifiedName + "', detail error message: \r\n" + sb);
        }

        private string GetConfigPath()
        {
            string path = ConfigurationManager.AppSettings["EventConsumerConfigFilePath"];
            if (path == null || path.Trim().Length <= 0)
            {
                return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configuration/EventConsumer.config");
            }
            string p = Path.GetPathRoot(path);
            if (p == null || p.Trim().Length <= 0) // 说明是相对路径
            {
                path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
            }
            return path;
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
    }
}
