using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
   abstract class Worker
    {
        public string Name { get; private set; }
        public abstract string Qualification { get; }
        public int Salary { get; private set; }
        public abstract int Productivity { get; }
        public int UsedWorkingUnits { get; private set; }

        public Worker(string name, int salary)
        {
            this.Name = name;
            this.Salary = salary;
            this.UsedWorkingUnits = 0;
        }
        public void DoWork(Aggregate takenAggregate)
        {
            takenAggregate.BuildAggregate();
            takenAggregate.IncreaseProductionCosts(this.Salary);
            GetTired();
        }
 
        private void GetTired()
        {
            int incrementedUsedWorkingUnits = this.UsedWorkingUnits + 1;
            int usedWorkingUnitsToFullPerformance = incrementedUsedWorkingUnits % this.Productivity;
            this.UsedWorkingUnits = usedWorkingUnitsToFullPerformance;
        }
    }
}
