using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Web.Routing;
using System.ServiceModel.Activation;

namespace Common.Service.Utility.WCF
{
    public static class RestWebServiceHost
    {
        /// <summary>
        /// 读取config文件里的Service配置，来启动Restful WCF服务
        /// </summary>
        public static void Open()
        {
            Open(null);
        }

        /// <summary>
        /// 读取config文件里的Service配置，来启动Restful WCF服务
        /// </summary>
        /// <param name="customBizExceptionTypeName">自定义的业务异常类型的类型全名，该类型必须继承自System.Exception；当不需要定义自定义业务异常时，可以传入null。</param>
        public static void Open(string customBizExceptionTypeName)
        {
            Open(customBizExceptionTypeName, null);
        }

        /// <summary>
        /// 读取config文件里的Service配置，来启动Restful WCF服务
        /// </summary>
        /// <param name="customBizExceptionTypeName">自定义的业务异常类型的类型全名，该类型必须继承自System.Exception；当不需要定义自定义业务异常时，可以传入null。</param>
        /// <param name="exceptionHandlerTypeName">未捕获的异常的处理器类型的全名，该类型必须实现接口ECCentral.Service.Utility.WCF.IExceptionHandle；当不需要未捕获的异常的处理器时，可以传入null。</param>
        public static void Open(string customBizExceptionTypeName, string exceptionHandlerTypeName)
        {
            Open(customBizExceptionTypeName, exceptionHandlerTypeName, null);
        }

        /// <summary>
        /// 读取config文件里的Service配置，来启动Restful WCF服务
        /// </summary>
        /// <param name="customBizExceptionTypeName">自定义的业务异常类型的类型全名，该类型必须继承自System.Exception；当不需要定义自定义业务异常时，可以传入null。</param>
        /// <param name="exceptionHandlerTypeName">未捕获的异常的处理器类型的全名，该类型必须实现接口ECCentral.Service.Utility.WCF.IExceptionHandle；当不需要未捕获的异常的处理器时，可以传入null。</param>
        /// <param name="converterTypeName">在方法返回QueryResult对象或DataTable对象时，序列化DataTable的过程中对数据进行转换时使用的自定义数据转化器的类型全名，该类型必须实现接口ECCentral.Service.Utility.WCF.IConvert；当不需要自定义数据转化器时，可以传入null。</param>
        public static void Open(string customBizExceptionTypeName, string exceptionHandlerTypeName, string converterTypeName)
        {
            WebServiceHostFactory factory = new RestWebServiceHostFactory(customBizExceptionTypeName, exceptionHandlerTypeName, converterTypeName);
            RouteTable.Routes.Add(new ServiceRoute("UtilityService", factory, typeof(UtilityRestService)));
            List<ServiceData> list = ServiceConfig.GetAllService();
            foreach (ServiceData de in list)
            {
                string routePrefix = (de.Path == null ? string.Empty : de.Path.Trim());
                Type serviceType = Type.GetType(de.Type.Trim(), true);
                RouteTable.Routes.Add(new ServiceRoute(routePrefix, factory, serviceType));
                //RouteTable.Routes.Add(new ServiceRoute(routePrefix, new WebServiceHostFactory(), serviceType));
            }
        }
    }
}
