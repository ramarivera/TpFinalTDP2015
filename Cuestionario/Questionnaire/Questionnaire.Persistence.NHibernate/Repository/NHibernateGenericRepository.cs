using NHibernate;
using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using System;
using System.Linq;

namespace Questionnaire.Persistence.NHibernate.Repository
{
    public class NHibernateGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : IBaseEntity
    {
        private readonly ISession iSession;

        public NHibernateGenericRepository(ISession pSession)
        {
            this.iSession = pSession;
        }

        public void Add(TEntity pEntityToAdd)
        {
            if (pEntityToAdd == null) throw new ArgumentNullException(nameof(pEntityToAdd));

            this.iSession.Save(pEntityToAdd);
        }

        public void DeleteById(object pId)
        {
            if (pId == null) throw new ArgumentNullException(nameof(pId));

            var lEntity = this.GetById(pId);
            this.Delete(lEntity);
        }

        public void Delete(TEntity pEntityToDelete)
        {
            if (pEntityToDelete == null) throw new ArgumentNullException(nameof(pEntityToDelete));

            this.iSession.Delete(pEntityToDelete);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.iSession.Query<TEntity>();
        }

        public TEntity GetById(object pId)
        {
            if (pId == null) throw new ArgumentNullException(nameof(pId));

            return this.iSession.Get<TEntity>(pId);
        }

        public void Update(TEntity pEntityToUpdate)
        {
            if (pEntityToUpdate == null) throw new ArgumentNullException(nameof(pEntityToUpdate));

            this.iSession.Update(pEntityToUpdate);
        }
    }
}
