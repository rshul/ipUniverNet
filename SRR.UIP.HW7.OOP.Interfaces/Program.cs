using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW7.OOP.Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();

            logger.LogStorages.Add(new ConsoleLogStorage());
            logger.LogStorages.Add(new FileLogStorage());
            logger.Info("user loged out");
            logger.LogStorages.RemoveAt(1);
            logger.Info("stringinfo");
            logger.Debug("stringdebug");
            logger.Warn("stringwarn");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethodName()
        {
            StackFrame sf = new StackTrace().GetFrame(1);
            return sf.GetMethod().Name;
        }

    }
}
