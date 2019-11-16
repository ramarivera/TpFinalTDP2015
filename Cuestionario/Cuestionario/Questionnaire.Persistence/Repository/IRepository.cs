using Questionnaire.Model;
using System.Linq;

namespace Questionnaire.Persistence.Repository
{
    public interface IRepository<TEntity>
        where TEntity : IBaseEntity
    {
        TEntity GetById(object pId);

        IQueryable<TEntity> GetAll();

        void Add(TEntity pEntityToAdd);

        void Update(TEntity pEntityToUpdate);

        void DeleteById(object pId);

        void Delete(TEntity pEntityToDelete);
    }
}
