using SRR.UIP.HW9.LandCalculator.Core.DI;
using SRR.UIP.HW9.LandCalculator.Shared;
using SRR.UIP.HW9.LandCalculator.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW9.LandCalculator.UI.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var storages = AppContainer.Resolve<IEnumerable<ILogStorage>>();
            InitializeStorages(storages);

            IUIConsoleInteractor appUI = AppContainer.Resolve<IUIConsoleInteractor>();
            appUI.Start();

            Console.ReadLine();
        }

        private static void InitializeStorages(IEnumerable<ILogStorage> storageCollection)
        {
            foreach (var storage in storageCollection)
            {
                StaticInjector.Logger.LogStorages.Add(storage);
            }
        }
    }
}
