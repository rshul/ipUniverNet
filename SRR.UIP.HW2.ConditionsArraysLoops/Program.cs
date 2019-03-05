using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW2.ConditionsArraysLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();

            int newIntValue1 = randomizer.Next(-50, 50);

            Console.WriteLine(newIntValue1);
            Console.ReadLine();

        }
    }
}
