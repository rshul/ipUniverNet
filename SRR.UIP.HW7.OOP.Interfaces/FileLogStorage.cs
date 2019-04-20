using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW7.OOP.Interfaces
{
    class FileLogStorage : ILogStorage
    {
        public void Write(string message)
        {
            Console.WriteLine($"{this.GetType().Name} {message}");
        }
    }
}
