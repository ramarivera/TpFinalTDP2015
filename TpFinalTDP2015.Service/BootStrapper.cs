using log4net;
using MarrSystems.TpFinalTDP2015.BusinessLogic.RSS;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;
using MarrSystems.TpFinalTDP2015.CrossCutting.DependencyInjection;
using MarrSystems.TpFinalTDP2015.Model.DomainServices;
using MarrSystems.TpFinalTDP2015.Persistence;
using MarrSystems.TpFinalTDP2015.Persistence.EntityFramework;
using Microsoft.Practices.Unity;
using System;
using System.Data;
using System.Linq;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic
{
    public static class BootStrap
    {
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger(typeof(BootStrap));
        private static IUnityContainer cContainer;

        public static IUnityContainer RegisterPerResolve<TFrom, TTo>(this IUnityContainer container, params InjectionMember[] injectionMembers)
        {
            return container.RegisterType(typeof(TFrom), typeof(TTo), new PerResolveLifetimeManager(), injectionMembers);
        }

        public static void Configure()
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", "TpFinalTDP2015.config");
            AutoMapperConfiguration.Configure();
            InitializeContainer();
            ConfigureContainer();
        }

        private static void InitializeContainer()
        {
            cContainer = IoCContainerLocator.Container;
        }

        private static void ConfigureContainer()
        {

            cContainer.RegisterInstance(typeof(IsolationLevel), IsolationLevel.ReadCommitted)
                      .RegisterPerResolve<IScheduleChecker, ScheduleChecker>()
                      .RegisterPerResolve<IRssReader, RawXmlRssReader>()
                      .RegisterPerResolve<IControllerFactory, ControllerFactory>()
                      .RegisterPerResolve<IUnitOfWork, EFUnitOfWork>()
                      .RegisterPerResolve<IDbContextFactory, DigitalSignageDbContextFactory>(new InjectionConstructor("DigitalSignageLocalDB"))
                      .RegisterType(typeof(IRepository<>), typeof(EFRepository<>), new PerResolveLifetimeManager())
                      .RegisterInstance<IPersistenceFactory>(cContainer.Resolve<EFPersistenceFactory>());

            cContainer.RegisterTypes(
                AllClasses.FromAssembliesInBasePath().Where(t => t.Namespace.Contains("BusinessLogic.Services")),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.PerResolve
            );

            cContainer.RegisterType<IDbContext>(
                new PerResolveLifetimeManager(),
                new InjectionFactory(c => c.Resolve<IDbContextFactory>().CreateContext())
            );
                
        }

        public static IControllerFactory GetControllerFactory()
        {
            var aux = (IControllerFactory)cContainer.Resolve(typeof(IControllerFactory));
            return aux;
        }
    }
}
