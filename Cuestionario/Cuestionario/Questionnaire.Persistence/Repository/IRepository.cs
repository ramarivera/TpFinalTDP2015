using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Persistence.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity GetById(object pId);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> pPredicate);

        void Add(TEntity pEntityToAdd);

        void Update(TEntity pEntityToUpdate);

        void Delete(object pId);

        void Delete(TEntity pEntityToDelete);
    }
}
