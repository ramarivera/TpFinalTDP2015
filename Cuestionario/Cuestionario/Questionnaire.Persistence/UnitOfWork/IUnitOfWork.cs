
using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using System.Data;

namespace Questionnaire.Persistence.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : IBaseEntity;

        void BeginTransaction(IsolationLevel pIsolationLevel = IsolationLevel.Serializable);

        void Commit();

        void Rollback();
    }
}
