using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Utility
{
    public static class Subscription<T> where T : IEventMessage
    {
        private static List<IConsumer<T>> s_Subscribers = new List<IConsumer<T>>();
        private static object s_SyncObj = new object();

        internal static List<IConsumer<T>> GetSubscribers()
        {
            return new List<IConsumer<T>>(s_Subscribers);
        }

        public static void AddSubscriber(IConsumer<T> subscriber)
        {
            if (!s_Subscribers.Contains(subscriber))
            {
                lock (s_SyncObj)
                {
                    if (!s_Subscribers.Contains(subscriber))
                    {
                        s_Subscribers.Add(subscriber);
                    }
                }
            }
        }
    }
}
