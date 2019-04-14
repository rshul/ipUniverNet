using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task1
{
    abstract class  Device
    {
        private static int NumerationCounterOfDevices { get; set; }
        private int deviceId;
        public int DeviceId
        {
            get
            {
                return deviceId;
            }
            private set
            {
                this.IsSetDeviceId = true;
                this.deviceId = value;
            }
        }
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
            this.DeviceId = NumerationCounterOfDevices++;
            this.Name = name;
            this.PowerConsumption = powerConsumption;
        }

        public static int CountTotalPowerConsumption(IEnumerable<Device> devices)
        {
            int sumOfPowerConsumption = 0;
            foreach (var device in devices)
            {
                sumOfPowerConsumption += ((Device)device).PowerConsumption;
            }
            return sumOfPowerConsumption;
        }

        public static int CountTotalRamOfDevices(IEnumerable<Device> devices)
        {
            int sumOfDevicesRam = 0;
            foreach (var device in devices)
            {
                if (device is ComputerDevice computerDevice)
                {    
                    sumOfDevicesRam += computerDevice.Ram;
                }
            }
            return sumOfDevicesRam;
        }

       
    }
}
