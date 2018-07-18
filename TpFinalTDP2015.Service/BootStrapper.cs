using log4net;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;
using MarrSystems.TpFinalTDP2015.Persistence;
using MarrSystems.TpFinalTDP2015.Persistence.EntityFramework;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Data;
using System.Linq;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.RegistrationByConvention;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic
{
    public static class BootStrap
    {
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger(typeof(BootStrap));
        private static IUnityContainer cContainer;

        public static void Configure()
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", "TpFinalTDP2015.config");
            AutoMapperConfiguration.Configure();
            InitializeContainer();
            ConfigureContainer();
        }

        private static void InitializeContainer()
        {
            cContainer = new UnityContainer();
        }

        private static void ConfigureContainer()
        {
            cContainer.LoadConfiguration("Registrations");

            cContainer.RegisterInstance(cContainer.Resolve<IPersistenceFactory>("IPersistenceFactory"));

            cContainer.RegisterInstance(typeof(IsolationLevel), IsolationLevel.ReadCommitted);
            cContainer.RegisterType(typeof(IUnitOfWork), typeof(EFUnitOfWork), new PerResolveLifetimeManager());
            cContainer.RegisterType(typeof(IRepository<>), typeof(EFRepository<>), new PerResolveLifetimeManager());


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
