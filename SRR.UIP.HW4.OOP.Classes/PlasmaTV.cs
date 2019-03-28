using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW4.OOP.Classes.Task1
{
    class PlasmaTV
    {
        public string Name { get; private set; }
        public int PowerConsumption { get; private set; }
        public int ScreenDiagonal { get; private set; }
        public string Resolution { get; private set; }

        public PlasmaTV(string name, int powerConsumption, int screenDiagonal, string resolusion)
        {
            this.Name = name;
            this.PowerConsumption = powerConsumption;
            this.ScreenDiagonal = screenDiagonal;
            this.Resolution = resolusion;
        }
        public string GetDescription()
        {
            return $"Plasma TV: name {this.Name}, power consumption {this.PowerConsumption}, " +
                $"screen diagonal {this.ScreenDiagonal}, resolution {this.Resolution}";
        }
    }

    

}
