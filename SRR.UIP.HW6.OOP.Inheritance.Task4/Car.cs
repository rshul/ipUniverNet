using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
    class Car:Aggregate
    {
        public double EngineVolume { get; private set; }
        public Car() : base("NoNameCar", 10) { }
        public Car(int numberOfDetails, double engineVolume) : base("NoNameCar", numberOfDetails)
        {
            this.EngineVolume = engineVolume;
        }
        
    }
}
