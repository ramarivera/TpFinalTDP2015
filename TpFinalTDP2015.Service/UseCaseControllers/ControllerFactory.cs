using Common.Logging;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.CrossCutting.Attributes;
using MarrSystems.TpFinalTDP2015.CrossCutting.Logging;
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
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger<ControllerFactory>();

        private IPersistenceFactory iPersistenceFact;
        private readonly IDictionary<Type, IController> iControllers;
        private readonly IUnityContainer iContainer;

        public ControllerFactory(IUnityContainer pContainer, IPersistenceFactory pUowFact)
        {
            this.iPersistenceFact = pUowFact;
            this.iControllers = new Dictionary<Type, IController>();
            this.iContainer = pContainer;

            
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
            return iContainer.Resolve(pType) as IController;
        }
    }

}
