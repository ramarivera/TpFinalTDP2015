using MarrSystems.TpFinalTDP2015.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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
