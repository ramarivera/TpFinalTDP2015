using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    public interface IDbContext : IDisposable
    {
        Database Database { get; }
        DbContextTransaction BeginTransaction(IsolationLevel pIsolationLevel);
        int SaveChanges();
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity pEntity) where TEntity : BaseEntity;
    }
}
