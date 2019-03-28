using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW4.OOP.Classes.Task1
{
    class Laptop
    {
        public string Name { get; private set; }
        public int PowerConsumption { get; private set; }
        public int Ram { get; private set; }
        public int Weight { get; private set; }

        public Laptop(string name, int powerConsumption, int ram, int weight)
        {
            this.Name = name;
            this.PowerConsumption = powerConsumption;
            this.Ram = ram;
            this.Weight = weight;
        }

        public string GetDescription()
        {
            return $"Laptop {this.Name}, power consumption {this.PowerConsumption}, RAM {this.Ram}, weight {this.Weight}";
        }
    }
}
