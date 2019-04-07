using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task1
{
    class ComputerDevice:Device
    {
        public int Ram { get; private set; }
        public ComputerDevice(string name, int powerConsumption, int ram):base(name, powerConsumption)
        {
            this.Ram = ram;
        }
    }
}
