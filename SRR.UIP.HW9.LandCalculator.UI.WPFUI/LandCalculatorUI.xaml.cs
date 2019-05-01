using SRR.UIP.HW9.LandCalculator.UI.WPFUI.CustomControls;
using System;
using System.Collections.Generic;
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
        public LandCalculatorUI()
        {
            InitializeComponent();
        }

        private void CalculateClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Calculation");
        }

        private void AddPointClick(object sender, RoutedEventArgs e)
        {
            PointInput ptIn = new PointInput();
            PointInputsCollection.Children.Add(ptIn);
        }

        internal List<Point> GetPoints()
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
