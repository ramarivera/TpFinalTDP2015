using NHibernate;
using Questionnaire.Model;
using Questionnaire.Persistence.NHibernate.Repository;
using Questionnaire.Persistence.Repository;
using Questionnaire.Persistence.UnitOfWork;
using System.Data;

namespace Questionnaire.Persistence.NHibernate.UnitOfWork
{
    // TODO missing documentation
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
            return new NHibernateGenericRepository<TEntity>(this.CurrentSession);
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
            if (this.CurrentSession != null && this.CurrentSession.IsOpen)
            {
                this.CurrentSession.Transaction.Commit();
            }
            else
            {
                throw new System.Exception("Closed session");
            }
        }

        public void Rollback()
        {
            if (this.CurrentSession != null && this.CurrentSession.IsOpen)
            {
                this.CurrentSession.Transaction.Rollback();
            }
            else
            {
                throw new System.Exception("Closed session");
            }

        }
    }
}
