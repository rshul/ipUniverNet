using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW5.OOP.Factory
{
    class Tank
    {
        public string Name { get; private set; }
        public int WorkingCost { get; private set; }
        public int AttachedDetailsCount { get; private set; }
        public bool IsCompleted
        {
            get
            {
                return AttachedDetailsCount == WorkingCost;
            }
        }
        public int GeneralProductionCosts { get; private set; }

        public Tank() : this("NoNameTank", 10) { }

        public Tank(int numberOfDetails) : this("NoNameTank", numberOfDetails) { }

        public Tank(string name, int workingCost)
        {
            this.AttachedDetailsCount = 0;
            this.Name = name;
            this.WorkingCost = workingCost;
            this.GeneralProductionCosts = 0;
        }

        public void BuildAggregate()
        {
            if (!this.IsCompleted)
            {
                AttachedDetailsCount++;
            }
        }

        public void IncreaseProductionCosts(int additionalCosts)
        {
            this.GeneralProductionCosts += additionalCosts;
        }

    }
}
