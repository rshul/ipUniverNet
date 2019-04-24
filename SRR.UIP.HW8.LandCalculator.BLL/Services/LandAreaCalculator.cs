using SRR.UIP.HW8.LandCalculator.Shared;
using SRR.UIP.HW8.LandCalculator.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW8.LandCalculator.BLL.Services
{
    public class LandAreaCalculator : ILandCalculator
    {
        public int CalculateLandArea(List<Point> points)
        {
            StaticInjector.Logger.Info("result = 0");
            return 0;
        }
    }
}
