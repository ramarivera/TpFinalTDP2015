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
using MarrSystems.TpFinalTDP2015.Model;
using Common.Logging;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using MarrSystems.TpFinalTDP2015.CrossCutting;
using MarrSystems.TpFinalTDP2015.CrossCutting.Logging;
using System.Dynamic;
using MarrSystems.TpFinalTDP2015.CrossCutting.InversionOfControl;
using System.Data;

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
