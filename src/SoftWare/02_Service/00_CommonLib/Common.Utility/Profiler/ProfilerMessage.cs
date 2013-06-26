using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Utility
{
    public class ProfilerMessage
    {
        public string AppServerIP { get; set; }

        public string AppID { get; set; }

        public Guid ThreadID { get; set; }

        public int CallStackDepth { get; set; }

        public string AssemblyFullName { get; set; }

        public string ClassTypeFullName { get; set; }

        public string MethodName { get; set; }

        public DateTime ExecutionStartTime { get; set; }

        public DateTime ExecutionEndTime { get; set; }

        public long ExecutionStartTicks { get; set; }

        public long ExecutionEndTicks { get; set; }

        public double ExecutionTicks { get; set; }

        public long ExecutionFrequency { get; set; }

        public bool HasThrowException { get; set; }
    }
}
