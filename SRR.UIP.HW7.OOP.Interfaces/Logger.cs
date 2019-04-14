using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW7.OOP.Interfaces
{
    class Logger : ILogger
    {
        private int _logLevel;
        public int LogLevel
        {
            get { return this._logLevel; }
            set
            {
                if (value < 1 || value > 5)
                {
                    return;
                }
                this._logLevel = value;
            }
        }
        public List<ILogStorage> LogStorages { get; } = new List<ILogStorage>();
        public void Info(string message)
        {
            WriteToStorages(1, Program.GetCurrentMethodName(), message);
        }

        public void Debug(string message)
        {
            WriteToStorages(2, Program.GetCurrentMethodName(), message);


        }

        public void Error(string message)
        {
            WriteToStorages(4, Program.GetCurrentMethodName(), message);
        }

        public void Fatal(string message)
        {
            WriteToStorages(5, Program.GetCurrentMethodName(), message);
        }

        public void Warn(string message)
        {
            WriteToStorages(3, Program.GetCurrentMethodName(), message);
        }
        public void WriteToStorages(int logLevelInt, string loglevel, string message)
        {
            if (logLevelInt >= this.LogLevel)
            {
                foreach (var storage in LogStorages)
                {
                    storage.Write($"{loglevel}{DateTime.Now}{message}");
                }
            }

        }
    }
}

