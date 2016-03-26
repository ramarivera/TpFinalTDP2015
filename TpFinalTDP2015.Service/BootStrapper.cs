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

namespace MarrSystems.TpFinalTDP2015.BusinessLogic
{
    public static class BootStrapper
    {
        private static readonly ILog cLogger = LogManager.GetLogger(typeof(BootStrapper));


        
        public static void Configure()
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE","TpFinalTDP2015.config");
            AutoMapperConfiguration.Configure();

        //   BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<BannerService>());
        //   BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<StaticTextService>());
        //   BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<CampaignService>());
        //   BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<ScheduleService>());
        //   BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<RssSourceService>());


        }


        
        public static IControllerFactory GetControllerFactory()
        {
            //TODO CAMBIAR NOMBREEEEEE
            //  var aux = IoCContainerLocator.Container.Resolve<IPersistenceFactory>();
            var uni = IoCContainerLocator.Container;

            uni.RegisterInstance(typeof(IUnityContainer),"IUnityContainer", uni, new ContainerControlledLifetimeManager());


            var hola = uni.Registrations;
            int i = 0;
            cLogger.Debug("Registrations:");
            foreach (var item in hola)
            {
                cLogger.DebugFormat("\t[{4}] {0}: {1} => {2} ({3}) ", item.Name ?? "Unnamed", item.RegisteredType, item.MappedToType, item.LifetimeManager, i++);
            }



            var aux = (IControllerFactory) uni.Resolve(typeof(IControllerFactory));
            // var chau = uni.Resolve<IRepository<StaticText>>();
            //var hola = uni.Resolve<StaticTextService>();

            var hel = uni.Resolve<IStaticTextService>();
           var st = hel.Read(1);


            var con = aux.GetController(typeof(ManageBannerHandler));

            return aux;
            //return aux;
        //    throw new NotImplementedException();
        }
    }
}
