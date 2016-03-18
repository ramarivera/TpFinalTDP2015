using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.CrossCutting.Attributes;
using MarrSystems.TpFinalTDP2015.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public class ControllerFactory : IControllerFactory
    {
        private IServiceFactory iServFact;
        private IPersistenceFactory iUowFactory;
        private readonly IDictionary<Type, IController> iControllers;

        public ControllerFactory(IPersistenceFactory pUowFact, IServiceFactory pServFact)
        {
            this.iUowFactory = pUowFact;
            this.iServFact = pServFact;
            this.iControllers = new Dictionary<Type, IController>();
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
            Object lResult = new object();
            if (!iControllers.ContainsKey(pType))
            {
                var lCons = pType.GetConstructors().FirstOrDefault();
                if (lCons != null)
                {
                    var lArgsInfo = lCons.GetParameters();
                    int lArgsCount = lArgsInfo.Count();
                    Object[] lArgs = new Object[lArgsCount];
                    IUnitOfWork lUow = iUowFactory.CreateUnitOfWork();

                    foreach (var info in lArgsInfo)
                    {
                        object lDependency = new object();
                        Type lType = info.ParameterType;
                        bool isUnitOfWork = lType is IUnitOfWork;
                        bool isDomainService = true;
                        bool isBusinessService = true;

                        if (isUnitOfWork)
                        {
                            lDependency = lUow;
                        }
                        else if (isBusinessService)
                        {
                            lDependency = iServFact.BusinessServiceFactory.GetService(lType, lUow);
                        }
                        else if (isDomainService)
                        {
                            lDependency = iServFact.DomainServiceFactory.GetService(lType);
                        }


                        /*
                        En el peor de los casos me van a pedir un BannerHandler.
                        Depende de una UnitOfWork, y de un BannerService,
                        que a su vez depende creo de: 
                        ScheduleService, IHasScheduleValidator, StaticText, RssSources


                         */

                        lArgs[info.Position] = lDependency;
                    }

                    lResult = Activator.CreateInstance(pType, lArgs);

                    iControllers[pType] = (IController)lResult;
                }
                else
                {
                    throw new Exception();
                }

                // aCA DE alguna manera magica CREO EL CONTROLADOR PEDIDO
            }
            return (IController)lResult;
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
