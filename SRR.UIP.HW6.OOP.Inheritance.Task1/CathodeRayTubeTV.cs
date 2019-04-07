using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task1
{
    class CathodeRayTubeTV:TVDevice
    {
        public double ScreenFPS { get; private set; }

        public CathodeRayTubeTV(string name, int powerConsumption, int screenDiagonal, double screenFPS) : base(name, powerConsumption, screenDiagonal)
        {
            this.ScreenFPS = screenFPS;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + $", screen diagonal{this.ScreenDiagonal}, screen FPS {this.ScreenFPS}";
        }
    }
}
