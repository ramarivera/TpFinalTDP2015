using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity pEntityToInsert);

        void Delete(object pId);

        void Delete(TEntity pEntityToDelete);

        void Update(TEntity pEntityToUpdate);

        TEntity GetByID(object pId);

        IQueryable<TEntity> GetAll(Func<TEntity, bool> pPredicate = null);
    }
}
