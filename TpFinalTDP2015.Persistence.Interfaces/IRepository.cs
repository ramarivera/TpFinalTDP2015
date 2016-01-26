using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Persistence.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity pEntityToAdd);

        void Delete(object pId);

        void Delete(TEntity pEntityToDelete);

        void Update(TEntity pEntityToUpdate);

        TEntity GetByID(object pId);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> pPredicate = null);
    }
}
