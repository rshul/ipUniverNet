using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task1
{
    class Device
    {
        public string Name { get; private set; }
        public int PowerConsumption { get; private set; }
        public Device(string name, int powerConsumption)
        {
            this.Name = name;
            this.PowerConsumption = powerConsumption;
        }
        public virtual string GetDescription()
        {
            return $"Device {this.Name}, power consumption {this.PowerConsumption}";
        }
    }
}
