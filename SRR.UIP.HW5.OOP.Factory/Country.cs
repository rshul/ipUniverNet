using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW5.OOP.Factory
{
    class Country
    {
        public string Name { get; private set; }

        public Country(string name)
        {
            this.Name = name;
        }

       public List<Order> GenerateNewOrders(int ordersCount)
        {
            if (ordersCount <= 0)
            {
                Console.WriteLine("Invalid count");
                return null;
            }
            List<Order> orders = new List<Order>();
            Random randomizer = new Random();
            for (int i = 0; i < ordersCount; i++)
            {
                orders.Add(GenerateNewOrder(randomizer));
            }
            return orders;
        }

        internal List<Worker> HireWorkers(int numberOfWorkers)
        {
            string[] workerNames = new string[8]
            {
                "Vasia",
                "Petia",
                "Vovan",
                "Slava",
                "Serhii",
                "Vania",
                "Oleh",
                "Vitia"
            };
            string[] workerQualifications = new string[3]
            {
                "newbie",
                "profi",
                "master"
            };
            Random randomizer = new Random();
            List<Worker> unemployedWorkers = new List<Worker>();

            for (int i = 0; i < numberOfWorkers; i++)
            {
                int randomWorkerName = randomizer.Next(0, 8);
                int randomWorkerQualification = randomizer.Next(0, 3);
                int randomWorkerSalary = randomizer.Next(10, 50);
                unemployedWorkers.Add(new Worker(workerNames[randomWorkerName], workerQualifications[randomWorkerQualification], randomWorkerSalary));
            }
            return unemployedWorkers;
        }

        private Order GenerateNewOrder(Random randomizer)
        {
            Order generatedOrder = new Order();
            generatedOrder.Cars = new List<Car>();
            generatedOrder.Tanks = new List<Tank>();

            int randomNumberOfCars = randomizer.Next(1,7);
            for (int i = 0; i < randomNumberOfCars; i++)
            {
                generatedOrder.Cars.Add(new Car(randomizer.Next(2,15)));
            }
            int randomNumberOfTanks = randomizer.Next(1, 7);
            for (int i = 0; i < randomNumberOfTanks; i++)
            {
                generatedOrder.Tanks.Add(new Tank(randomizer.Next(4,20)));
            }
            return generatedOrder;
        }
    }
}
