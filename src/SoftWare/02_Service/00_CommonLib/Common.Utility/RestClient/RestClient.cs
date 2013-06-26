using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;

namespace Common.Utility
{
    public class RestClient
    {
        private const string SIGN_KEY = "ds@H73d12Jds%dN&2#";

        private static int m_UserSysNo;

        private static string m_UserAcct;

        private string m_ServicePath;

        private string m_LanguageCode = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;

        private class AsyncArgs<T>
        {
            public Action<RestServiceError> ErrorHandler
            {
                get;
                private set;
            }
            public Action<T> SucceedHandler
            {
                get;
                private set;
            }
            public HttpRequest Request
            {
                get;
                private set;
            }
            public bool IsDynamic
            {
                get;
                private set;
            }

            public AsyncArgs(HttpRequest request, Action<T> succeedHandler, Action<RestServiceError> errorHandler, bool isDynamic)
            {
                IsDynamic = isDynamic;
                Request = request;
                SucceedHandler = succeedHandler;
                ErrorHandler = errorHandler;
            }
        }

        public string ContentType
        {
            get;
            set;
        }

        public int? Timeout
        {
            get;
            set;
        }

        public RestClient(string servicPath)
        {
            string no = ConfigurationManager.AppSettings["UserSysNo"];
            int userSysNo;
            if (no == null || no.Trim().Length <= 0 || !int.TryParse(no, out userSysNo) || userSysNo <= 0)
            {
                throw new ApplicationException("There are some errors with the appSettings configuration of 'UserSysNo' in configuration file '" + AppDomain.CurrentDomain.SetupInformation.ConfigurationFile + "'");
            }
            string acct = ConfigurationManager.AppSettings["UserAcct"];
            if (acct == null || acct.Trim().Length <= 0)
            {
                throw new ApplicationException("There are some errors with the appSettings configuration of 'UserAcct' in configuration file '" + AppDomain.CurrentDomain.SetupInformation.ConfigurationFile + "'");
            }
            ContentType = ContentTypes.Json;
            m_ServicePath = servicPath;
            m_UserSysNo = userSysNo;
            m_UserAcct = acct;
        }

        public RestClient(string servicPath, string languageCode)
            : this(servicPath)
        {
            if (!string.IsNullOrEmpty(languageCode))
            {
                m_LanguageCode = languageCode;
            }
        }

        public RestClient(string servicPath, int userSysNo, string userAcct)
        {
            if (userSysNo <= 0)
            {
                throw new ArgumentException("Invalid UserSysNo", "userSysNo");
            }
            if (userAcct == null || userAcct.Trim().Length <= 0)
            {
                throw new ArgumentNullException("userAcct");
            }
            ContentType = ContentTypes.Json;
            m_ServicePath = servicPath;
            m_UserSysNo = userSysNo;
            m_UserAcct = userAcct;
        }

        public RestClient(string servicPath, int userSysNo, string userAcct, string languageCode)
            : this(servicPath, userSysNo, userAcct)
        {
            if (!string.IsNullOrEmpty(languageCode))
            {
                m_LanguageCode = languageCode;
            }
        }

        public static void RegisterSerializer(string serializerName, ISerializer serializer)
        {
            SerializerFactory.Register(serializerName, serializer);
        }

        internal string SignParameters(string userSysNo, string userAcct, string hour)
        {
            byte[] array = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(userSysNo + m_UserAcct + hour + SIGN_KEY));
            return Convert.ToBase64String(array);
        }

        private void HandlePostRequestHeader(HttpRequest request, string operating)
        {
            if (operating != Operating.POST)
            {
                request.Headers["X-Http-Method-Override"] = operating;
            }
            string hour = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).Hours.ToString();
            string sign = SignParameters(m_UserSysNo.ToString(), m_UserAcct, hour);

