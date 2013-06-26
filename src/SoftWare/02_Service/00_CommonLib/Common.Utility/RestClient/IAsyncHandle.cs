using System;
using System.Net;
using System.Threading;

namespace Common.Utility
{
    public interface IAsyncHandle : IAsyncResult
    {
        void Abort();
    }

    internal class RestClientAsyncHandle : IAsyncHandle
    {
        private HttpRequest m_request;
        private IAsyncResult m_AsyncResult;

        public RestClientAsyncHandle(HttpRequest request, IAsyncResult handler)
        {
            m_request = request;
            m_AsyncResult = handler;
        }

        public void Abort()
        {
            if (m_request != null)
            {
                m_request.Abort();
            }
        }

        public object AsyncState
        {
            get { return m_AsyncResult.AsyncState; }
        }

        public WaitHandle AsyncWaitHandle
        {
            get { return m_AsyncResult.AsyncWaitHandle; }
        }

        public bool CompletedSynchronously
        {
            get { return m_AsyncResult.CompletedSynchronously; }
        }

        public bool IsCompleted
        {
            get { return m_AsyncResult.IsCompleted; }
        }
    }
}
