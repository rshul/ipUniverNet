using SRR.UIP.HW9.LandCalculator.BLL.Services;
using SRR.UIP.HW9.LandCalculator.Shared.Interfaces;
using SRR.UIP.HW9.LandCalculator.Shared.Models;
using SRR.UIP.HW9.LandCalculator.Shared.Services;
using SRR.UIP.HW9.LandCalculator.UI.WPFUI.CustomControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SRR.UIP.HW9.LandCalculator.UI.WPFUI
{
    /// <summary>
    /// Interaction logic for LandCalculatorUI.xaml
    /// </summary>
    public partial class LandCalculatorUI : UserControl
    {
        public ILandCalculator LandCalculator { get; set; }
        public IPointsValidator PointsValidator { get; set; }
        public ILogger Logger { get; set; }

        public LandCalculatorUI()
        {
            InitializeComponent();
            LandCalculator = new LandAreaCalculator();
            PointsValidator = new PointsValidator();
            Logger = new Logger();

        }


        private void CalculateClick(object sender, RoutedEventArgs e)
        {
            Logger.Fatal($"[{this.GetType().Name}]: CalculateClick");
            long result = CalculateArea(GetPoints());
            if (result != -1)
            {
                MessageBox.Show($"Calculation result {result}");
            }
        }

        private long CalculateArea(List<Point> points)
        {
            if (this.LandCalculator == null)
            {
                MessageBox.Show("No land calculator added");
                return -1;
            }
            if (points.Count == 0)
            {
                MessageBox.Show("Wrong input. Be carefull");
                return -1;
            }
            PointsValidationResult pValidation = PointsValidator.GetValidationResult(points);
            if (!pValidation.ArePointsValid)
            {
                MessageBox.Show($"Points not valid: {pValidation.Message}");
                return -1;
            }
            bool isCalculationSuccessfull = LandCalculator.CalculateLandArea(points, true) == LandCalculator.CalculateLandArea(points, false);
            if (!isCalculationSuccessfull)
            {
                MessageBox.Show("Calculation is not successful");
                return -1;
            }

            return LandCalculator.CalculateLandArea(points);
        }
        private void AddPointClick(object sender, RoutedEventArgs e)
        {
            PointInput ptIn = new PointInput();
            ptIn.DeletePointInput += (object pi, EventArgs _) => this.PointInputsCollection.Children.Remove((PointInput)pi);
            PointInputsCollection.Children.Add(ptIn);
        }

        public List<Point> GetPoints()
        {
            List<Point> points = new List<Point>();
            foreach (var pointInput in this.PointInputsCollection.Children)
            {
                var ptIn = pointInput as PointInput;
                if (ptIn != null)
                {
                    if (ptIn.IsParsableToPoint)
                    {
                        points.Add(ptIn.GetPoint());
                    }
                    else
                    {
                        points.Clear();
                        return points;
                    }
                }
            }
            return points;
        }
    }
}