            request.Headers["X-Accept-Language-Override"] = m_LanguageCode;
            request.Headers["X-User-SysNo"] = m_UserSysNo.ToString();
            request.Headers["X-User-Acct"] = m_UserAcct;
            request.Headers["X-Portal-TimeZone"] = hour;
            request.Headers["X-Portal-Sign"] = sign;
        }

        private string HandleGetRequestUrl(string url)
        {
            if (url != null && url.Length > 0)
            {
                string firstChar = url.Contains("?") ? "&" : "?";
                string language = Thread.CurrentThread.CurrentUICulture.Name;
                string acceptType = ContentType;
                string hour = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).Hours.ToString();
                string sign = SignParameters(m_UserSysNo.ToString(), m_UserAcct, hour);
                return string.Format("{0}{1}Portal_Accept={2}&Portal_Language={3}&Portal_UserSysNo={4}&Portal_UserAcct={5}&Portal_TimeZone={6}&Portal_Sign={7}",
                    url, firstChar, acceptType, language, m_UserSysNo, HttpUtility.UrlEncode(m_UserAcct), hour, HttpUtility.UrlEncode(sign));
            }
            return url;
        }

        private string CombineUrl(string root, string sub)
        {
            string url = sub.ToLower().Trim();
            if (url.Length <= 0)
            {
                return root;
            }
            if (url.IndexOf("http") == 0)
            {
                return sub.Trim();
            }
            return root.Trim().TrimEnd(new char[] { '/' }) + "/" + sub.Trim().TrimStart(new char[] { '/', '\\' });
        }

        private bool ErrorHandle(out RestServiceError error, string responseTxt, ISerializer serializer)
        {
            bool existError = false;
            error = null;
            if (responseTxt != null)
            {
                try
                {
                    using (Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(responseTxt)))
                    {
                        error = serializer.Deserialize(stream, typeof(RestServiceError)) as RestServiceError;
                    }
                    if (!(existError = (error != null && error.Faults != null && error.StatusCode > 0)))
                    {
                        error = null;
                    }
                }
                catch
                {
                    existError = false;
                }
            }

            return existError;
        }

        private bool ErrorHandle(out RestServiceError error, HttpWebResponse response, ISerializer serializer)
        {
            bool existError = false;
            error = null;
            if (response != null)
            {
                try
                {
                    error = serializer.Deserialize(response.GetResponseStream(), typeof(RestServiceError)) as RestServiceError;
                    if (!(existError = (error != null && error.Faults != null && error.StatusCode > 0)))
                    {
                        error = null;
                    }
                }
                catch
                {
                    existError = false;
                }
            }

            return existError;
        }

        #region 异步方式

        private void OnGetResponse<T>(IAsyncResult result)
        {
            AsyncArgs<T> args = (AsyncArgs<T>)result.AsyncState;
            HttpWebResponse response = null;
            object data = null;
            RestServiceError error = null;
            try
            {
                response = args.Request.EndGetResponse(result) as HttpWebResponse;
                ISerializer serializer = SerializerFactory.GetSerializer((args.Request.Accept == null || args.Request.Accept.Length == 0) ? ContentType : args.Request.Accept);
                string responseTxt;
                using (StreamReader readStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseTxt = readStream.ReadToEnd();
                }
                if (!ErrorHandle(out error, responseTxt, serializer))
                {
                    if (args.IsDynamic)
                    {
                        data = DynamicXml.Parse(responseTxt);
                    }
                    else
                    {
                        using (Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(responseTxt)))
                        {
                            data = (T)serializer.Deserialize(stream, typeof(T));
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse e = ex.Response as HttpWebResponse;
                error = new RestServiceError();
                error.StatusCode = e.StatusCode.GetHashCode();
                error.StatusDescription = e.StatusDescription;
                error.Faults = new List<Error>();
                error.Faults.Add(new Error()
                {
                    ErrorCode = "00000",
                    ErrorDescription = string.Format("Call Service {0} Failed.\r\n\r\nError Detail:{1}", args.Request.RequestUri.ToString(), ex.ToString())
                });
                e.Close();
                ExceptionHelper.HandleException(ex, string.Format("Call Service {0} Failed.", args.Request.RequestUri.ToString()), new object[0]);
            }
            catch (Exception ex)
            {
                error = new RestServiceError();
                error.StatusCode = 500;
                error.Faults = new List<Error>();
                error.Faults.Add(new Error()
                {
                    ErrorCode = "00000",
                    ErrorDescription = string.Format("Call Service {0} Failed.\r\n\r\nError Detail:{1}", args.Request.RequestUri.ToString(), ex.ToString())
                });
                ExceptionHelper.HandleException(ex, string.Format("Call Service {0} Failed.", args.Request.RequestUri.ToString()), new object[0]);
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            if (error == null)
            {
                Action<T> handler = args.SucceedHandler;
                if (handler != null)
                {
                    handler((T)data);
                }
            }
            else
            {
                Action<RestServiceError> eHandler = args.ErrorHandler;
                if (eHandler != null)
                {
                    eHandler(error);
                }
            }
        }

        private IAsyncHandle AsyncHttpPostData<T>(string operating, string relativeUrl, object data, Action<T> callback, Action<RestServiceError> errorHandler, bool isDynamic = false)
        {
            string url = CombineUrl(this.m_ServicePath, relativeUrl == null || relativeUrl.Trim().Length <= 0 ? string.Empty : relativeUrl);
            HttpRequest request = new HttpRequest(url, ContentType, ContentType);
            HandlePostRequestHeader(request, operating);
            request.Method = Operating.POST;
            if (data != null)
            {
                ISerializer serializer = SerializerFactory.GetSerializer(request.ContentType);
                if (serializer != null)
                {
                    string postContent = serializer.Serialization(data, data.GetType());
                    using (StreamWriter stream = new StreamWriter(request.GetRequestStream()))
                    {
                        stream.Write(postContent);
                    }
                }
            }
            IAsyncResult handler = request.BeginGetResponse(new AsyncCallback(OnGetResponse<T>),
                new AsyncArgs<T>(request, callback, errorHandler, isDynamic));
            return new RestClientAsyncHandle(request, handler);
        }

        private IAsyncHandle AsyncHttpGetData<T>(string relativeUrl, Action<T> callback, Action<RestServiceError> errorHandler, bool isDynamic = false)
        {
            string url = CombineUrl(this.m_ServicePath, relativeUrl == null || relativeUrl.Trim().Length <= 0 ? string.Empty : relativeUrl);
            url = HandleGetRequestUrl(url);
            HttpRequest request = new HttpRequest(url, ContentType, ContentType);
            request.Method = Operating.GET;
            IAsyncResult handler = request.BeginGetResponse(new AsyncCallback(OnGetResponse<T>),
                new AsyncArgs<T>(request, callback, errorHandler, isDynamic));
            return new RestClientAsyncHandle(request, handler);
        }

        public IAsyncHandle AsyncQueryDynamicData(string relativeUrl, Action<dynamic> callback, Action<RestServiceError> errorHandler = null)
        {
            return AsyncHttpGetData<dynamic>(relativeUrl, callback, errorHandler, true);
        }

        public IAsyncHandle AsyncQueryDynamicData(string relativeUrl, object condition, Action<dynamic> callback, Action<RestServiceError> errorHandler = null)
        {
            return AsyncHttpPostData<dynamic>(Operating.POST, relativeUrl, condition, callback, errorHandler, true);
        }

        public IAsyncHandle AsyncQuery<T>(string relativeUrl, Action<T> callback, Action<RestServiceError> errorHandler = null)
        {
            return AsyncHttpGetData<T>(relativeUrl, callback, errorHandler);
        }

        public IAsyncHandle AsyncQuery<T>(string relativeUrl, object condition, Action<T> callback, Action<RestServiceError> errorHandler = null)
        {
            return AsyncHttpPostData<T>(Operating.POST, relativeUrl, condition, callback, errorHandler);
        }

        public IAsyncHandle AsyncCreate<T>(string relativeUrl, object data, Action<T> callback, Action<RestServiceError> errorHandler = null)
        {
            return AsyncHttpPostData<T>(Operating.POST, relativeUrl, data, callback, errorHandler);
        }

        public IAsyncHandle AsyncCreate(string relativeUrl, object data, Action callback, Action<RestServiceError> errorHandler = null)
        {
            return AsyncCreate<object>(relativeUrl, data, (o) => callback(), errorHandler);
        }

        public IAsyncHandle AsyncUpdate<T>(string relativeUrl, object data, Action<T> callback, Action<RestServiceError> errorHandler = null)
        {
            return AsyncHttpPostData<T>(Operating.PUT, relativeUrl, data, callback, errorHandler);
        }

        public IAsyncHandle AsyncUpdate(string relativeUrl, object data, Action callback, Action<RestServiceError> errorHandler = null)
        {
            return AsyncUpdate<object>(relativeUrl, data, (o) => callback(), errorHandler);
        }

        public IAsyncHandle AsyncDelete<T>(string relativeUrl, object data, Action<T> callback, Action<RestServiceError> errorHandler = null)
        {
            return AsyncHttpPostData<T>(Operating.DELETE, relativeUrl, data, callback, errorHandler);
        }

        public IAsyncHandle AsyncDelete(string relativeUrl, object data, Action callback, Action<RestServiceError> errorHandler = null)
        {
            return AsyncDelete<object>(relativeUrl, data, (o) => callback(), errorHandler);
        }

        #endregion 异步方式

        #region 同步方式

        private bool GetResponse<T>(HttpRequest request, out T data, out RestServiceError error, bool isDynamic)
        {
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    ISerializer serializer = SerializerFactory.GetSerializer((request.Accept == null || request.Accept.Length == 0) ? ContentType : request.Accept);
                    string responseTxt;
                    using (StreamReader readStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        responseTxt = readStream.ReadToEnd();
                    }
                    if (!ErrorHandle(out error, responseTxt, serializer))
                    {
                        if (isDynamic)
                        {
                            data = DynamicXml.Parse(responseTxt);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(responseTxt))
                            {
                                using (Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(responseTxt)))
                                {
                                    data = (T)serializer.Deserialize(stream, typeof(T));
                                }
                            }
                            else
                            {
                                data = default(T);
                            }

                        }
                        error = null;
                        return true;
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse e = ex.Response as HttpWebResponse;
                if (e != null)
                {
                    error = new RestServiceError();
                    error.StatusCode = e.StatusCode.GetHashCode();
                    error.StatusDescription = e.StatusDescription;
                    error.Faults = new List<Error>();
                    error.Faults.Add(new Error()
                    {
                        ErrorCode = "00000",
                        ErrorDescription = string.Format("Call Service {0} Failed.\r\n\r\nError Detail:{1}", request.RequestUri.ToString(), ex.ToString())
                    });
                    e.Close();
                }
                else if (ex.Response != null)
                {
                    error = new RestServiceError();
                    error.StatusCode = -1;
                    error.StatusDescription = "未知错误，返回的WebException.Response类型为：" + ex.Response.GetType();
                    error.Faults = new List<Error>();
                    error.Faults.Add(new Error()
                    {
                        ErrorCode = "00000",
                        ErrorDescription = string.Format("Call Service {0} Failed.\r\n\r\nError Detail:{1}", request.RequestUri.ToString(), ex.ToString())
                    });
                }
                else
                {
                    error = new RestServiceError();
                    error.StatusCode = -2;
                    error.StatusDescription = "未知错误，返回的WebException.Response为null。";
                    error.Faults = new List<Error>();
                    error.Faults.Add(new Error()
                    {
                        ErrorCode = "00000",
                        ErrorDescription = string.Format("Call Service {0} Failed.\r\n\r\nError Detail:{1}", request.RequestUri.ToString(), ex.ToString())
                    });
                }
                ExceptionHelper.HandleException(ex, string.Format("Call Service {0} Failed.", request.RequestUri.ToString()), new object[0]);
            }
            catch (Exception ex)
            {
                error = new RestServiceError();
                error.StatusCode = 500;
                error.Faults = new List<Error>();
                error.Faults.Add(new Error()
                {
                    ErrorCode = "00000",
                    ErrorDescription = string.Format("Call Service {0} Failed.\r\n\r\nError Detail:{1}", request.RequestUri.ToString(), ex.ToString())
                });
                ExceptionHelper.HandleException(ex, string.Format("Call Service {0} Failed.", request.RequestUri.ToString()), new object[0]);
            }
            data = default(T);
            return false;
        }

        private bool HttpPostData<T>(string operating, string relativeUrl, object data, out T returnData, out RestServiceError error, bool isDynamic = false)
        {
            string url = CombineUrl(this.m_ServicePath, relativeUrl == null || relativeUrl.Trim().Length <= 0 ? string.Empty : relativeUrl);
            HttpRequest request = new HttpRequest(url, ContentType, ContentType);
            if (this.Timeout.HasValue)
            {
                request.Timeout = this.Timeout.Value;
            }
            HandlePostRequestHeader(request, operating);
            request.Method = Operating.POST;
            if (data != null)
            {
                ISerializer serializer = SerializerFactory.GetSerializer(request.ContentType);
                if (serializer != null)
                {
                    string postContent = serializer.Serialization(data, data.GetType());
                    using (StreamWriter stream = new StreamWriter(request.GetRequestStream()))
                    {
                        stream.Write(postContent);
                    }
                }
            }
            return GetResponse(request, out returnData, out error, isDynamic);
        }

        private bool HttpGetData<T>(string relativeUrl, out T returnData, out RestServiceError error, bool isDynamic = false)
        {
            string url = CombineUrl(this.m_ServicePath, relativeUrl == null || relativeUrl.Trim().Length <= 0 ? string.Empty : relativeUrl);
            url = HandleGetRequestUrl(url);
            HttpRequest request = new HttpRequest(url, ContentType, ContentType);
            if (this.Timeout.HasValue)
            {
                request.Timeout = this.Timeout.Value;
            }
            request.Method = Operating.GET;
            return GetResponse(request, out returnData, out error, isDynamic);
        }

        public bool QueryDynamicData(string relativeUrl, out dynamic returnData, out RestServiceError error)
        {
            return HttpGetData<dynamic>(relativeUrl, out returnData, out error, true);
        }

        public bool QueryDynamicData(string relativeUrl, object condition, out dynamic returnData, out RestServiceError error)
        {
            return HttpPostData<dynamic>(Operating.POST, relativeUrl, condition, out returnData, out error, true);
        }

        public bool Query<T>(string relativeUrl, out T returnData, out RestServiceError error)
        {
            return HttpGetData<T>(relativeUrl, out returnData, out error);
        }

        public bool Query<T>(string relativeUrl, object condition, out T returnData, out RestServiceError error)
        {
            return HttpPostData<T>(Operating.POST, relativeUrl, condition, out returnData, out error);
        }

        public bool Create<T>(string relativeUrl, object data, out T returnData, out RestServiceError error)
        {
            return HttpPostData<T>(Operating.POST, relativeUrl, data, out returnData, out error);
        }

        public bool Create(string relativeUrl, object data, out RestServiceError error)
        {
            object returnData;
            return Create<object>(relativeUrl, data, out returnData, out error);
        }

        public bool Update<T>(string relativeUrl, object data, out T returnData, out RestServiceError error)
        {
            return HttpPostData<T>(Operating.PUT, relativeUrl, data, out returnData, out error);
        }

        public bool Update(string relativeUrl, object data, out RestServiceError error)
        {
            object returnData;
            return Update<object>(relativeUrl, data, out returnData, out error);
        }

        public bool Delete<T>(string relativeUrl, object data, out T returnData, out RestServiceError error)
        {
            return HttpPostData<T>(Operating.DELETE, relativeUrl, data, out returnData, out error);
        }

        public bool Delete(string relativeUrl, object data, out RestServiceError error)
        {
            object returnData;
            return Delete<object>(relativeUrl, data, out returnData, out error);
        }

        #endregion 同步方式
    }
}