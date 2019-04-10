using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
    class Profi:Worker
    {
        public override string Qualification { get; } = "profi";
        public override int Productivity { get; } = 3;

        public Profi(string name, int salary) : base(name, salary) { }
    }
}
