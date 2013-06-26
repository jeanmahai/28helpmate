using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Utility
{
    public interface IConsumer<T> where T : IEventMessage
    {
        void HandleEvent(T eventMessage);

        ExecuteMode ExecuteMode
        {
            get;
        }
    }

    public enum ExecuteMode
    {
        /// <summary>
        /// 同步执行
        /// </summary>
        Sync,

        /// <summary>
        /// 异步执行
        /// </summary>
        Async,

        /// <summary>
        /// 根据当前执行上下文的事务情况，如果有事务则同步执行加入事务，如果没有事务则异步执行
        /// </summary>
        AccordingToTransaction
    }
}
