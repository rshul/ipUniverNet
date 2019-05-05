using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SRR.UIP.HW9.LandCalculator.Shared.Interfaces
{
    public interface ILandCalculator
    {
        long CalculateLandArea(List<Point> points, bool isAltAppr = true);
    }
}
