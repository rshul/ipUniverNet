using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task1
{
    class Laptop:ComputerDevice
    {
        public int Weight { get; private set; }
        public Laptop(string name, int powerConsumption, int ram, int weight):base(name, powerConsumption, ram)
        {
            this.Weight = weight;
        }

        public override string ToString()
        {
            return $"Laptop {this.Name}, power consumption {this.PowerConsumption}, RAM {this.Ram}, weight {this.Weight}. Type: {this.GetType()}";
        }
    }
}
