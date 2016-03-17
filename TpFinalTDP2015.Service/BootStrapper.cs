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

namespace MarrSystems.TpFinalTDP2015.BusinessLogic
{
    public static class BootStrapper
    {
        [Log]
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


        [Log]
        public static IControllerFactory GetControllerFactory()
        {
            //TODO CAMBIAR NOMBREEEEEE
            //  var aux = IoCContainerLocator.Container.Resolve<IPersistenceFactory>();
            var uni = IoCContainerLocator.Container;
            var aux = uni.Resolve<IControllerFactory>();

            return aux;
            //return aux;
        //    throw new NotImplementedException();
        }
    }
}
