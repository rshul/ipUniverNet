using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task2
{
   internal abstract class ElectricDevice
    {
        public Guid DeviceId { get; private set; }
        public abstract int AvailablePower { get; }
        public ElectricDevice NextDevice { get; private set; }
        public ElectricDevice PreviousDevice { get; private set; }

        public ElectricDevice()
        {
            this.DeviceId = Guid.NewGuid();
        }
        public virtual bool PlugDevice(ConsumptionDevice device)
        {
            if (NextDevice != null || AvailablePower < device.ConsumptionPower)
            {
                return false;
            }
            this.NextDevice = device;
            device.PreviousDevice = this;
            return true;
        }

        public virtual bool UnplugDevice()
        {
            if (this.NextDevice == null)
            {
                return false;
            }
            this.NextDevice.PreviousDevice = null;
            this.NextDevice.UnplugDevice();
            this.NextDevice = null;
            return true;

        }
    }
}
