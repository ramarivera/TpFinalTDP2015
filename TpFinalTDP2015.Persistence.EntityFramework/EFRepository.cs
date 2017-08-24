using Common.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Persistence;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        internal IDbSet<TEntity> iDbSet;
        internal IDbContext iContext;

        public EFRepository(IDbContext pContext)
        {
            this.iContext = pContext;
            this.iDbSet = this.iContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Queryable
        {
            get
            {
                return this.iDbSet;
            }
        }

        void IRepository<TEntity>.Add(TEntity pEntityToAdd)
        {
            this.iDbSet.Add(pEntityToAdd);
        }

        void IRepository<TEntity>.Delete(object pId)
        {
            IRepository<TEntity> lRepo = this;
            TEntity entityToDelete = lRepo.GetByID(pId);
            lRepo.Delete(entityToDelete);
        }

        void IRepository<TEntity>.Delete(TEntity pEntityToDelete)
        {
            if (this.iContext.Entry(pEntityToDelete).State == EntityState.Detached)
            {
                this.iDbSet.Attach(pEntityToDelete);
            }
            this.iDbSet.Remove(pEntityToDelete);
        }

        void IRepository<TEntity>.Update(TEntity pEntityToUpdate)
        {
            var lOld = this.iDbSet.Find(pEntityToUpdate.Id);
            var lDbEntry = this.iContext.Entry(lOld);
            lDbEntry.CurrentValues.SetValues(pEntityToUpdate);
           // lDbEntry.State = EntityState.Modified;

        }

       TEntity IRepository<TEntity>.GetByID(object pId)
       {
           return this.iDbSet.Find(pId);
       }

       IQueryable<TEntity> IRepository<TEntity>.GetAll(Expression<Func<TEntity, bool>> pPredicate)
       {
           IQueryable<TEntity> lResult;

           if (pPredicate == null)
           {
                lResult = this.iDbSet.AsQueryable();
           }
           else
           {
               lResult = this.iDbSet.Where(pPredicate);
           }

           return lResult;
       }
    }

}
