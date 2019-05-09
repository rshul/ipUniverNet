using Autofac;
using SRR.UIP.HW9.LandCalculator.BLL.Services;
using SRR.UIP.HW9.LandCalculator.DAL.Storages;
using SRR.UIP.HW9.LandCalculator.Shared.Interfaces;
using SRR.UIP.HW9.LandCalculator.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW9.LandCalculator.Core.DI
{
    public class AppContainer
    {
        public static IContainer _container;
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            builder.RegisterType<LandAreaCalculator>().As<ILandCalculator>().SingleInstance();
            builder.RegisterType<PointsValidator>().As<IPointsValidator>().SingleInstance();
            builder.RegisterType<ConsoleLogStorage>().As<ILogStorage>().SingleInstance();
            builder.RegisterType<FileLogStorage>().As<ILogStorage>().SingleInstance();
            builder.RegisterType<UIConsoleInteractor>().As<IUIConsoleInteractor>().SingleInstance();

            _container = builder.Build();
        }
        static AppContainer()
        {
            ConfigureContainer();
        }
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

    }
}
