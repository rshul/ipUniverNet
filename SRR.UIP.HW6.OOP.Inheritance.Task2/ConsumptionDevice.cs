using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task2
{
    class ConsumptionDevice:ElectricDevice
    {
        public int ConsumptionPower { get; private set; }
        public override int AvailablePower
        {
            get
            {
                if (this.PreviousDevice == null)
                {
                    return 0;
                }
                return this.PreviousDevice.AvailablePower - this.ConsumptionPower;
            }
        }

        public ConsumptionDevice(int consumptionPower)
        {
            this.ConsumptionPower = consumptionPower;
        }
    }
}
