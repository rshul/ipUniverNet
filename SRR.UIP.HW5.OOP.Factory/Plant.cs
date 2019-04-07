using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW5.OOP.Factory
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
                Tank currentTank = GetNotCompletedTank(currentOrder);
                Car currentCar = GetNotCompletedCar(currentOrder);
                if (currentCar != null)
                {
                    int workingCapacity = worker.Productivity - worker.UsedWorkingUnits;
                    for (int i = 0; i < workingCapacity; i++)
                    {
                        worker.DoWork(currentCar);
                        Logger.LogInfo($"do work on {currentCar.Name} {currentCar.AttachedDetailsCount}");
                        if (currentCar.IsCompleted)
                        {
                            Logger.LogInfo($"Car {currentCar.Name} is completed. Total Costs: {currentCar.GeneralProductionCosts}");
                            break;
                        }
                    }
                }
                else if(currentTank != null)
                {
                    int workingCapacity = worker.Productivity - worker.UsedWorkingUnits;
                    for (int i = 0; i < workingCapacity; i++)
                    {
                        worker.DoWork(currentTank);
                        Logger.LogInfo($"do work on {currentTank.Name} {currentTank.AttachedDetailsCount}");
                        if (currentTank.IsCompleted)
                        {
                            Logger.LogInfo($"Tank {currentTank.Name} is completed. Total Costs: {currentTank.GeneralProductionCosts}");
                            break;
                        }
                    }
                }
                if (currentOrder.IsCompleted)
                {
                    Logger.LogInfo($"order {currentOrder.OrderID} is completed cars{currentOrder.Cars.Count} tanks {currentOrder.Tanks.Count}" +
                        $"\n --------------------------------------------\n" +
                        $"Total order costs: {currentOrder.TotalProductionCosts}\n");
                }
                Logger.LogInfo($"worker {worker.Name} {worker.Qualification} ended");
            }


        }

        private Car GetNotCompletedCar(Order currentOrder)
        {
            foreach (var car in currentOrder.Cars)
            {
                if (!car.IsCompleted)
                {
                    return car;
                }
            }
            return null;
        }

        private Tank GetNotCompletedTank(Order currentOrder)
        {
            foreach (var tank in currentOrder.Tanks)
            {
                if (!tank.IsCompleted)
                {
                    return tank;
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
