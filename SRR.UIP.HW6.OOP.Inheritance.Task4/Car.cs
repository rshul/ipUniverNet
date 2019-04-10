using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
    class Car:Aggregate
    {
        public Car() : base("NoNameCar", 10) { }
        public Car(int numberOfDetails) : base("NoNameCar", numberOfDetails) { }
        
    }
}
