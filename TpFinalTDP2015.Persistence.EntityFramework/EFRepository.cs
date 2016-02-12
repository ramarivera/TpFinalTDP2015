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
        internal DbSet<TEntity> iDbSet;
        internal DbContext iContext;

        public EFRepository(DbContext pContext)
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
            /* if (this.iContext.Entry<TEntity>(pEntityToUpdate).State == EntityState.Detached)
             {
                 this.iDbSet.Attach(pEntityToUpdate);
             }*/
            /* EntityState lState = this.iContext.Entry<TEntity>(pEntityToUpdate).State;

            if (lState == EntityState.Detached)
            {
                this.iDbSet.Attach(pEntityToUpdate);
                this.iContext.Entry<TEntity>(pEntityToUpdate).State = EntityState.Modified;
            }
            else
            {
                this.iContext.Entry<TEntity>(pEntityToUpdate).State = EntityState.Detached;
                this.iContext.Entry<TEntity>(pEntityToUpdate).State = lState;*/


            var lOld = this.iDbSet.Find(pEntityToUpdate.Id);
            var st = this.iContext.Entry(pEntityToUpdate).State;
            var dicc = this.iContext.Entry(lOld).CurrentValues;
            dicc.SetValues(pEntityToUpdate);
            
            //    EntityState lest = this.iContext.Entry(lOld).State;


            //  this.iContext.Entry<TEntity>(pEntityToUpdate).State = EntityState.Modified;
            //  this.iDbSet
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

        


    /*    */
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
