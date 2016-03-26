using Common.Logging;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.CrossCutting.Attributes;
using MarrSystems.TpFinalTDP2015.CrossCutting.Interceptor;
using MarrSystems.TpFinalTDP2015.Model.DomainServices;
using MarrSystems.TpFinalTDP2015.Persistence;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ControllerFactory : IControllerFactory
    {
        private static readonly ILog cLogger = LogManager.GetLogger<ControllerFactory>();

        private IServiceFactory iServFact;
        private IPersistenceFactory iPersistenceFact;
        private readonly IDictionary<Type, IController> iControllers;
        private readonly IUnityContainer iContainer;

        public ControllerFactory(IUnityContainer pContainer, IPersistenceFactory pUowFact, IServiceFactory pServFact)
        {
            this.iPersistenceFact = pUowFact;
            this.iServFact = pServFact;
            this.iControllers = new Dictionary<Type, IController>();
            this.iContainer = pContainer;

            iContainer.RegisterTypes(
                AllClasses.FromAssembliesInBasePath().Where(t => t.Namespace.Contains("BusinessLogic.Services")),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.PerResolve,
                type =>
                {
                    // If settings type, load the setting
                    if (typeof(IDomainService).IsAssignableFrom(type))
                    {
                        return new InjectionMember[]
                        {
                            new Interceptor<InterfaceInterceptor>(),
                            new InterceptionBehavior<MyBehavior>(),
                            new InjectionFactory ((c,t,n) =>
                            {
                               return this.iServFact.GetDomainService(t);
                            }),
                            
                        };
                    }
                    else if (typeof(IBusinessService).IsAssignableFrom(type))
                    {
                        return new InjectionMember[]
                        {
                            new Interceptor<InterfaceInterceptor>(),
                            new InterceptionBehavior<MyBehavior>(),
                            new InjectionFactory ((c,t,n) =>
                            {
                               return this.iServFact.GetBusinessService(t);
                            }),
                        };
                    }
                    else // Otherwise, no special consideration is needed
                    {
                        return new InjectionMember[0];
                    }
                });
        }



        public T GetController<T>() where T : IController
        {
            return (T)this.GetController(typeof(T));
        }


        public void ReleaseController(IController pController)
        {
            var lDisp = pController as IDisposable;
            if (lDisp != null)
            {
                lDisp.Dispose();
            }
        }

        public IController GetController(Type pType)
        {
            var aux = iPersistenceFact.CreateUnitOfWork();
            CompositeResolverOverride lResolvers = new CompositeResolverOverride();
            lResolvers.Add(new DependencyOverride<IUnitOfWork>(aux));


            /*
            Pido un statictextcontroller, necesito:
                IUnitOfWork
                IServStText, necesito:
                    IRepoStText


            El poroblema que tengo es que unity no puede resolver los repos, 
            ni darse uenta que los repos se tienen que sincronizar con la uow
            */

            var chau = iContainer.Resolve<IStaticTextService>(lResolvers);
            return iContainer.Resolve(pType, lResolvers) as IController;

        }
    }

    /*
          private IServiceFactory iServFact;
        private IUnitOfWorkFactory iUowFactory;
        private readonly Dictionary<int, IDictionary<Type, IController>> iClients;

        internal ControllerFactory(IUnitOfWorkFactory pUowFact, IServiceFactory pServFact)
        {
            this.iUowFactory = pUowFact;
            this.iServFact = pServFact;
            this.iClients = new Dictionary<int, IDictionary<Type, IController>>();
        }


        public void RegisterAsClient(IControllerClient pClient)
        {
            this.iClients[pClient. .GetHashCode()] = new Dictionary<Type, IController>();
        }


        public T GetControllerForClient<T>(Object pClient) where T :IController
        {
            T lResult;
            IDictionary<Type, IController> lClientControllers;

            if (iClients.TryGetValue(pClient.GetHashCode(), out lClientControllers))
            {
                IController lController;
                if (lClientControllers.TryGetValue(typeof(T),out lController))
                {
                    lResult = (T) lController;
                }
                else
                {
                    // aCA DE alguna manera magica CREO EL CONTROLADOR PEDIDO


                    lResult = (T) (new object());
                }

            }
            else
            {
                throw new Exception();
            }

            return lResult;

        }


        public void ReleaseControllersForClient(Object pClient)
        {
            foreach (var item in iClients[pClient.GetHashCode()])
            {
                var lDisp = item.Value as IDisposable;
                if (lDisp != null)
                {
                    lDisp.Dispose();
                }
            }
        }

    */
}
