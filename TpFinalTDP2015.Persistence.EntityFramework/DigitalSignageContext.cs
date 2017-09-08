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
using MarrSystems.TpFinalTDP2015.Model;
using System.Data;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    public class DigitalSignageContext : DbContext, IDbContext
    {
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger<DigitalSignageContext>();

        public virtual IDbSet<Campaign> Campaigns { get; set; }
        public virtual IDbSet<Banner> Banners { get; set; }
        public virtual IDbSet<RssItem> RssItems { get; set; }
        public virtual IDbSet<RssSource> RssSources { get; set; }
        public virtual IDbSet<StaticText> Texts { get; set; }
        public virtual IDbSet<Slide> Slides { get; set; }
        public virtual IDbSet<ScheduleEntry> TimeIntervals { get; set; }
        public virtual IDbSet<Schedule> DateIntervals { get; set; }

        static Random _r = new Random();

        public DigitalSignageContext(string pConnectionString) : base(pConnectionString)
        {
            Database.SetInitializer<DigitalSignageContext>(new DigitalSignageInitializer());

            this.Database.Log = (str => MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger<System.Data.Entity.DbContext>().DebugFormat(str));
            cLogger.InfoFormat("Conexion establecida a: {0}", this.Database.Connection.ConnectionString);

            this.RandomId = _r.Next(1,1000000);
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

        public int RandomId { get; private set; }
        #endregion
    }
}
