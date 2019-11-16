using NHibernate;
using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Persistence.NHibernate.Repository
{
    public class NHibernateGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : IBaseEntity
    {
        private readonly ISession iSession;
        private readonly ISessionFactory iSessionFactory;

        protected NHibernateGenericRepository(ISession pSession)
        {
            this.iSession = pSession;
        }

        public NHibernateGenericRepository(ISessionFactory pSessionFactory)
        {
            this.iSessionFactory = pSessionFactory;
        }

        private ISession Session => this.iSession ?? this.iSessionFactory.GetCurrentSession();

        public async Task AddAsync(TEntity pEntityToAdd)
        {
            if (pEntityToAdd == null) throw new ArgumentNullException(nameof(pEntityToAdd));

            await this.Session.SaveAsync(pEntityToAdd);
        }

        public async Task DeleteByIdAsync(object pId)
        {
            if (pId == null) throw new ArgumentNullException(nameof(pId));

            var lEntity = await this.GetByIdAsync(pId);
            await this.DeleteAsync(lEntity);
        }

        public Task DeleteAsync(TEntity pEntityToDelete)
        {
            if (pEntityToDelete == null) throw new ArgumentNullException(nameof(pEntityToDelete));

            return this.Session.DeleteAsync(pEntityToDelete);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.Session.Query<TEntity>();
        }

        public Task<TEntity> GetByIdAsync(object pId)
        {
            if (pId == null) throw new ArgumentNullException(nameof(pId));
            return this.Session.GetAsync<TEntity>(pId);
        }

        public async Task UpdateAsync(TEntity pEntityToUpdate)
        {
            if (pEntityToUpdate == null) throw new ArgumentNullException(nameof(pEntityToUpdate));

            await this.Session.UpdateAsync(pEntityToUpdate);
        }
    }
}
