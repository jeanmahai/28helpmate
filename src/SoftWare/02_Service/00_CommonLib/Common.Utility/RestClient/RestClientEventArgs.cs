using System;
using System.Net;
using System.Text;

namespace Common.Utility
{
    public class RestClientEventArgs<T> : EventArgs
    {
        internal object m_result;

        public T Result
        {
            get
            {
                return (T)m_result;
            }
        }

        public RestServiceError Error { get; internal set; }

        internal RestClientEventArgs()
        {

        }

        public RestClientEventArgs(T result)
        {
            m_result = result;
        }

        private bool FaultsHandle()
        {
            if (this.Error != null)
            {
                bool isBizException = true;
                string error = GetError(ref isBizException);
                
                return true;
            }

            return false;
        }

        private string GetError(ref bool isBizException)
        {
            StringBuilder build = new StringBuilder();
            foreach (Error item in this.Error.Faults)
            {
                if (isBizException && !item.IsBusinessException)
                {
                    isBizException = false;
                }
                build.Append(string.Format("{0}", item.ErrorDescription));
            }
            return build.ToString();
        }
    }
}
