using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Questionnaire.Persistence.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(object pId);

        IQueryable<TEntity> GetAll();

        Task AddAsync(TEntity pEntityToAdd);

        Task UpdateAsync(TEntity pEntityToUpdate);

        Task DeleteByIdAsync(object pId);

        Task DeleteAsync(TEntity pEntityToDelete);
    }
}
