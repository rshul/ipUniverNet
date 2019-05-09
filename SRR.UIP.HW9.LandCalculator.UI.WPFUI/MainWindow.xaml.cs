using SRR.UIP.HW9.LandCalculator.Core.DI;
using SRR.UIP.HW9.LandCalculator.Shared;
using SRR.UIP.HW9.LandCalculator.Shared.Interfaces;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            StaticInjector.Logger = AppContainer.Resolve<ILogger>();
            var storages = AppContainer.Resolve<IEnumerable<ILogStorage>>();
            StaticInjector.InitializeStorages(storages);
            InitializeComponent();
            
        }

       
    }
}
