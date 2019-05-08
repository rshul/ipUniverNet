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

namespace SRR.UIP.HW9.LandCalculator.UI.WPFUI.CustomControls
{
    /// <summary>
    /// Interaction logic for PointInput.xaml
    /// </summary>
    public partial class PointInput : UserControl
    {

        public event EventHandler DeletePointInput;
        public PointInput()
        {
            InitializeComponent();
        }

        public bool IsParsableToPoint
        {
            get
            {
                return int.TryParse(this.X.Text, out int _) && int.TryParse(this.Y.Text, out int _);
            }
        }

        internal Point GetPoint()
        {
            if (this.IsParsableToPoint)
            {
                int.TryParse(this.X.Text, out int coordX);
                int.TryParse(this.Y.Text, out int coordY);
                return new Point(coordX, coordY);
            }
            else
            {
                return new Point();

            }

        }

        private void DeleteInputPoint_Click(object sender, RoutedEventArgs e)
        {
            if (DeletePointInput == null)
            {
                return;
            }
            DeletePointInput(this, EventArgs.Empty);
        }

        private void TextChangedInInputPoint(object sender, TextChangedEventArgs e)
        {
            if (!this.IsParsableToPoint)
            {
                ValidationBlock.Visibility = Visibility.Visible;
                ValidationBlock.Text = "X OR Y value is not valid";
            }
            else
            {
                ValidationBlock.Visibility = Visibility.Collapsed;
                ValidationBlock.Text = "";
            }
        }

        
    }
}
