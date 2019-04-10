using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
    class Plant
    {
        public string PlantName { get; private set; }
        public List<Worker> Workers { get; set; }
        public List<Order> Orders { get; set; }
        public Country PlantCountry { get; private set; }

        public Plant(Country plantCountry) : this(plantCountry, "NoNamePlant") { }

        public Plant(Country plantCountry, string name)
        {
            this.PlantName = name;
            this.PlantCountry = plantCountry;
            this.Orders = this.PlantCountry.GenerateNewOrders(7);
            this.Workers = this.PlantCountry.HireWorkers(10);
        }

        public void StartYear()
        {
            for (int i = 0; i < 12; i++)
            {
                Logger.LogInfo($"month {i} started");
                StartMonth();
                Logger.LogInfo($"month {i} ended");
            }
        }

        public void StartMonth()
        {
            for (int i = 0; i < 30; i++)
            {
                Logger.LogInfo($"day {i} started");
                StartDay();
                Logger.LogInfo($"day {i} ended");
            }
        }

        public void StartDay()
        {
            foreach (var worker in this.Workers)
            {
                Logger.LogInfo($"worker {worker.Name} {worker.Qualification} started");
                Order currentOrder = GetNotCompletedOrder();
                Aggregate currentAggregate = GetNotCompletedAggregate(currentOrder);
                if (currentAggregate != null)
                {
                    int workingCapacity = worker.Productivity - worker.UsedWorkingUnits;
                    for (int i = 0; i < workingCapacity; i++)
                    {
                        worker.DoWork(currentAggregate);
                        Logger.LogInfo($"do work on {currentAggregate.Name} {currentAggregate.AttachedDetailsCount}");
                        if (currentAggregate.IsCompleted)
                        {
                            Logger.LogInfo($"Car {currentAggregate.Name} is completed. Total Costs: {currentAggregate.GeneralProductionCosts}");
                            break;
                        }
                    }
                }

                if (currentOrder.IsCompleted)
                {
                    Logger.LogInfo($"order {currentOrder.OrderID} is completed, aggregates - {currentOrder.Aggregates.Count}" +
                        $"\n --------------------------------------------\n" +
                        $"Total order costs: {currentOrder.TotalProductionCosts}\n");
                }
                Logger.LogInfo($"worker {worker.Name} {worker.Qualification} ended");
            }


        }

        private Aggregate GetNotCompletedAggregate(Order currentOrder)
        {
            foreach (var aggregate in currentOrder.Aggregates)
            {
                if (!aggregate.IsCompleted)
                {
                    return aggregate;
                }
            }
            return null;
        }

        private Order GetNotCompletedOrder()
        {
            Order currentOrder = SearchNotCompletedOrder();
            if (currentOrder == null)
            {
                this.Orders.AddRange(this.PlantCountry.GenerateNewOrders(7));
                Logger.LogInfo("Got new orders");
                currentOrder = SearchNotCompletedOrder();
            }
            return currentOrder;

        }

        private Order SearchNotCompletedOrder()
        {
            foreach (var order in this.Orders)
            {
                if (!order.IsCompleted)
                {
                    return order;
                }
            }
            return null;
        }
    }
}
