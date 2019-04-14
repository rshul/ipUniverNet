using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task4
{
    enum WorkerQualification
    {
        Newbie = 1,
        Profi = 3,
        Master = 5
    }

    class Program
    {
        static void Main(string[] args)
        {
            Country ukraine = new Country("UA");
            Plant aggregateFactory = new Plant(ukraine, "Best Agragates Ltd");
            aggregateFactory.StartYear();

            Console.ReadLine();
        }
    }
}
