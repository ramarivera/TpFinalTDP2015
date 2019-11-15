﻿using NHibernate;
using Questionnaire.Persistence.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Persistence.NHibernate.Repository
{
    public class NHibernateGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly ISession iSession;

        public NHibernateGenericRepository(ISession pSession)
        {
            this.iSession = pSession;
        }

        public async Task AddAsync(TEntity pEntityToAdd)
        {
            if (pEntityToAdd == null) throw new ArgumentNullException(nameof(pEntityToAdd));

            await this.iSession.SaveAsync(pEntityToAdd);

            return;
        }

        public async Task DeleteByIdAsync(object pId)
        {
            if (pId == null) throw new ArgumentNullException(nameof(pId));

            var lEntity = await this.GetByIdAsync(pId);
            await this.DeleteAsync(lEntity);

            return;
        }

        public Task DeleteAsync(TEntity pEntityToDelete)
        {
            if (pEntityToDelete == null) throw new ArgumentNullException(nameof(pEntityToDelete));

            return this.iSession.DeleteAsync(pEntityToDelete);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.iSession.Query<TEntity>();
        }

        public Task<TEntity> GetByIdAsync(object pId)
        {
            if (pId == null) throw new ArgumentNullException(nameof(pId));
            return this.iSession.GetAsync<TEntity>(pId);
        }

        public async Task UpdateAsync(TEntity pEntityToUpdate)
        {
            if (pEntityToUpdate == null) throw new ArgumentNullException(nameof(pEntityToUpdate));

            await this.iSession.UpdateAsync(pEntityToUpdate);

            return;
        }
    }
}
