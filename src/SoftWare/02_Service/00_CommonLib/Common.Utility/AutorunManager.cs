using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Common.Utility
{
    public class AutorunManager
    {
        private static readonly string s_XmlPath = GetAutorunXmlPath();

        public static void Startup(Action<Exception> errorHandler)
        {
            List<IStartup> list = GetModule<IStartup>(@"//autorun/startup", errorHandler);
            foreach (var m in list)
            {
                try
                {
                    m.Start();
                }
                catch (Exception ex)
                {
                    if (errorHandler != null)
                    {
                        errorHandler(ex);
                    }
                }
            }
        }

        public static void Shutdown(Action<Exception> errorHandler)
        {
            List<IShutdown> list = GetModule<IShutdown>(@"//autorun/shutdown", errorHandler);
            foreach (var m in list)
            {
                try
                {
                    m.Shut();
                }
                catch (Exception ex)
                {
                    if (errorHandler != null)
                    {
                        errorHandler(ex);
                    }
                }
            }
        }

        private static List<T> GetModule<T>(string xpath, Action<Exception> errorHandler)
        {
            if (!File.Exists(s_XmlPath))
            {
                return new List<T>(0);
            }
            XmlDocument x = new XmlDocument();
            x.Load(s_XmlPath);
            XmlNode node = x.SelectSingleNode(xpath);
            if (node == null || node.ChildNodes == null || node.ChildNodes.Count <= 0)
            {
                return new List<T>(0);
            }
            XmlNode[] mList = GetChildrenNodes(node, "module");
            if (mList == null || mList.Length <= 0)
            {
                return new List<T>(0);
            }
            List<T> rstList = new List<T>(mList.Length);
            foreach (var n in mList)
            {
                try
                {
                    string typeName = GetNodeAttribute(n, "type");
                    if (typeName == null || typeName.Trim().Length <= 0)
                    {
                        continue;
                    }
                    string[] argments;
                    XmlNodeList args = n.SelectNodes("constructor/arg");
                    if (args == null || args.Count <= 0)
                    {
                        argments = new string[0];
                    }
                    else
                    {
                        argments = new string[args.Count];
                        for (int i = 0; i < args.Count; i++)
                        {
                            string t = args[i].InnerText;
                            argments[i] = t == null ? null : t.Trim();
                        }
                    }
                    Type type = Type.GetType(typeName, true);
                    rstList.Add((T)CreateInstance(type, argments));
                }
                catch (Exception ex)
                {
                    if (errorHandler != null)
                    {
                        errorHandler(ex);
                    }
                }
            }
            return rstList;
        }

        private static string GetAutorunXmlPath()
        {
            string path = ConfigurationManager.AppSettings["AutorunConfigPath"];
            if (path == null || path.Trim().Length <= 0)
            {
                return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configuration/Autorun.config");
            }
            string p = Path.GetPathRoot(path);
            if (p == null || p.Trim().Length <= 0) // 说明是相对路径
            {
                path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
            }
            return path;
        }

        private static object CreateInstance(Type type, string[] args)
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
                catch(Exception ex)
                {
                    sb.AppendLine(j + ". " + ex.Message);
                }
                j++;
            }
            throw new ApplicationException("There are " + matched.Count + " matched constructor(s), but all failed to construct instance for type '" + type.AssemblyQualifiedName + "', detail error message: \r\n" + sb);
        }

        private static XmlNode[] GetChildrenNodes(XmlNode node, string nodeName)
        {
            return GetChildrenNodes(node, delegate(XmlNode child)
            {
                return child.Name == nodeName;
            });
        }

        private static XmlNode[] GetChildrenNodes(XmlNode node, Predicate<XmlNode> match)
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
    }

    public interface IStartup
    {
        void Start();
    }

    public interface IShutdown
    {
        void Shut();
    }
}
