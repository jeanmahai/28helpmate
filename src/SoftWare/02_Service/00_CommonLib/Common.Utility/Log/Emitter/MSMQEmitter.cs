using System;
using System.Collections.Generic;

using System.Text;
using System.Messaging;

namespace Common.Utility
{
    internal class MSMQEmitter : ILogEmitter
    {
        private string[] m_Queues;

        public void Init(string configParam)
        {
            m_Queues = configParam.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private MessageQueue CreateSendQueue()
        {
            int idx;
            if (m_Queues.Length == 1)
            {
                idx = 0;
            }
            else
            {
                idx = new Random(DateTime.Now.Millisecond).Next(0, m_Queues.Length);                    
            }
            return new MessageQueue(m_Queues[idx]);  
        }

        internal string BuildMSMQMessage(LogEntry log)
        {
            StringBuilder sb = new StringBuilder(500);
            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sb.Append("<Log>");
                    sb.Append("<Body>");
                        sb.AppendFormat("<Category>{0}</Category>", log.Category);
                        if (log.Content != null)
                        {
                            sb.AppendFormat("<Content><![CDATA[{0}]]></Content>", log.Content.Replace("]]>", "]] >"));
                        }
                        sb.AppendFormat("<GlobalName>{0}</GlobalName>", log.GlobalName);
                        sb.AppendFormat("<LogID>{0}</LogID>", log.LogID);
                        sb.AppendFormat("<LocalName>{0}</LocalName>", log.LocalName);
                        sb.AppendFormat("<LogServerIP>{0}</LogServerIP>", log.LogServerIP);
                        sb.AppendFormat("<LogServerName>{0}</LogServerName>", log.LogServerName);
                        if (!string.IsNullOrEmpty(log.LogUserName))
                        {
                            sb.AppendFormat("<LogUserName><![CDATA[{0}]]></LogUserName>", log.LogUserName);
                        }
                        if (!string.IsNullOrEmpty(log.ReferenceKey))
                        {
                            sb.AppendFormat("<ReferenceKey><![CDATA[{0}]]></ReferenceKey>", log.ReferenceKey);
                        }
                        if (log.ExtendedProperties != null && log.ExtendedProperties.Count > 0)
                        {
                            sb.Append("<ExtendedData>");   
                            sb.Append("<ExtendedProperties>");                           
                            foreach (ExtendedPropertyData data in log.ExtendedProperties)
                            {
                                sb.Append("<ExtendedPropertyData>");
                                sb.AppendFormat("<PropertyName>{0}</PropertyName>", data.PropertyName);
                                sb.AppendFormat("<PropertyValue><![CDATA[{0}]]></PropertyValue>", data.GetPropertyValue());
                                sb.Append("</ExtendedPropertyData>");
                            }
                            sb.Append("</ExtendedProperties>");
                            sb.Append("</ExtendedData>");   
                        }
                    sb.Append("</Body>");
                sb.Append("</Log>");
            return sb.ToString();
        }

        public void EmitLog(LogEntry log)
        {
            RetryHelper helper = new RetryHelper(10, 0.05);
            helper.Retry(() =>
            {
                using (MessageQueue sendQueue = CreateSendQueue())
                {
                    sendQueue.Send(BuildMSMQMessage(log));
                    sendQueue.Close();
                }
            });
        }

    }
}
