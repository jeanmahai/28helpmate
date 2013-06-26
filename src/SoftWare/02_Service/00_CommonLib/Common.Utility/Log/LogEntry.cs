using System;
using System.Collections.Generic;

using System.Text;
using System.Net;

namespace Common.Utility
{
    [Serializable]
    public class LogEntry
    {
        public LogEntry()
        {
            m_LogID = Guid.NewGuid().ToString();
            LogSetting s = LogSection.GetSetting();
            if (s != null)
            {
                LocalName = s.LocalRegionName == null ? null : s.LocalRegionName.Trim();
                GlobalName = s.GlobalRegionName == null ? null : s.GlobalRegionName.Trim();
            }
        }


        internal void CheckData()
        {
            if (string.IsNullOrEmpty(GlobalName))
            {
                throw new ArgumentNullException(GlobalName, "Global Name is required");
            }
            if (string.IsNullOrEmpty(LocalName))
            {
                throw new ArgumentNullException(LocalName, "Local Name is required, please check your app.config");
            }
        }

        private string m_LogID;

        public string LogID
        {
            get
            {
                return m_LogID;
            }
        }

        public string GlobalName { get; set; }

        public string LocalName { get; set; }

        public string Content { get; set; }

        public string LogUserName { get; set; }

        public string Category { get; set; }

        private static string m_LogServerIP;

        internal string LogServerIP
        {
            get
            {
                if (string.IsNullOrEmpty(m_LogServerIP))
                {
                    IPAddress[] address = Dns.GetHostEntry(LogServerName).AddressList;
                    if (address != null)
                    {
                        foreach (IPAddress addr in address)
                        {
                            //过滤IPv6的地址信息
                            if (addr.ToString().Length <= 16 && addr.ToString().Length > 5)
                            {
                                m_LogServerIP = addr.ToString();
                                break;
                            }
                        }
                    }
                }
                return m_LogServerIP;
            }
        }


        internal string LogServerName
        {
            get
            {
                return Dns.GetHostName();
            }
        }

        private List<ExtendedPropertyData> extendedProperties;

        public List<ExtendedPropertyData> ExtendedProperties
        {
            get
            {
                if (extendedProperties == null)
                {
                    extendedProperties = new List<ExtendedPropertyData>();
                }
                return extendedProperties;
            }
            set
            {
                extendedProperties = value;
            }
        }

        public void AddExtendedProperty(string propertyName, object propertyValue)
        {
            ExtendedProperties.Add(new ExtendedPropertyData(propertyName, propertyValue));
        }

        public string ReferenceKey { get; set; }
    }

    [Serializable]
    public class ExtendedPropertyData
    {
        public string PropertyName { get; set; }

        public object PropertyValue { get; set; }

        internal string GetPropertyValue()
        {
            if(PropertyValue == null)
            {
                return "NULL";
            }
            else if (PropertyValue is string)
            {
                return Convert.ToString(PropertyValue).Replace("]]>", "]] >");
            }
            else if (PropertyValue.GetType().IsPrimitive)
            {
                return PropertyValue.ToString();
            }
            else
            {
                return SerializationUtility.XmlSerialize(PropertyValue);
            }
        }

        public ExtendedPropertyData()
        {
        }

        public ExtendedPropertyData(string propertyName, object propertyValue)
        {
            this.PropertyName = propertyName;
            this.PropertyValue = propertyValue;
        }
    }
}