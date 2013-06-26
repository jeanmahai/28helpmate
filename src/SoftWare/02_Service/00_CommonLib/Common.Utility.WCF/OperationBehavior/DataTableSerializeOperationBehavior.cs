using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.Xml;
using System.Net;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Common.Service.Utility.WCF
{
    /// <summary>
    /// 通过该Behavior来插入一个自定义的MessageFormatter，用该Formatter来序列化DataTable和QueryResult对象
    /// </summary>
    public class DataTableSerializeOperationBehavior : IOperationBehavior
    {
        private IConvert m_Convertor = null;

        public DataTableSerializeOperationBehavior()
        {

        }

        public DataTableSerializeOperationBehavior(string typeName)
            : this(typeName != null && typeName.Trim().Length > 0 ? Type.GetType(typeName, true) : null)
        {

        }

        public DataTableSerializeOperationBehavior(Type type)
        {
            if (type != null)
            {
                if (!typeof(IConvert).IsAssignableFrom(type))
                {
                    throw new ArgumentException("类型" + type.FullName + "没有实现接口" + typeof(IConvert).FullName, "type");
                }
                m_Convertor = Activator.CreateInstance(type) as IConvert;
            }
        }

        public DataTableSerializeOperationBehavior(IConvert convertor)
        {
            m_Convertor = convertor;
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {

        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Formatter = new DataTableSerializeMessageFormatter(operationDescription, dispatchOperation.Formatter, m_Convertor);
        }

        public void Validate(OperationDescription operationDescription)
        {

        }
    }
}
