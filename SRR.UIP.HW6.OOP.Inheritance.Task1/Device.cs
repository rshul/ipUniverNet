using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task1
{
    abstract class  Device
    {
        private static int NumerationCounterOfDevices { get; set; }
        public int DeviceId { get; private set; }
        public bool IsSetDeviceId { get; private set; }
        public string Name { get; private set; }
        public int PowerConsumption { get; private set; }

        static Device()
        {
            Random randomizer = new Random();
            NumerationCounterOfDevices = randomizer.Next(0,100);
        }
        public Device(string name, int powerConsumption)
        {
            this.IsSetDeviceId = false;
            this.Name = name;
            this.PowerConsumption = powerConsumption;
        }

        public static int CountTotalPowerConsumption(params Device[] devices)
        {
            int sumOfPowerConsumption = 0;
            foreach (var device in devices)
            {
                sumOfPowerConsumption += device.PowerConsumption;
            }
            return sumOfPowerConsumption;
        }

        public static int CountTotalRamOfDevices(params Device[] devices)
        {
            int sumOfDevicesRam = 0;
            foreach (var device in devices)
            {
                if (device is ComputerDevice)
                {
                    ComputerDevice computer = (ComputerDevice)device;
                    sumOfDevicesRam += computer.Ram;
                }
            }
            return sumOfDevicesRam;
        }

        public void SetDeviceID()
        {
            this.DeviceId = NumerationCounterOfDevices++;
            this.IsSetDeviceId = true;
        }
    }
}
