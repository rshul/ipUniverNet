using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW5.OOP.Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Country ukraine = new Country("UA");
            Plant aggregateFactory = new Plant(ukraine,"Best Agragates Ltd");
            aggregateFactory.StartYear();

            Console.ReadLine();
        }
    }
}
