using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task1
{
    class Server:ComputerDevice
    {
        public int CpuNumber { get; private set; }
        public Server(string name, int powerConsumption, int ram, int cpuNumber) : base(name, powerConsumption, ram)
        {
            this.CpuNumber = cpuNumber;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + $", RAM {this.Ram}, {this.CpuNumber}";
        }
    }
}
