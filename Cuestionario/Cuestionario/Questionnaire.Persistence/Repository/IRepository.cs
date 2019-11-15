using Questionnaire.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Persistence.Repository
{
    public interface IRepository<TEntity>
        where TEntity : IBaseEntity
    {
        Task<TEntity> GetByIdAsync(object pId);

        IQueryable<TEntity> GetAll();

        Task AddAsync(TEntity pEntityToAdd);

        Task UpdateAsync(TEntity pEntityToUpdate);

        Task DeleteByIdAsync(object pId);

        Task DeleteAsync(TEntity pEntityToDelete);
    }
}
