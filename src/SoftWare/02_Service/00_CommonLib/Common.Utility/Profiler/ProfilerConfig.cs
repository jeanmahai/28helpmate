using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Collections;

namespace Common.Utility
{
    internal static class ProfilerConfig
    {
        private static Hashtable s_Profiler = ConfigurationManager.GetSection("profiler") as Hashtable;

        private static bool? s_Disabled;
        public static bool Disabled // 不需要加锁，因为即使多线程时发生了并发冲突也不会有问题，加锁反而带来更大的性能开销
        {
            get
            {
                if (s_Disabled == null)
                {
                    string str = GetValue("disabled");
                    bool dis;
                    if (str != null && str.Trim().Length > 0 && bool.TryParse(str, out dis))
                    {
                        s_Disabled = dis;
                    }
                    else
                    {
                        s_Disabled = false;
                    }
                }
                return s_Disabled.Value;
            }
        }

        private static string m_ServerIP;
        public static string GetServerIP() // 不需要加锁，因为即使多线程时发生了并发冲突也不会有问题，加锁反而带来更大的性能开销
        {
            if (m_ServerIP == null)
            {
                IPAddress ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(i => i.AddressFamily == AddressFamily.InterNetwork);
                m_ServerIP = ip.ToString();
            }
            return m_ServerIP;
        }

        public static string GetValue(string key)
        {
            if (s_Profiler == null || !s_Profiler.Contains(key))
            {
                return null;
            }
            return s_Profiler[key].ToString();
        }

        private static string m_AppID;
        public static string GetAppID() // 不需要加锁，因为即使多线程时发生了并发冲突也不会有问题，加锁反而带来更大的性能开销
        {
            if (m_AppID == null)
            {
                if (s_Profiler == null || !s_Profiler.Contains("appID"))
                {
                    m_AppID = string.Empty;
                }
                else
                {
                    object tmp = s_Profiler["appID"];
                    m_AppID = (tmp == null) ? string.Empty : tmp.ToString().Trim();
                }
            }
            return m_AppID;
        }

        public static int GetPersistBatchSize()  // 不需要加锁，因为只会被单线程调用一次（静态构造）
        {
            const int DEFAULT_VALUE = 128;
            if (s_Profiler == null || !s_Profiler.Contains("batchSize"))
            {
                return DEFAULT_VALUE; // default value
            }
            else
            {
                object tmp = s_Profiler["batchSize"];
                int size;
                if (tmp != null && int.TryParse(tmp.ToString().Trim(), out size) && size > 0)
                {
                    return size;
                }
                else
                {
                    return DEFAULT_VALUE;
                }
            }
        }

        public static int GetDequeueThreadMaxAmount()  // 不需要加锁，因为只会被单线程调用一次（静态构造）
        {
            const int DEFAULT_VALUE = 5;
            if (s_Profiler == null || !s_Profiler.Contains("dequeueConcurrentMaxLimit"))
            {
                return DEFAULT_VALUE; // default value
            }
            else
            {
                object tmp = s_Profiler["dequeueConcurrentMaxLimit"];
                int size;
                if (tmp != null && int.TryParse(tmp.ToString().Trim(), out size) && size > 0)
                {
                    return size;
                }
                else
                {
                    return DEFAULT_VALUE;
                }
            }
        }

        public static IQueue<ProfilerMessage> GetQueue()  // 不需要加锁，因为只会被单线程调用一次（静态构造）
        {
            int _capacity = 10240;
            if (s_Profiler == null)
            {
                return new ThreadSafetyQueue<ProfilerMessage>(_capacity);
            }
            if (s_Profiler.Contains("boundedCapacity"))
            {
                object tmp = s_Profiler["boundedCapacity"];
                int size;
                if (tmp != null && int.TryParse(tmp.ToString().Trim(), out size) && size > 0)
                {
                    _capacity = size;
                }
            }

            if (!s_Profiler.Contains("queueType"))
            {
                return new ThreadSafetyQueue<ProfilerMessage>(_capacity);
            }
            object queueType = s_Profiler["queueType"];
            if (queueType == null || queueType.ToString().Trim().Length <= 0)
            {
                return new ThreadSafetyQueue<ProfilerMessage>(_capacity);
            }
            Type p = Type.GetType(queueType.ToString().Trim(), true);
            return (IQueue<ProfilerMessage>)Activator.CreateInstance(p);
        }
    }
}
