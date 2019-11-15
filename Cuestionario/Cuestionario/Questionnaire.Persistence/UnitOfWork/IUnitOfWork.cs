
using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using System.Data;
using System.Threading.Tasks;

namespace Questionnaire.Persistence.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : IBaseEntity;

        void BeginTransaction(IsolationLevel pIsolationLevel);

        Task CommitAsync();

        Task RollbackAsync();
    }
}
