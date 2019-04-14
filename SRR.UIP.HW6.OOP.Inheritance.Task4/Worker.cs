using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
    class Worker
    {
        public string Name { get; private set; }
        public string Qualification { get; }
        public int Salary { get; private set; }
        public int Productivity { get; }
        public int UsedWorkingUnits { get; private set; }

        public Worker(string name, WorkerQualification workerQualification, int salary)
        {
            this.Qualification = workerQualification.ToString();
            this.Productivity = (int)workerQualification;
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
