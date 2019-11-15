using NHibernate;
using Questionnaire.Persistence.NHibernate.Repository;
using Questionnaire.Persistence.Repository;
using Questionnaire.Persistence.UnitOfWork;
using System.Data;
using System.Threading.Tasks;

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

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
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

        public Task CommitAsync()
        {
            if (this.CurrentSession != null && this.CurrentSession.IsOpen)
            {
                return this.CurrentSession.Transaction.CommitAsync();
            }

            throw new System.Exception("Closed session");
        }

        public Task RollbackAsync()
        {
            if (this.CurrentSession != null && this.CurrentSession.IsOpen)
            {
                return this.CurrentSession.Transaction.RollbackAsync();
            }

            throw new System.Exception("Closed session");
        }
    }
}
