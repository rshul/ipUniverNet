using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW5.OOP.Factory
{
    class Car
    {
        public string Name { get; private set; }
        public int WorkingCost { get; private set; }
        public int StateOfReadinessCount { get; private set; }
        public bool IsCompleted
        {
            get
            {
                return StateOfReadinessCount == WorkingCost;
            }
        }
        public int GeneralProductionCosts { get; private set; }

        public Car():this("NoNameCar", 10) { }
        public Car(int numberOfDetails):this("NoNameCar", numberOfDetails){}

        public Car(string name, int workingCost)
        {
            this.StateOfReadinessCount = 0;
            this.Name = name;
            this.WorkingCost = workingCost;
            this.GeneralProductionCosts = 0;
        }

        public void BuildAggregate()
        {
            if (!this.IsCompleted)
            {
                StateOfReadinessCount++;
            }
        }

        public void IncreaseProductionCosts(int additionalCosts)
        {
            this.GeneralProductionCosts += additionalCosts;
        }
    }
}
