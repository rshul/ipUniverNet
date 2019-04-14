using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
    class Tank:Aggregate
    {
        public int OutputPower { get; private set; }
        public Tank() : base("NoNameTank", 10) { }
        public Tank(int numberOfDetails, int outputPower) : base("NoNameTank", numberOfDetails)
        {
            this.OutputPower = outputPower;
        }
    }
}
