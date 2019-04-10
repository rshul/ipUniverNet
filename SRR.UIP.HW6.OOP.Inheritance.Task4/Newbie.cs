using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
    class Newbie:Worker
    {
        public override string Qualification { get;} = "newbie";
        public override int Productivity { get;} = 1;

        public Newbie(string name, int salary) : base(name, salary) { }  
    }
}
