﻿using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.CrossCutting.DependencyInjection;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic
{
    public static class BootStrapper
    {
        public static void Configure()
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"TpFinalTDP2015.config");
            AutoMapperConfiguration.Configure();

            BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<BannerService>());
            BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<StaticTextService>());
            BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<CampaignService>());
            BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<ScheduleService>());
            BusinessServiceLocator.Register(() => IoCContainerLocator.Container.Resolve<RssSourceService>());


        }
    }
}