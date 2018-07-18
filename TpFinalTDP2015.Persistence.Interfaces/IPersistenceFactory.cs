using MarrSystems.TpFinalTDP2015.Model;
using System;

namespace MarrSystems.TpFinalTDP2015.Persistence
{
    public interface IPersistenceFactory
    {
        IUnitOfWork CreateUnitOfWork();

        IUnitOfWork GetUnitOfWork();

        IRepository<T> GetRepository<T>() where T : BaseEntity;

        IRepository<BaseEntity> GetRepository(Type pType);
    }
}
