using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task2
{
    class Generator:ElectricDevice
    {
        public int GeneratedPower { get; private set; }

        public override int AvailablePower
        {
            get
            {
                return this.GeneratedPower;
            }
        }

        public Generator(int generatedPower)
        {
            this.GeneratedPower = generatedPower;
        }


    }
}
