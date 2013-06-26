using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace Common.Utility
{
    public static class EmitterFactory
    {
        private static List<ILogEmitter> s_Emitters = null;
        private static object s_SyncObj = new object();

        public static List<ILogEmitter> Create()
        {
            if (s_Emitters == null)
            {
                lock (s_SyncObj)
                {
                    if (s_Emitters == null)
                    {
                        LogSetting s = LogSection.GetSetting();
                        List<ILogEmitter> list = new List<ILogEmitter>();
                        if (s.WebServiceParam != null && s.WebServiceParam.Trim().Length > 0)
                        {
                            ILogEmitter e = new WebServiceEmitter();
                            e.Init(s.WebServiceParam);
                            list.Add(e);
                        }
                        if (s.TextParam != null && s.TextParam.Trim().Length > 0)
                        {
                            ILogEmitter e = new TxtEmitter();
                            e.Init(s.TextParam);
                            list.Add(e);
                        }
                        if (s.MsmqParam != null && s.MsmqParam.Trim().Length > 0)
                        {
                            ILogEmitter e = new MSMQEmitter();
                            e.Init(s.MsmqParam);
                            list.Add(e);
                        }
                        if (s.CustomParam != null && s.CustomParam.Count > 0)
                        {
                            foreach (var entry in s.CustomParam)
                            {
                                ILogEmitter e = (ILogEmitter)Activator.CreateInstance(entry.Key);
                                e.Init(entry.Value);
                                list.Add(e);
                            }
                        }
                        if (list.Count <= 0)
                        {
                            ILogEmitter e = new TxtEmitter();
                            e.Init(null);
                            list.Add(e);
                        }
                        s_Emitters = list;
                    }
                }
            }
            return s_Emitters;
        }
    }
}