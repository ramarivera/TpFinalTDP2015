using Common.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Persistence.EntityFramework.Configuration;
using System.Data;

namespace TpFinalTDP2015.Persistence.EntityFramework
{
    public class DigitalSignageContext : DbContext, IDbContext
    {
        private static readonly ILog cLogger = LogManager.GetLogger<DigitalSignageContext>();

        public virtual IDbSet<Campaign> Campaigns { get; set; }
        public virtual IDbSet<Banner> Banners { get; set; }
        public virtual IDbSet<RssItem> RssItems { get; set; }
        public virtual IDbSet<RssSource> RssSources { get; set; }
        public virtual IDbSet<StaticText> Texts { get; set; }
        public virtual IDbSet<Slide> Slides { get; set; }
        public virtual IDbSet<TimeInterval> TimeIntervals { get; set; }
        public virtual IDbSet<DateInterval> DateIntervals { get; set; }
        public virtual IDbSet<Day> Days { get; set; }


        public DigitalSignageContext() : base(EFConfiguration.ConnectionString)
        {
            //  this.Configuration.ProxyCreationEnabled = false;
            // this.Configuration.LazyLoadingEnabled = false;
            
            this.Database.Log = (str => LogManager.GetLogger<System.Data.Entity.DbContext>().DebugFormat(str));

            Database.SetInitializer<DigitalSignageContext>(new DigitalSignageInitializer());

            cLogger.InfoFormat("Conexion establecida a: {0}", this.Database.Connection.ConnectionString);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            EFConfiguration.Configure(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var lDayEntityEntries = ChangeTracker.Entries<BaseEntity>();

            foreach (var item in lDayEntityEntries)
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.CreationDate = DateTime.Now;
                }
                if (item.State == EntityState.Added || item.State == EntityState.Modified)
                {
                    item.Entity.LastModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        #region IDbContext
        DbContextTransaction IDbContext.BeginTransaction(IsolationLevel pIsolationLevel)
        {
            return this.Database.BeginTransaction(pIsolationLevel);
        }

        int IDbContext.SaveChanges()
        {
            return this.SaveChanges();
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return this.Set<TEntity>();
        }

        DbEntityEntry<TEntity> IDbContext.Entry<TEntity>(TEntity pEntity)
        {
            return this.Entry<TEntity>(pEntity);
        }

        Database IDbContext.Database
        {
            get
            {
                return this.Database;
            }
        }
        #endregion
    }
}
