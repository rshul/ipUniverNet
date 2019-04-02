using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW5.OOP.Factory
{
    class Logger
    {
        public static int LogInfoCounter { get; private set; }
        public static int LogWarningCounter { get; private set; }

        static Logger()
        {
            LogInfoCounter = 0;
            LogWarningCounter = 0;
        }
       public static void LogInfo(string message)
        {
            Console.WriteLine($"{LogInfoCounter++} Info {DateTime.Now.ToString()} {message}");
        }
       public static void LogWarning(string message)
        {
            Console.WriteLine($"{LogWarningCounter++} Warning {DateTime.Now.ToString()} {message}");
        }
    }
}
