using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.CrossCutting.DependencyInjection;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;
using MarrSystems.TpFinalTDP2015.Persistence;
using MarrSystems.TpFinalTDP2015.Persistence.EntityFramework;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;
using MarrSystems.TpFinalTDP2015.Model;
using Common.Logging;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using MarrSystems.TpFinalTDP2015.CrossCutting;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic
{
    public static class BootStrap
    {
        private static readonly ILog cLogger = LogManager.GetLogger(typeof(BootStrap));
        private static IUnityContainer cContainer;


        public static void Configure()
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", "TpFinalTDP2015.config");
            AutoMapperConfiguration.Configure();
            InitializeContainer();
            ConfigureContainer();
            //   BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<BannerService>());
            //   BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<StaticTextService>());
            //   BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<CampaignService>());
            //   BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<ScheduleService>());
            //   BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<RssSourceService>());


        }

        private static void InitializeContainer()
        {
            cContainer = new UnityContainer();
        }

        private static void ConfigureContainer()
        {
            cContainer.
                AddNewExtension<Interception>().
                    Configure<Interception>().
                    AddPolicy("Logging").
                    AddMatchingRule<AssemblyMatchingRule>(
                        new InjectionConstructor(
                            new InjectionParameter(typeof(IPersistenceFactory).Assembly))).
                    AddMatchingRule<AssemblyMatchingRule>(
                        new InjectionConstructor(
                            new InjectionParameter(typeof(BootStrap).Assembly))).
                    AddCallHandler<LoggingCallHandler>(
                        new ContainerControlledLifetimeManager(),
                        new InjectionConstructor(),
                        new InjectionProperty("Order", 1));

            cContainer.LoadConfiguration("Registrations");


            cContainer.RegisterInstance(cContainer.Resolve<IPersistenceFactory>("IPersistenceFactory"));
        }



        public static IControllerFactory GetControllerFactory()
        {
            //TODO CAMBIAR NOMBREEEEEE


            cContainer.RegisterInstance(typeof(IUnityContainer), "IUnityContainer", cContainer, new ContainerControlledLifetimeManager());


            



            var aux = (IControllerFactory)cContainer.Resolve(typeof(IControllerFactory));
            // var chau = uni.Resolve<IRepository<StaticText>>();
            //var hola = uni.Resolve<StaticTextService>();

            var hel = cContainer.Resolve<IStaticTextService>();
            var st = hel.Read(1);

            var hola = cContainer.Registrations;
            int i = 0;
            cLogger.Debug("Registrations:");
            foreach (var item in hola)
            {
                cLogger.DebugFormat("\t[{4}] {0}: {1} => {2} ({3}) ",
                    item.Name ?? "Unnamed", item.RegisteredType, item.MappedToType, item.LifetimeManager, i++);
            }

            var con = aux.GetController(typeof(ManageBannerHandler));

            return aux;
            //return aux;
            //    throw new NotImplementedException();
        }
    }
}
