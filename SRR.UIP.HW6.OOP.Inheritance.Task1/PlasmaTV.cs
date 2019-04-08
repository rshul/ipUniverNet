using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task1
{
    class PlasmaTV : TVDevice
    {
        public string Resolution { get; private set; }

        public PlasmaTV(string name, int powerConsumption, int screenDiagonal, string resolution) : base(name, powerConsumption, screenDiagonal)
        {
            this.Resolution = resolution;
        }

        public override string ToString()
        {
            return $"Plasma TV: name {this.Name}, power consumption {this.PowerConsumption}, " +
                $"screen diagonal {this.ScreenDiagonal}, resolution {this.Resolution}. Type: {this.GetType()}";
        }
    }
}