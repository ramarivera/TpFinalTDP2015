using log4net;
using MarrSystems.TpFinalTDP2015.CrossCutting.Logging;
using System;
using Unity;

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

        public T GetController<T>()
            where T : class, IController
        {
            return this.GetController(typeof(T)) as T;
        }

        public IController GetController(Type pType)
        {
            return iContainer.Resolve(pType) as IController;
        }
    }

}
