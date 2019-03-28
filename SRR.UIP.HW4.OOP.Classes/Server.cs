using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW4.OOP.Classes.Task1
{
    class Server
    {
        public string Name { get; private set; }
        public int PowerConsumption { get; private set; }
        public int Ram { get; private set; }
        public int CpuNumber { get; private set; }

        public Server(string name, int powerConsumption, int ram, int cpuNumber)
        {
            this.Name = name;
            this.PowerConsumption = powerConsumption;
            this.Ram = ram;
            this.CpuNumber = cpuNumber;
        }

        public string GetDescription()
        {
            return $"Server {this.Name}, power consumption {this.PowerConsumption}, RAM {this.Ram}, cpu number {this.CpuNumber}";
        }
    }
}
