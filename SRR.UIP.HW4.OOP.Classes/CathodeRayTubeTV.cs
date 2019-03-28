using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW4.OOP.Classes.Task1
{
    class CathodeRayTubeTV
    {
        public string Name { get; private set; }
        public int PowerConsumption { get; private set; }
        public int ScreenDiagonal { get; private set; }
        public double ScreenFPS { get; private set; }

        public CathodeRayTubeTV(string name, int powerConsumption, int screenDiagonal, double screenFPS)
        {
            this.Name = name;
            this.PowerConsumption = powerConsumption;
            this.ScreenDiagonal = screenDiagonal;
            this.ScreenFPS = screenFPS;
        }

        public string GetDescription()
        {
            return $"Cathode ray tube TV:  {this.Name}, power consumption {this.PowerConsumption}, " +
                $"screen diagonal {this.ScreenDiagonal}, screen FPS {this.ScreenFPS}";
        }
    }
}
