using SRR.UIP.HW8.LandCalculator.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW8.LandCalculator.UIConsole
{
    public class UIConsoleInteractor
    {
        private ILandCalculator LandAreaCalculator;

        public UIConsoleInteractor(ILandCalculator landAreaCalculator)
        {
            LandAreaCalculator = landAreaCalculator;
        }

        internal void Start()
        {
            List<Point> points = GetPoints();

            int landArea = LandAreaCalculator.CalculateLandArea(points);

            Console.WriteLine($"Result = {landArea}");
        }

        private List<Point> GetPoints()
        {
            return null;
        }
    }
}
