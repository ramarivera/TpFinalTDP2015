using MarrSystems.TpFinalTDP2015.Persistence;
using System;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public interface IBusinessServiceFactory
    {
        IBusinessService GetService(Type pType, IUnitOfWork pUoW);

        T GetService<T>(IUnitOfWork pUoW) where T : IBusinessService;

    }
}