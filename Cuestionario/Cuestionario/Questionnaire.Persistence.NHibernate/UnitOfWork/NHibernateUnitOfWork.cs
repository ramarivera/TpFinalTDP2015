using NHibernate;
using Questionnaire.Model;
using Questionnaire.Persistence.NHibernate.Repository;
using Questionnaire.Persistence.Repository;
using Questionnaire.Persistence.UnitOfWork;
using System;
using System.Data;

namespace Questionnaire.Persistence.NHibernate.UnitOfWork
{
    class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory iSessionFactory;

        public NHibernateUnitOfWork(ISessionFactory pSessionFactory)
        {
            this.iSessionFactory = pSessionFactory;
        }

        protected ISession CurrentSession => this.iSessionFactory.GetCurrentSession();

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : IBaseEntity
        {
            return new NHibernateGenericRepository<TEntity>(this.iSessionFactory);
        }

        public void BeginTransaction(IsolationLevel pIsolationLevel = IsolationLevel.Serializable)
        {
            if (this.CurrentSession != null)
            {
                this.CurrentSession.BeginTransaction(pIsolationLevel);
            }
        }

        public void Commit()
        {
            if (this.CurrentSession != null && this.CurrentSession.Transaction.IsActive)
            {
                this.CurrentSession.Transaction.Commit();
            }
        }

        public void Rollback()
        {
            if (this.CurrentSession != null && this.CurrentSession.Transaction.IsActive)
            {
                this.CurrentSession.Transaction.Rollback();
            }
        }
    }
}
