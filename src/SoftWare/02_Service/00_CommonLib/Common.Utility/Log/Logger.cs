using System;
using System.Collections.Generic;

using System.Text;
using System.Messaging;
using System.Diagnostics;

namespace Common.Utility
{
    public static class Logger
    {
        private static void WriteEventLog(string source, string content, EventLogEntryType type)
        {
            try
            {
                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source, "ECCentral.Service");
                }
                using (EventLog errorLog = new EventLog())
                {
                    errorLog.Source = source;
                    errorLog.WriteEntry(content, type);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    using (EventLog log = new EventLog("Application", ".", "Common.Utility"))
                    {
                        log.WriteEntry(ex.ToString(), EventLogEntryType.Error);
                    }
                }
                catch
                {
                }
            }
        }

        private static string WriteLog(LogEntry log, List<ILogEmitter> logEmitterList)
        {
            if (logEmitterList == null || logEmitterList.Count <= 0)
            {
                return log.LogID;
            }
            try
            {
                log.CheckData();
                foreach (var logEmitter in logEmitterList)
                {
                    if (logEmitter == null)
                    {
                        continue;
                    }
                    try
                    {
                        logEmitter.EmitLog(log);
                    }
                    catch (Exception ex)
                    {
                        string message = string.Format("Write log failed.\r\n\r\n Error Info: {0}. \r\n\r\n Log Type: {1}. \r\n\r\n Log Info: {2}", ex.ToString(), logEmitter.GetType().AssemblyQualifiedName, SerializationUtility.XmlSerialize(log));
                        Logger.WriteEventLog("Common.Utility_LoggingComponent", message, EventLogEntryType.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                string message = string.Format("Write log failed.\r\n\r\n Error Info: {0}. \r\n\r\n Log Info: {1}", ex.ToString(), SerializationUtility.XmlSerialize(log));
                Logger.WriteEventLog("Common.Utility_LoggingComponent", message, EventLogEntryType.Error);
            }

            return log.LogID;
        }

        internal static string WriteLog(LogEntry log)
        {
            return WriteLog(log, EmitterFactory.Create());
        }

        public static string WriteLog(string content, string category)
        {
            return WriteLog(content, category, null, null);
        }

        public static string WriteLog(string content, string category, string referenceKey)
        {
            return WriteLog(content, category, referenceKey, null);
        }

        public static string WriteLog(string content, string category, string referenceKey, List<ExtendedPropertyData> extendedProperties)
        {
            LogEntry log = new LogEntry();
            log.Category = category;
            log.Content = content;
            log.ReferenceKey = referenceKey;
            log.ExtendedProperties = extendedProperties;
            return WriteLog(log);
        }
        
    }
}