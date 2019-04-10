using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
    class Master:Worker
    {
        public override string Qualification { get; } = "master";
        public override int Productivity { get; } = 5;

        public Master(string name, int salary) : base(name, salary) { }
    }
}
