using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW7.OOP.Interfaces
{
    class Logger : ILogger
    {
        private LevelsOfLog _logLevel;
        public LevelsOfLog LogLevel
        {
            get { return this._logLevel; }
            set
            {
                if (!Enum.IsDefined(typeof(LevelsOfLog), value))
                {
                    return;
                }
                this._logLevel = value;
            }
        }
        public List<ILogStorage> LogStorages { get; } = new List<ILogStorage>();
        public void Info(string message)
        {
            WriteToStorages(LevelsOfLog.Info, Program.GetMethodName(), message);
        }

        public void Debug(string message)
        {
            WriteToStorages(LevelsOfLog.Debug, Program.GetMethodName(), message);
        }

        public void Error(string message)
        {
            WriteToStorages(LevelsOfLog.Error, Program.GetMethodName(), message);
        }

        public void Fatal(string message)
        {
            WriteToStorages(LevelsOfLog.Fatal, Program.GetMethodName(), message);
        }

        public void Warn(string message)
        {
            WriteToStorages(LevelsOfLog.Warn, Program.GetMethodName(), message);
        }
        public void WriteToStorages(LevelsOfLog logLevelInt, string methodName, string message)
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

