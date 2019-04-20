using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW7.OOP.Interfaces
{
    class Logger : ILogger
    {
        private LogLevels _logLevel;
        public LogLevels LogLevel
        {
            get { return this._logLevel; }
            set
            {
                if (!Enum.IsDefined(typeof(LogLevels), value))
                {
                    return;
                }
                this._logLevel = value;
            }
        }
        public List<ILogStorage> LogStorages { get; } = new List<ILogStorage>();
        public void Info(string message)
        {
            WriteToStorages(LogLevels.Info, Program.GetMethodName(), message);
        }

        public void Debug(string message)
        {
            WriteToStorages(LogLevels.Debug, Program.GetMethodName(), message);
        }

        public void Error(string message)
        {
            WriteToStorages(LogLevels.Error, Program.GetMethodName(), message);
        }

        public void Fatal(string message)
        {
            WriteToStorages(LogLevels.Fatal, Program.GetMethodName(), message);
        }

        public void Warn(string message)
        {
            WriteToStorages(LogLevels.Warn, Program.GetMethodName(), message);
        }
        public void WriteToStorages(LogLevels logLevelInt, string methodName, string message)
        {
            if (logLevelInt >= this.LogLevel)
            {
                foreach (var storage in LogStorages)
                {
                    storage.Write($"{logLevelInt} {DateTime.Now} {message}");
                }
            }

        }
    }
}

