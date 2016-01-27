using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Persistence.Interfaces;

namespace TpFinalTDP2015.Persistence
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        internal DbSet<TEntity> iDbSet;
        internal DbContext iContext;

        public EFRepository(DbContext pContext)
        {
            this.iContext = pContext;
            this.iDbSet = this.iContext.Set<TEntity>();
        }

        void IRepository<TEntity>.Add(TEntity pEntityToAdd)
        {
            this.iContext.Set<TEntity>().Add(pEntityToAdd);
        }

        void IRepository<TEntity>.Delete(object pId)
        {
            IRepository<TEntity> lRepo = (IRepository<TEntity>)this;
            TEntity entityToDelete = lRepo.GetByID(pId);
            lRepo.Delete(entityToDelete);
        }

        void IRepository<TEntity>.Delete(TEntity pEntityToDelete)
        {
            if (this.iContext.Entry<TEntity>(pEntityToDelete).State == EntityState.Detached)
            {
                this.iDbSet.Attach(pEntityToDelete);
            }
            this.iContext.Entry<TEntity>(pEntityToDelete).State = EntityState.Deleted;
        }

        void IRepository<TEntity>.Update(TEntity pEntityToUpdate)
        {
            this.iContext.Entry<TEntity>(pEntityToUpdate).State = EntityState.Modified;
        }

        TEntity IRepository<TEntity>.GetByID(object pId)
        {
            return (TEntity) this.iDbSet.Find(pId);
        }

        IQueryable<TEntity> IRepository<TEntity>.GetAll(Expression<Func<TEntity, bool>> pPredicate)
        {
            IQueryable<TEntity> lResult;

            if (pPredicate == null)
            {
                lResult = this.iDbSet.AsQueryable<TEntity>();
            }
            else
            {
                lResult = this.iDbSet.Where(pPredicate);
            }

            return lResult;
        }
    }
}
