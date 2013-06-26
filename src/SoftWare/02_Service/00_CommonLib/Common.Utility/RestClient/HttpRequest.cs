using System;
using System.Net;
using System.IO;

namespace Common.Utility
{
    internal class HttpRequest
    {
        protected HttpWebRequest m_request;

        public string Accept
        {
            get
            {
                return m_request.Accept;
            }
            set
            {
                m_request.Accept = value;
            }
        }

        public bool AllowWriteStreamBuffering
        {
            get
            {
                return m_request.AllowWriteStreamBuffering;
            }

            set
            {
                m_request.AllowWriteStreamBuffering = value;
            }
        }

        public string ContentType
        {
            get
            {
                return m_request.ContentType;
            }

            set
            {
                m_request.ContentType = value;
            }
        }

        public CookieContainer CookieContainer
        {
            get
            {
                return m_request.CookieContainer;
            }
            set
            {
                m_request.CookieContainer = value;
            }
        }

        public bool HaveResponse
        {
            get
            {
                return m_request.HaveResponse;
            }

        }

        public int Timeout
        {
            get
            {
                return m_request.Timeout;
            }
            set
            {
                m_request.Timeout = value;
            }
        }

        public WebHeaderCollection Headers
        {
            get
            {
                return m_request.Headers;
            }
            set
            {
                m_request.Headers = value;
            }
        }

        public string Method
        {
            get
            {
                return m_request.Method;
            }
            internal set
            {
                m_request.Method = value;
            }
        }

        public Uri RequestUri
        {
            get
            {
                return m_request.RequestUri;
            }
        }

        public long ContentLength
        {
            get
            {
                return m_request.ContentLength;
            }
            set
            {
                m_request.ContentLength = value;
            }
        }

        public ICredentials Credentials
        {
            get
            {
                return m_request.Credentials;
            }
            set
            {
                m_request.Credentials = value;
            }
        }

        public bool UseDefaultCredentials
        {
            get
            {
                return m_request.UseDefaultCredentials;
            }
            set
            {
                m_request.UseDefaultCredentials = value;
            }
        }

        public HttpRequest(string url)
            : this(url, ContentTypes.Json, ContentTypes.Json)
        {
        }

        public HttpRequest(string url, string accpetType, string contentType)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            m_request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            m_request.Method = Operating.GET;
            m_request.Accept = accpetType;
            m_request.ContentType = contentType;
        }

        internal Stream GetRequestStream()
        {
            return m_request.GetRequestStream();
        }

        internal WebResponse GetResponse()
        {
            return m_request.GetResponse();
        }

        internal IAsyncResult BeginGetRequestStream(AsyncCallback callback, object state)
        {
            return m_request.BeginGetRequestStream(callback, state);
        }

        internal IAsyncResult BeginGetResponse(AsyncCallback callback, object state)
        {
            return m_request.BeginGetResponse(callback, state);
        }

        internal Stream EndGetRequestStream(IAsyncResult asyncResult)
        {
            return m_request.EndGetRequestStream(asyncResult);
        }

        internal WebResponse EndGetResponse(IAsyncResult asyncResult)
        {
            return m_request.EndGetResponse(asyncResult);
        }

        internal void Abort()
        {
            m_request.Abort();
        }
    }
}
