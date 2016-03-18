using System;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers
{
    public interface IDomainServiceFactory
    {
        IDomainService GetService(Type pType);

        T GetService<T>() where T : IDomainService;
    }
}