using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
    class Tank:Aggregate
    {
        public Tank() : base("NoNameTank", 10) { }
        public Tank(int numberOfDetails) : base("NoNameTank", numberOfDetails) { }
    }
}
