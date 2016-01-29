using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;

        void Commit();
        void Rollback();

        void BeginTransaction(IsolationLevel pIsolationLevel = IsolationLevel.Unspecified);
    }

}
