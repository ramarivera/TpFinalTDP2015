using Common.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Persistence.Interfaces;

namespace TpFinalTDP2015.Persistence.EntityFramework
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

        public EFRepository(IDbContext pContext, IDbSet<TEntity> pDbSet)
        {
            this.iContext = pContext;
            this.iDbSet = pDbSet;
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
            if (this.iContext.Entry<TEntity>(pEntityToDelete).State == EntityState.Detached)
            {
                this.iDbSet.Attach(pEntityToDelete);
            }
            this.iDbSet.Remove(pEntityToDelete);
        }

        void IRepository<TEntity>.Update(TEntity pEntityToUpdate)
        {
            var lOld = this.iDbSet.Find(pEntityToUpdate.Id);
            this.iContext.Entry<TEntity>(lOld).CurrentValues.SetValues(pEntityToUpdate);
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

    static class EFExtensionMethods
    {
        public static IQueryable<TEntity> IncludeAll<TEntity>(this IQueryable<TEntity> queryable)
        {
            var type = typeof(TEntity);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var isVirtual = property.GetGetMethod().IsVirtual;
                if (isVirtual && properties.FirstOrDefault(c => c.Name == property.Name + "Id") != null)
                {
                    queryable = queryable.Include(property.Name);
                }
            }
            return queryable;
        }
    }
}
