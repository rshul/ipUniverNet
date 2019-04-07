using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Laptop laptopLenovo = new Laptop("Lenovo", 50, 16, 2);
            Laptop laptopSamsung = new Laptop("Samsung", 60, 32, 3);

            Server serverDell = new Server("Dell", 1000, 48, 4);
            Server serverHPE = new Server("Hewlett Packard Enterprise", 950, 32, 2);

            PlasmaTV plasmaSamsung = new PlasmaTV("Samsung", 500, 50, "4000 X 3000");
            PlasmaTV plasmaToshiba = new PlasmaTV("Toshiba", 400, 42, "3000 X 2000");

            CathodeRayTubeTV cathodeRayTubeLG = new CathodeRayTubeTV("LG", 400, 42, 2.0);
            CathodeRayTubeTV cathodeRayTubeVega = new CathodeRayTubeTV("Vega", 300, 40, 2.5);

            Player playerApple = new Player("Apple", 10, new string[] { "mp3", "wav" });
            Player playerSamsung = new Player("Samsung", 15, new string[] { "mp3", "ogg", "aac" });

            Console.WriteLine(laptopLenovo.GetDescription());
            Console.WriteLine(laptopSamsung.GetDescription());
            Console.WriteLine(serverDell.GetDescription());
            Console.WriteLine(serverHPE.GetDescription());

            Console.WriteLine(plasmaSamsung.GetDescription());
            Console.WriteLine(plasmaToshiba.GetDescription());
            Console.WriteLine(cathodeRayTubeLG.GetDescription());
            Console.WriteLine(cathodeRayTubeVega.GetDescription());
            Console.WriteLine(playerApple.GetDescription());
            Console.WriteLine(playerSamsung.GetDescription());

            Console.ReadKey();
        }
    }
}
