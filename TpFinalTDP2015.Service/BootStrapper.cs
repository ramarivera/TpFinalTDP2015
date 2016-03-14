using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.CrossCutting.DependencyInjection;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic
{
    public static class BootStrapper
    {
        public static void Configure()
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"TpFinalTDP2015.config");
            AutoMapperConfiguration.Configure();

            BusinessServiceLocator.Instance.Register(() => IoCContainerLocator.Container.Resolve<BannerService>());
            BusinessServiceLocator.Instance.Register(() => IoCContainerLocator.Container.Resolve<StaticTextService>());
            BusinessServiceLocator.Instance.Register(() => IoCContainerLocator.Container.Resolve<CampaignService>());
            BusinessServiceLocator.Instance.Register(() => IoCContainerLocator.Container.Resolve<ScheduleService>());
            BusinessServiceLocator.Instance.Register(() => IoCContainerLocator.Container.Resolve<RssSourceService>());


        }

        public static IControllerFactory GetControllerFactory()
        {
            //TODO CAMBIAR NOMBREEEEEE
            throw new NotImplementedException();
        }
    }
}
