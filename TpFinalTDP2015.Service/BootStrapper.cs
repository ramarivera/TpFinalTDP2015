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
using MarrSystems.TpFinalTDP2015.CrossCutting.Logging;
using System.Dynamic;
using MarrSystems.TpFinalTDP2015.CrossCutting.InversionOfControl;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic
{
    public static class BootStrap
    {
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger(typeof(BootStrap));
        private static IUnityContainer cContainer;


        public static void Configure()
        {
            cLogger.DebugFormat("Srasa, sarasa");
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
                AddNewExtension<BuildTracking>().
                AddNewExtension<LogCreation>().
                AddNewExtension<Interception>().
                LoadConfiguration("Registrations");



            cContainer.RegisterInstance(cContainer.Resolve<IPersistenceFactory>("IPersistenceFactory"));


            cContainer.RegisterType(typeof(IRepository<>),
                                new PerResolveLifetimeManager(),

              new InjectionFactory((c, t, n) =>
              {
                  var lRepoType = t.IsGenericType ? t.GenericTypeArguments[0] : null;
                  var met = typeof(IPersistenceFactory).GetMethods().
                  FirstOrDefault(m => m.IsGenericMethod && m.Name == "GetRepository").MakeGenericMethod(lRepoType);
                  return met.Invoke(c.Resolve<IPersistenceFactory>(),
                      new object[] { });
              }),
              new Interceptor<InterfaceInterceptor>(),
              new InterceptionBehavior<PolicyInjectionBehavior>()
              );

            cContainer.RegisterTypes(
                AllClasses.FromAssembliesInBasePath().Where(t => t.Namespace.Contains("BusinessLogic.Services")),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.PerResolve,
                type =>
                {
                    cLogger.TraceFormat("Ejecutando funcion para el tipo {0}", type);
                    return new InjectionMember[]
                        {
                            new Interceptor<InterfaceInterceptor>(),
                            new InterceptionBehavior<PolicyInjectionBehavior>(),
                        };
                });

            cContainer.RegisterType(typeof(IUnitOfWork),
              new PerResolveLifetimeManager(),
              new InjectionMember[]
              {
                  new InjectionFactory((c, t, n) => c.Resolve<IPersistenceFactory>().CreateUnitOfWork()),
                  new InterceptionBehavior<PolicyInjectionBehavior>(),
                  new Interceptor<InterfaceInterceptor>()
              });

            cContainer.
                Configure<Interception>().
                AddPolicy("PersistenceLogging").
                AddMatchingRule<AssemblyMatchingRule>(
                    new InjectionConstructor(
                        new InjectionParameter(typeof(IPersistenceFactory).Assembly))).
                AddCallHandler<LoggingCallHandler>(
                    new ContainerControlledLifetimeManager(),
                    new InjectionConstructor(),
                    new InjectionProperty("Order", 1));

            cContainer.
                Configure<Interception>().
                AddPolicy("ServiceLogging").
                AddMatchingRule<AssemblyMatchingRule>(
                    new InjectionConstructor(
                        new InjectionParameter(typeof(BootStrap).Assembly))).
                AddCallHandler<LoggingCallHandler>(
                    new ContainerControlledLifetimeManager(),
                    new InjectionConstructor(),
                    new InjectionProperty("Order", 1));

            var uo = cContainer.Resolve<IUnitOfWork>();

            uo.BeginTransaction();
            uo.Rollback();


        }



        public static IControllerFactory GetControllerFactory()
        {
            //TODO CAMBIAR NOMBREEEEEE


            //  cContainer.RegisterInstance(typeof(IUnityContainer), "IUnityContainer", cContainer, new ContainerControlledLifetimeManager());






            var aux = (IControllerFactory)cContainer.Resolve(typeof(IControllerFactory));
            // var chau = uni.Resolve<IRepository<StaticText>>();
            //var hola = uni.Resolve<StaticTextService>();

            var hel = cContainer.Resolve<IStaticTextService>();

            var st = hel.Read(1);

            dynamic lRegistrations = new ExpandoObject().Init(
                "Registrations".Is(new List<ExpandoObject>()));

            foreach (var item in cContainer.Registrations)
            {
                lRegistrations.Registrations.Add(
                    new ExpandoObject().Init(
                        "Name".Is(item.Name ?? "Unnamed"),
                        "Registered".Is(item.RegisteredType),
                        "MappedTo".Is(item.MappedToType),
                        "LifetimeManager".Is(item.LifetimeManager)));

            }

            cLogger.Trace(StringUtils.ToJson(lRegistrations));

            return aux;
            //return aux;
            //    throw new NotImplementedException();
        }
    }
}
