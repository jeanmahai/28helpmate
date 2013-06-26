using System;
using System.Diagnostics;

using PostSharp.Aspects;

namespace Common.Utility
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class ProfilerTraceAttribute : OnMethodBoundaryAspect
    {
        private string m_AssemblyFullName;
        private string m_ClassTypeFullName;
        private string m_MethodName;

        public override void CompileTimeInitialize(System.Reflection.MethodBase method, AspectInfo aspectInfo)
        {
            m_AssemblyFullName = method.DeclaringType.Assembly.FullName;
            m_ClassTypeFullName = method.DeclaringType.FullName;
            m_MethodName = method.Name;
        }

        public override bool CompileTimeValidate(System.Reflection.MethodBase method)
        {
            // 1. 检查方法上是否有添加排除跟踪的Attribute标记
            var array = method.GetCustomAttributes(typeof(NoProfilerTraceAttribute), false);
            if (array != null && array.Length > 0 && array[0] is NoProfilerTraceAttribute)
            {
                return false;
            }
            // 2. 检查定义方法的类型上是否有添加排除跟踪的Attribute标记
            array = method.DeclaringType.GetCustomAttributes(typeof(NoProfilerTraceAttribute), false);
            if (array != null && array.Length > 0 && array[0] is NoProfilerTraceAttribute)
            {
                return false;
            }
            return true;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (ProfilerConfig.Disabled)
            {
                return;
            }
            ExecutionInfo info = new ExecutionInfo();
            args.MethodExecutionTag = info;
            info.Start();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            if (ProfilerConfig.Disabled)
            {
                return;
            }
            ExecutionInfo info = (ExecutionInfo)args.MethodExecutionTag;
            info.Stop();
            ProfilerMessage msg = info.ToMessage(m_AssemblyFullName, m_ClassTypeFullName, m_MethodName);
            ProfilerManager.Enqueue(msg);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            if (ProfilerConfig.Disabled)
            {
                return;
            }
            ExecutionInfo info = (ExecutionInfo)args.MethodExecutionTag;
            info.HasThrowException = (args.Exception != null);
        }

        private class ExecutionInfo
        {
            //private Stopwatch m_Stopwatch = new Stopwatch();
            private DateTime m_StartTime;
            private DateTime m_EndTime;
            private bool m_HasThrowException;
            private long m_StartTicks;
            private long m_EndTicks;
            private long m_Frequency;

            [ThreadStatic]
            private static Guid s_ThreadID = Guid.NewGuid();
            [ThreadStatic]
            private static int s_Depth;

            public bool HasThrowException
            {
                get { return m_HasThrowException; }
                set { m_HasThrowException = value; }
            }

            public void Start()
            {
                s_Depth++;
                m_StartTime = DateTime.Now;
                m_StartTicks = Stopwatch.GetTimestamp();
            }

            public void Stop()
            {
                m_EndTicks = Stopwatch.GetTimestamp();
                m_Frequency = Stopwatch.Frequency;
                m_EndTime = DateTime.Now;
                s_Depth--;
            }

            public ProfilerMessage ToMessage(string assembly, string classType, string method)
            {
                if (s_ThreadID == Guid.Empty)
                {
                    s_ThreadID = Guid.NewGuid();
                }
                return new ProfilerMessage()
                {
                    AppServerIP = ProfilerConfig.GetServerIP(),
                    AppID = ProfilerConfig.GetAppID(),
                    ThreadID = s_ThreadID,
                    CallStackDepth = s_Depth,
                    AssemblyFullName = assembly,
                    ClassTypeFullName = classType,
                    MethodName = method,

                    ExecutionStartTime = m_StartTime,
                    ExecutionEndTime = m_EndTime,
                    ExecutionStartTicks = m_StartTicks,
                    ExecutionEndTicks = m_EndTicks,
                    ExecutionFrequency = m_Frequency,
                    HasThrowException = m_HasThrowException,
                    ExecutionTicks = (double)(m_EndTicks - m_StartTicks) / m_Frequency
                    
                };
            }
        }
    }
}
