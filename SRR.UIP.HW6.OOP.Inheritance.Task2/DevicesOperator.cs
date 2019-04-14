using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task2
{
    class DevicesOperator
    {
        public List<ElectricDevice> SupportedDevices { get; private set; }

        public bool IsLessThanTwoDevices
        {
            get
            {
                if (SupportedDevices == null || this.SupportedDevices.Count == 1)
                {
                    return true;
                }
                return false;
            }
        }


        public DevicesOperator(List<ElectricDevice> devices)
        {
            this.SupportedDevices = devices;
        }

        public void ConnectDevices()
        {
            if (FindGenerator() == null || this.IsLessThanTwoDevices)
            {
                return;
            }

            
            if (!this.IsLessThanTwoDevices)
            {
                ElectricDevice previousLink = FindGenerator();
                foreach (var device in this.SupportedDevices)
                {
                    if (device is ConsumptionDevice)
                    {
                        bool isPossibleToContinue = previousLink.PlugDevice((ConsumptionDevice)device);
                        if (!isPossibleToContinue)
                        {
                            break;
                        }
                        previousLink = device;
                    }
                }
            }
        }

        public void ShowDevices()
        {
            if (IsLessThanTwoDevices)
            {
                Console.WriteLine($"No one device is connect");
                return;
            }

            Generator generator = FindGenerator();
            if (generator == null)
            {
                Console.WriteLine("Generator is absent");
                return;
            }
            ElectricDevice previousLink = generator;
            for (int i = 0; i < this.SupportedDevices.Count - 1; i++)
            {
                ElectricDevice currentDevice = previousLink.NextDevice;
                if (currentDevice == null)
                {
                    return;
                }
                Console.WriteLine($"Device id {currentDevice.DeviceId} connected with available power {currentDevice.AvailablePower}");
                previousLink = currentDevice;
            }

        }

        private Generator FindGenerator()
        {
            if (!this.IsLessThanTwoDevices)
            {
                foreach (var device in this.SupportedDevices)
                {
                    if (device is Generator)
                    {
                        return (Generator)device;
                    }
                }
                return null;

            }
            return null;
        }
    }
}
