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

            List<ElectricDevice> devices = new List<ElectricDevice>
            {
                new Generator(3000),
                new ConsumptionDevice(700),
                new ConsumptionDevice(700),
                new ConsumptionDevice(700),
                new ConsumptionDevice(700),
                new ConsumptionDevice(700)
            };

            DevicesOperator devicesOperator = new DevicesOperator(devices);
            devicesOperator.ConnectDevices();
            devicesOperator.ShowDevices();
            devicesOperator.SupportedDevices[2].UnplugDevice();
            devicesOperator.ShowDevices();

            Console.ReadLine();
        }
    }
}
