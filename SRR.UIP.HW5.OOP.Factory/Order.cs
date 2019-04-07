using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW5.OOP.Factory
{
    class Order
    {
        public Guid OrderID { get; private set; }
        public List<Car> Cars { get; set; }
        public List<Tank> Tanks { get; set; }
        public bool IsCompleted
        {
            get
            {
                if (Cars == null || Tanks == null)
                {
                    return false;
                }
                foreach (var car in this.Cars)
                {
                    if (!car.IsCompleted)
                    {
                        return false;
                    }
                }
                foreach (var tank in this.Tanks)
                {
                    if (!tank.IsCompleted)
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
                if (Cars == null || Tanks == null)
                {
                    return 0;
                }
                int totalCosts = 0;
                foreach (var car in this.Cars)
                {
                    totalCosts += car.GeneralProductionCosts;
                }
                foreach (var tank in this.Tanks)
                {
                    totalCosts += tank.GeneralProductionCosts;
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
