using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
    class Order
    {
        public Guid OrderID { get; private set; }
        public List<Aggregate> Aggregates { get; set; }
        
        public bool IsCompleted
        {
            get
            {
                if (this.Aggregates == null)
                {
                    return false;
                }
                foreach (var aggregate in this.Aggregates)
                {
                    if (!aggregate.IsCompleted)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public int TotalProductionCosts
        {
            get
            {
                if (this.Aggregates == null)
                {
                    return 0;
                }
                int totalCosts = 0;
                foreach (var aggregate in this.Aggregates)
                {
                    totalCosts += aggregate.GeneralProductionCosts;
                }
                return totalCosts;
            }
        }

        public Order()
        {
            this.OrderID = Guid.NewGuid();
        }

    }
}
