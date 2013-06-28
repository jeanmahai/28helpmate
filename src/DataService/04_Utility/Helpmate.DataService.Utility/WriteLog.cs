using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Helpmate.DataService.Utility
{
    public class WriteLog
    {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log">日志内容</param>
        public static void Write(string log)
        {
            string path = string.Format("{0}\\log\\SvcLog_{1}", AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToShortDateString());
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            string logMessage = string.Format("{0}：{1}", DateTime.Now.ToString(), log);
            FileStream fs = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(logMessage + "\r\n");
            sw.Close();
            sw.Dispose();
        }

        /// <summary>
        /// 写系统消息日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="messageType">消息类型</param>
        public static void WriteEventLog(string message, EventLogEntryType messageType)
        {
            EventLog.WriteEntry(GetConfig.GetXMLValue("ServiceName"), message, messageType);
        }
    }
}
