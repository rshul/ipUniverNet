using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator(1000);
            ConsumptionDevice device1 = new ConsumptionDevice(700);
            ConsumptionDevice device2 = new ConsumptionDevice(700);
            ConsumptionDevice device3 = new ConsumptionDevice(700);
            ConsumptionDevice device4 = new ConsumptionDevice(700);

            generator.PlugDevice(device1);
            device1.PlugDevice(device2);
            device2.PlugDevice(device3);
            device3.PlugDevice(device4);

            Console.ReadLine();
        }
    }
}
