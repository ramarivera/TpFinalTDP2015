using Questionnaire.Persistence.Repositories;

namespace Questionnaire.Persistence.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
