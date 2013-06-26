using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services.Description;

namespace Common.Utility
{
    internal class WebServiceEmitter : ILogEmitter
    {
        private string[] m_ServiceAddress;

        public void Init(string configParam)
        {
            m_ServiceAddress = configParam.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public void EmitLog(LogEntry log)
        {
            LogEntryContract msg = new LogEntryContract();
            msg.Body = new LogEntryBody();
            msg.Body.CategoryName = log.Category;
            msg.Body.Content = log.Content;
            msg.Body.GlobalName = log.GlobalName;
            msg.Body.ID = log.LogID;
            msg.Body.LocalName = log.LocalName;
            msg.Body.LogServerIP = log.LogServerIP;
            msg.Body.LogServerName = log.LogServerName;
            msg.Body.LogUserName = log.LogUserName;
            msg.Body.ReferenceKey = log.ReferenceKey;
            if (log.ExtendedProperties != null && log.ExtendedProperties.Count > 0)
            {
                ArrayOfKeyValueOfstringstringKeyValueOfstringstring[] pp = new ArrayOfKeyValueOfstringstringKeyValueOfstringstring[log.ExtendedProperties.Count];
                for (int i = 0; i < log.ExtendedProperties.Count; i++)
                {
                    pp[i] = new ArrayOfKeyValueOfstringstringKeyValueOfstringstring();
                    pp[i].Key = log.ExtendedProperties[i].PropertyName;
                    pp[i].Value = log.ExtendedProperties[i].GetPropertyValue();
                }
                msg.Body.ExtendedProperties = pp;
            }

            for (int i = 0; i < m_ServiceAddress.Length; i++)
            {                               
                LogService service = new LogService();
                service.Url = m_ServiceAddress[i];

                try
                {
                    RetryHelper helper = new RetryHelper(3, 0.05);
                    helper.Retry(() =>
                    {
                        service.LogAsync(msg);
                    });
                    break;
                }
                catch
                {
                    if (i == m_ServiceAddress.Length-1)
                    {
                        throw;
                    }                  
                }
            }

        }
    }
}
