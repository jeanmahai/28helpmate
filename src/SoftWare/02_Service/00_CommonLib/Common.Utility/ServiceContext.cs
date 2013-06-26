using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;

namespace Common.Utility
{
    public static class ServiceContext
    {
        public static IContext Current
        {
            get
            {
                // 可以配置自定义的上下文对象容器，便于以后切换服务端具体的技术框架容器，以及方便做UnitTest（可以定义mock的上下文对象）
                string contextTypeName = ConfigurationManager.AppSettings["ServiceContextType"];
                if (contextTypeName != null && contextTypeName.Trim().Length > 0)
                {
                    return (IContext)Activator.CreateInstance(Type.GetType(contextTypeName, true));
                }
                // 默认不配置则使用WCF Restfull的方式的上下文
                return new WCFRestServiceContext();
            }
        }
    }

    public interface IContext
    {
        /// <summary>
        /// 当前操作用户的系统唯一编号
        /// </summary>
        int UserSysNo { get; }

        /// <summary>
        /// 当前操作用户的显示名
        /// </summary>
        string UserDisplayName { get; }

        /// <summary>
        /// 当前操作客户端的IP地址
        /// </summary>
        string ClientIP { get; }

        /// <summary>
        /// 将当前的 IContext 实例附加到指定的 IContext 实例
        /// </summary>
        /// <param name="owner">要附加的IContext实例</param>
        void Attach(IContext owner);
    }

    internal class ConsoleServiceContext : IContext
    {

        public int UserSysNo
        {
            get { return 1; }
        }

        public string UserDisplayName
        {
            get { return "Mock"; }
        }

        public string ClientIP
        {
            get { return "127.0.0.1"; }
        }

        public void Attach(IContext owner)
        {

        }
    }

    internal class WCFRestServiceContext : IContext
    {
        private const string X_User_SysNo = "X-User-SysNo";
        private const string X_User_Display_Name = "X-User-Display-Name";
        //private const string X_Portal_TimeZone = "X-Portal-TimeZone";

        private OperationContext m_RealContext;
        private System.Globalization.CultureInfo m_Culture; 

        public WCFRestServiceContext()
        {
            m_RealContext = OperationContext.Current;
            m_Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
        }

        public OperationContext RealContext
        {
            get 
            {
                return m_RealContext;
            }
        }

        public System.Globalization.CultureInfo Culture
        {
            get
            {
                return m_Culture;
            }
        }

        public int UserSysNo
        {
            get
            {
                if (WebOperationContext.Current != null
                    && WebOperationContext.Current.IncomingRequest != null
                    && WebOperationContext.Current.IncomingRequest.Headers != null)
                {
                    int tmp;
                    string userSysNo = WebOperationContext.Current.IncomingRequest.Headers[X_User_SysNo];
                    if (userSysNo != null && userSysNo.Trim().Length > 0 && int.TryParse(HttpUtility.UrlDecode(userSysNo), out tmp))
                    {
                        return tmp;
                    }
                }
                return -1;
            }
        }

        public string UserDisplayName 
        {
            get
            {
                if (WebOperationContext.Current != null
                    && WebOperationContext.Current.IncomingRequest != null
                    && WebOperationContext.Current.IncomingRequest.Headers != null)
                {
                    string name = WebOperationContext.Current.IncomingRequest.Headers[X_User_Display_Name];
                    if (name != null)
                    {
                        return HttpUtility.UrlDecode(name.Trim());
                    }
                }
                return null;
            }
        }

        public string ClientIP
        {
            get
            {
                if (OperationContext.Current != null)
                {
                    RemoteEndpointMessageProperty endpointProperty = OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                    if (endpointProperty != null)
                    {
                        return endpointProperty.Address;
                    }
                }
                return string.Empty;
            }
        }

        #region IContext Members


        public void Attach(IContext owner)
        {
            WCFRestServiceContext context = owner as WCFRestServiceContext;
            if (context != null)
            {
                var realContext = context.RealContext;
                OperationContext.Current = realContext;

                System.Threading.Thread.CurrentThread.CurrentCulture = context.Culture;
            }
        }

        #endregion
    }
}
