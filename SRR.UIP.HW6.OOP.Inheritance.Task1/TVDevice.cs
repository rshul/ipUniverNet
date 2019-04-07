using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task1
{
    class TVDevice:Device
    {
        public int ScreenDiagonal { get; private set; }
        public TVDevice(string name, int powerConsumption, int screenDiagonal):base(name, powerConsumption)
        {
            this.ScreenDiagonal = screenDiagonal;
        }
    }
}
