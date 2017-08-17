using Common.Logging;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
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
        private static readonly ILog cLogger = LogManagerWrapper.GetLogger<ControllerFactory>();

        private readonly IUnityContainer iContainer;

        public ControllerFactory(IUnityContainer pContainer)
        {
            this.iContainer = pContainer;
        }

        public T GetController<T>() where T : IController
        {
            return (T)this.GetController(typeof(T));
        }

        public IController GetController(Type pType)
        {
            return iContainer.Resolve(pType) as IController;
        }
    }

}
