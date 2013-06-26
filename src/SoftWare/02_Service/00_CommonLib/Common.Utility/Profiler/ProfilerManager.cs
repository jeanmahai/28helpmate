using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Utility
{
    public static class ProfilerManager
    {
        private static QueueManager<ProfilerMessage> s_QueueManager = new QueueManager<ProfilerMessage>(
            ProfilerConfig.GetQueue(), HandleQueueItem,
            ProfilerConfig.GetPersistBatchSize(), ProfilerConfig.GetDequeueThreadMaxAmount(), HandleException);

        private static Action<List<ProfilerMessage>> m_QueueItemHandler = null;

        private static Action<Exception> m_ExceptionHandler = null;

        public static Action<List<ProfilerMessage>> QueueItemHandler
        {
            set { ProfilerManager.m_QueueItemHandler = value; }
        }

        public static Action<Exception> ExceptionHandler
        {
            set { ProfilerManager.m_ExceptionHandler = value; }
        }

        public static void StopDequeue()
        {
            s_QueueManager.StopDequeue();
        }

        internal static void Enqueue(ProfilerMessage msg)
        {
            s_QueueManager.Enqueue(msg, true);
        }

        private static void HandleException(Exception ex)
        {
            var handler = m_ExceptionHandler;
            if (handler != null)
            {
                handler(ex);
            }
        }

        private static void HandleQueueItem(List<ProfilerMessage> list)
        {
            var handler = m_QueueItemHandler;
            if (handler != null)
            {
                handler(list);
            }
        }
    }
}
