using Questionnaire.Persistence.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Questionnaire.Persistence.NHibernate.Repository
{
    public class NHibernateGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public void Add(TEntity pEntityToAdd)
        {
            throw new NotImplementedException();
        }

        public void Delete(object pId)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity pEntityToDelete)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> pPredicate)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(object pId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity pEntityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
