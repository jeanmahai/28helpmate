using System;
using System.Collections.Generic;

using System.Text;
using System.Messaging;


namespace Common.Utility
{
    public interface ILogEmitter
    {
        void Init(string configParam);

        void EmitLog(LogEntry log);
    }
}
