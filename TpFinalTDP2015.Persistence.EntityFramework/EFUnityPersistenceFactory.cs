using MarrSystems.TpFinalTDP2015.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    class EFUnityPersistenceFactory 
    {

        IDbContextFactory iFactory;
        EFUnitOfWork iUoW;
        private readonly IUnityContainer iContainer;

        public EFUnityPersistenceFactory(IUnityContainer pContainer,IDbContextFactory pFactory)
        {
            this.iFactory = pFactory;
            this.iContainer = pContainer;
        }

        IRepository<T> GetRepository<T>() where T : BaseEntity
        {

            return (IRepository<T>) this.GetRepository(typeof(T));
            
        }

        IUnitOfWork CreateUnitOfWork()
        {
            return iUoW = new EFUnitOfWork(this.iFactory.CreateContext());
        }

        IUnitOfWork GetLastUnitOfWork()
        {
            return iUoW;
        }

        IRepository<BaseEntity> GetRepository(Type pType)
        {
            if (iUoW != null)
            {
                return (IRepository<BaseEntity>)
                    iContainer.Resolve(typeof(EFRepository<>).MakeGenericType(pType));
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
