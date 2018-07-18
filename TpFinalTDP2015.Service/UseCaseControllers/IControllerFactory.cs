using System;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public interface IControllerFactory
    {
        IController GetController(Type pType);

        T GetController<T>()
            where T : class, IController;
    }
}
