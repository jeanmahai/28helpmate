using System.Threading;

namespace Common.Utility
{
    internal class ThreadSafetyQueue<T> : IQueue<T>
    {
        private int m_BoundedCapacity;
        private ThreadSafetyQueueItem<T>[] m_MessageList;
        private int m_EnqueueIndex = -1;
        private int m_DequeueIndex = -1;

        public ThreadSafetyQueue(int boundedCapacity)
        {
            m_BoundedCapacity = boundedCapacity;
            m_MessageList = new ThreadSafetyQueueItem<T>[boundedCapacity];
        }
        
        // thread safe
        public void Enqueue(T msg)
        {            
            int initialValue;
            int computedValue;
            do
            {
                // Save the current running 's_Index' in a local variable.
                initialValue = m_EnqueueIndex;

                // compute the new value and stored it into the local variable 'computedValue'.
                computedValue = initialValue + 1;
                if (computedValue >= m_MessageList.Length)
                {
                    computedValue = 0;
                }

                // CompareExchange compares 's_Index' to 'initialValue'. If
                // they are not equal, then another thread has updated the
                // running 's_Index' since this loop started. CompareExchange
                // does not update 's_Index'. CompareExchange returns the
                // contents of 's_Index', which do not equal 'initialValue',
                // so the loop executes again.
            }
            while (initialValue != Interlocked.CompareExchange(ref m_EnqueueIndex, computedValue, initialValue));
            // If no other thread updated the running 's_Index', then 
            // 's_Index' and 'initialValue' are equal when CompareExchange
            // compares them, and 'computedValue' is stored in 's_Index'.
            // CompareExchange returns the value that was in 's_Index'
            // before the update, which is equal to initialValue, so the 
            // loop ends.
            m_MessageList[computedValue] = new ThreadSafetyQueueItem<T>() { Data=msg, HasDequeued=false };
        }

        // thread safe
        public T Dequeue()
        {
            int initialValue;
            int computedValue;
            ThreadSafetyQueueItem<T> msg;
            do
            {
                initialValue = m_DequeueIndex;
                computedValue = initialValue + 1;
                if (computedValue >= m_MessageList.Length)
                {
                    computedValue = 0;
                }
                msg = m_MessageList[computedValue];
                // there is a bug : the thread may exit advanced when queue
                // is not empty, because there is another thread just
                // modify the current 'msg.HasDequeued' to true.
                if (msg == null || msg.HasDequeued)
                {
                    return default(T);
                }
            }
            while (initialValue != Interlocked.CompareExchange(ref m_DequeueIndex, computedValue, initialValue));
            msg.HasDequeued = true;
            return msg.Data;
        }
    }

    internal class ThreadSafetyQueueItem<T>
    {
        public bool HasDequeued { get; set; }
        public T Data { get; set; }
    }
}