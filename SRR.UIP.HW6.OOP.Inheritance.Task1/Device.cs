using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task1
{
    abstract class  Device
    {
        public string Name { get; private set; }
        public int PowerConsumption { get; private set; }
        public Device(string name, int powerConsumption)
        {
            this.Name = name;
            this.PowerConsumption = powerConsumption;
        }
        public static int TotalPowerConsumption(params Device[] devices)
        {
            int sumOfPowerConsumption = 0;
            foreach (var device in devices)
            {
                sumOfPowerConsumption += device.PowerConsumption;
            }
            return sumOfPowerConsumption;
        }
    }
}
