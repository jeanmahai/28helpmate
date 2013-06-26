using System;
using System.Collections.Generic;
using System.Threading;

namespace Common.Utility
{
    public interface IQueue<T>
    {
        void Enqueue(T msg);

        T Dequeue();
    }

    internal class QueueManager<T>
    {
        private IQueue<T> m_Queue;
        private Action<List<T>> m_QueueItemHandler;
        private int m_BufferLength;
        // 设定的最大的取队列线程数量
        private int m_DequeueThreadMaxAmount;
        private Action<Exception> m_ExceptionHandler;
        public QueueManager(IQueue<T> queue, Action<List<T>> queueItemHandler = null, int itemCountPerBatchToHandle = 256,
            int dequeueThreadAmountMaxLimit = 5, Action<Exception> exceptionHandler = null)
        {
            m_Queue = queue;
            m_QueueItemHandler = queueItemHandler;
            m_BufferLength = itemCountPerBatchToHandle;
            m_DequeueThreadMaxAmount = dequeueThreadAmountMaxLimit;
            m_ExceptionHandler = exceptionHandler;
        }

        #region 信号量

        // 当前正在执行取队列的线程数量
        private int m_CurrentDequeueThreadAmount = 0;
        // 一个信号量，表示是否有新数据进入队列（0为无，1为有）
        private int m_HasNewMessage = 0;
        // 轮询监视s_HasNewMessage这个信号量的线程，
        // 当s_HasNewMessage为1时，该线程会重置
        // s_HasNewMessage为0，并向CLR线程池扔进一
        // 个取队列的任务（但如果s_CurrentDequeueThreadAmount
        // 已经等于s_DequeueThreadMaxAmount时则不会再扔）；
        // 该引用本身是否为null也是该引用所指向的线程和CLR线程池
        // 中各个执行取队列的任务是否停止的信号量
        private Thread m_NewMessageWatcher = null;

        #endregion

        // 线程安全的
        public void Enqueue(T msg, bool startAutoDequeue = true)
        {
            if (startAutoDequeue)
            {
                StartNewMessageWatcher();
            }
            m_Queue.Enqueue(msg);
            Interlocked.Exchange(ref m_HasNewMessage, 1);
        }

        // 线程安全的
        public void StopDequeue()
        {
            Thread thread = Interlocked.Exchange(ref m_NewMessageWatcher, null);
            if (null != thread)
            {
                thread.Join();
            }
        }

        #region Private Method

        private void StartNewMessageWatcher()
        {
            if (null != Interlocked.CompareExchange<Thread>(ref m_NewMessageWatcher, null, null))
            {
                return;
            }
            Thread thread = new Thread(o =>
            {
                int times = 0;
                while (m_NewMessageWatcher != null)
                {
                    times++;
                    if (1 == Interlocked.Exchange(ref m_HasNewMessage, 0) || times >= 60000) // 600 seconds
                    {
                        ReadQueue();
                        times = 0;
                    }
                    Thread.Sleep(10);
                }
            });
            if (null != Interlocked.CompareExchange<Thread>(ref m_NewMessageWatcher, thread, null))
            {
                return;
            }
            thread.Start();
        }

        private void ReadQueue()
        {
            int initialValue;
            int computedValue;
            do
            {
                initialValue = m_CurrentDequeueThreadAmount;
                computedValue = initialValue + 1;
                if (computedValue > m_DequeueThreadMaxAmount)
                {
                    computedValue = m_DequeueThreadMaxAmount;
                }
            }
            while (initialValue != Interlocked.CompareExchange(ref m_CurrentDequeueThreadAmount, computedValue, initialValue));
            if (initialValue == computedValue)
            {
                return;
            }

            ThreadPool.QueueUserWorkItem(new WaitCallback(o =>
            {
                try
                {
                    int len = m_BufferLength;
                    List<T> list = new List<T>(len);
                    do
                    {
                        T msg = m_Queue.Dequeue();
                        if (msg == null)
                        {
                            SaveMessages(list);
                            return;
                        }
                        list.Add(msg);
                        if (list.Count >= len)
                        {
                            SaveMessages(list);
                            list.Clear();
                        }
                    } while (m_NewMessageWatcher != null);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
                finally
                {
                    Interlocked.Decrement(ref m_CurrentDequeueThreadAmount);
                }
            }));
        }

        private void SaveMessages(List<T> list)
        {
            if (m_QueueItemHandler != null && list != null && list.Count > 0)
            {
                m_QueueItemHandler(list);
            }
        }

        private void HandleException(Exception ex)
        {
            if (m_ExceptionHandler != null && ex != null)
            {
                m_ExceptionHandler(ex);
            }
        }

        #endregion
    }
}
