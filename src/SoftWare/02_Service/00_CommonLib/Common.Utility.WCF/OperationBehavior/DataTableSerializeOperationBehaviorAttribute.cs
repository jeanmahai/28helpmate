using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Common.Service.Utility.WCF
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DataTableSerializeOperationBehaviorAttribute : Attribute, IOperationBehavior
    {
        DataTableSerializeOperationBehavior m_OperationBehavior;

        public DataTableSerializeOperationBehaviorAttribute()
        {
            m_OperationBehavior = new DataTableSerializeOperationBehavior();
        }

        public DataTableSerializeOperationBehaviorAttribute(string typeName)
        {
            m_OperationBehavior = new DataTableSerializeOperationBehavior(typeName);
        }

        public DataTableSerializeOperationBehaviorAttribute(Type type)
        {
            m_OperationBehavior = new DataTableSerializeOperationBehavior(type);
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            m_OperationBehavior.AddBindingParameters(operationDescription, bindingParameters);
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            m_OperationBehavior.ApplyClientBehavior(operationDescription, clientOperation);
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            m_OperationBehavior.ApplyDispatchBehavior(operationDescription, dispatchOperation);
        }

        public void Validate(OperationDescription operationDescription)
        {
            m_OperationBehavior.Validate(operationDescription);
        }
    }
}
