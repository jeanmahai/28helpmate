using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Common.Utility
{
    internal class TxtEmitter : ILogEmitter
    {
        private static object s_SyncObject = new object();

        private static string m_LogFolderPath;

        public void Init(string configParam)
        {
            string folderPath = configParam;

            if (StringUtility.IsNullOrEmpty(folderPath))
            {
                m_LogFolderPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Log");
                return;
            }
            string p = Path.GetPathRoot(folderPath);
            if (p == null || p.Trim().Length <= 0) // 说明是相对路径
            {
                m_LogFolderPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, folderPath);
                return;
            }
            m_LogFolderPath = folderPath;
        }

        public void EmitLog(LogEntry log)
        {
            if (!Directory.Exists(m_LogFolderPath))
            {
                Directory.CreateDirectory(m_LogFolderPath);
            }

            WriteToFile(SerializationUtility.XmlSerialize(log),
                Path.Combine(m_LogFolderPath, DateTime.Now.ToString("yyyy-MM-dd") + ".txt"));
        }

        private static void WriteToFile(string log, string filePath)
        {
            lock (s_SyncObject)
            {
                log += "\r\n** ["+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"] **********************************************************************\r\n";
                byte[] textByte = System.Text.Encoding.UTF8.GetBytes(log);
                using (FileStream logStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Write))
                {
                    logStream.Write(textByte, 0, textByte.Length);
                }
            }
        }
    }
}
