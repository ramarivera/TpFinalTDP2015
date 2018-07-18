using MarrSystems.TpFinalTDP2015.Model;
using System;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    public class EFPersistenceFactory : IPersistenceFactory
    {
        IDbContextFactory iFactory;
        EFUnitOfWork iUoW;
        private readonly Guid guid;

        public EFPersistenceFactory(IDbContextFactory pFactory)
        {
            this.iFactory = pFactory;
            this.guid = Guid.NewGuid();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            iUoW = new EFUnitOfWork(this.iFactory.CreateContext());
            return (IRepository<T>)this.iUoW.GetRepository<T>();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return iUoW = new EFUnitOfWork(this.iFactory.CreateContext());
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return iUoW;
        }

        public IRepository<BaseEntity> GetRepository(Type pType)
        {
            if (iUoW != null)
            {
                return (IRepository<BaseEntity>)iUoW.GetRepository(pType);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
