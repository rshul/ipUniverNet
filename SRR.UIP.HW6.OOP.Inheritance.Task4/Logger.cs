using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
    static class Logger
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
            Console.WriteLine($"{LogInfoCounter++,10:D} Info\t{DateTime.Now.ToString("dd.MM.yyyy HH:mm:fff")} {message}");
        }
        public static void LogWarning(string message)
        {
            Console.WriteLine($"{LogWarningCounter++,10:D} Warning\t{DateTime.Now.ToString("dd.MM.yyyy HH:mm:fff")} {message}");
        }
    }
}
