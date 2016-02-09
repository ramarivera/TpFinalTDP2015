using Common.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Persistence.EntityFramework.Configuration;

namespace TpFinalTDP2015.Persistence.EntityFramework
{
    public class DigitalSignageContext : DbContext
    {
        private static readonly ILog cLogger = LogManager.GetLogger<DigitalSignageContext>();

        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<RssItem> RssItems { get; set; }
        public virtual DbSet<RssSource> RssSources { get; set; }
        public virtual DbSet<StaticText> Texts { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<TimeInterval> TimeIntervals { get; set; }
        public virtual DbSet<DateInterval> DateIntervals { get; set; }
        public virtual DbSet<Day> Days { get; set; }


        public DigitalSignageContext() : base()
        {
            Database.SetInitializer<DigitalSignageContext>(new DigitalSignageInitializer());

            cLogger.Info("Conexion establecida: ConnectionString" + this.Database.Connection.ConnectionString);
        }

        public DigitalSignageContext(string pConnectionString) : base(pConnectionString)
        {
          //  this.Configuration.ProxyCreationEnabled = false;
           // this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<DigitalSignageContext>(new DigitalSignageInitializer());

            // cLogger.InfoFormat("Deberia estarme conectando usando \"{0}\"", pConnectionString);
            // cLogger.InfoFormat("Conexion establecida: {0}", this.Database.Connection.ConnectionString);
            cLogger.InfoFormat("Conexion establecida a: {0}", pConnectionString);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            EFConfiguration.Configure(modelBuilder);

            //   base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
          /*  var lDayEntityEntries = ChangeTracker.Entries<Day>();

            bool lSaveDays = (lDayEntityEntries != null) &&         //Si no hay dias cargados en el contexto actual
                             (Days.Count() == 0);                   //Y ya hay 7 dias en la DB

            if (!lSaveDays)
            {
                foreach (var entry in lDayEntityEntries)
                {
                    entry.State = EntityState.Detached;
                    //entry.Entity.ModifiedDate = DateProvider.GetCurrentDate();
                }
            }

            var added = this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            */


            return base.SaveChanges();
        }


    }
}
