using Microsoft.Extensions.Logging;
using NHibernate;
using Questionnaire.Model;
using Questionnaire.Persistence.Repository;
using Questionnaire.Persistence.Specification;
using Questionnaire.Utilities;
using System;
using System.Collections.Generic;
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

        public ILogger Logger { get; set; }

        public void Add(TEntity pEntityToAdd)
        {
            if (pEntityToAdd == null) throw new ArgumentNullException(nameof(pEntityToAdd));

            this.iSession.Save(pEntityToAdd);
        }

        public void Update(TEntity pEntityToUpdate)
        {
            if (pEntityToUpdate == null) throw new ArgumentNullException(nameof(pEntityToUpdate));

            this.iSession.Update(pEntityToUpdate);
        }

        public void DeleteById(int pId)
        {
            var lEntity = this.FindById(pId);
            this.Delete(lEntity);
        }

        public void Delete(TEntity pEntityToDelete)
        {
            if (pEntityToDelete == null) throw new ArgumentNullException(nameof(pEntityToDelete));

            this.iSession.Delete(pEntityToDelete);
        }

        public TEntity FindById(int pId)
        {
            return this.iSession.Get<TEntity>(pId);
        }

        public IEnumerable<TEntity> FindBy(ISpecification<TEntity> pSpecification)
        {
            if (pSpecification == null)
            {
                throw new ArgumentNullException(nameof(pSpecification));
            }

            var lFilteredQuery = this.iSession.Query<TEntity>()
                                              .Where(pSpecification.ToExpression());

            if (Logger.IsEnabled(LogLevel.Debug))   
            {
                var lQueryDebugExpression = lFilteredQuery.Expression.DebugView();
                this.Logger.LogDebug("Specification execution yielded debug expression of {lQueryDebugExpression}", pSpecification, lQueryDebugExpression);
            }

            return lFilteredQuery.ToList();
        }

        public IEnumerable<TEntity> ToList()
        {
            return this.iSession.Query<TEntity>().ToList();
        }
    }
}
