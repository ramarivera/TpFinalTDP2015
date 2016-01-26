using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Persistence.Interfaces;
using System.Linq.Expressions;
using NHibernate.Linq;

namespace TpFinalTDP2015.Persistence.NHibernate
{
    public class NHRepository<TEntity> : IRepository<TEntity>   where TEntity : BaseEntity
    {
        internal ISession iSession;
        //internal Quer iQuery;

        public NHRepository(ISession pSession)
        {
            this.iSession = pSession;
           // this.iQuery = this.iSession.Query<TEntity>()
            //TODO verificar si vale la pena DbSet y Query
        }
 
        void IRepository<TEntity>.Add(TEntity pEntityToAdd)
        {
            this.iSession.Save(pEntityToAdd);
        }

        void IRepository<TEntity>.Delete(object pId)
        {
            IRepository<TEntity> lRepo = (IRepository<TEntity>)this;
            TEntity entityToDelete = lRepo.GetByID(pId);
            lRepo.Delete(entityToDelete);
        }

        void IRepository<TEntity>.Delete(TEntity pEntityToDelete)
        {
            this.iSession.Delete(pEntityToDelete);
        }

        void IRepository<TEntity>.Update(TEntity pEntityToUpdate)
        {
            this.iSession.Update(pEntityToUpdate);
        }

        TEntity IRepository<TEntity>.GetByID(object pId)
        {
           return this.iSession.Get<TEntity>(pId);
        }

        IQueryable<TEntity> IRepository<TEntity>.GetAll(Expression<Func<TEntity, bool>> pPredicate)
        {
            IQueryable<TEntity> lResult;

            if (pPredicate == null)
            {
                lResult = this.iSession.Query<TEntity>();
            }
            else
            {
                lResult = this.iSession.Query<TEntity>().Where<TEntity>(pPredicate);
            }

            return lResult;
        }
    }
}
