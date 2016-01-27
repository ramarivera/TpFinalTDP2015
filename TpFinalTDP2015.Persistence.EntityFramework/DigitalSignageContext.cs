using Common.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
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

        public DbSet<Campaign> Campaigns;
        public DbSet<Banner> Banners;
        public DbSet<RssItem> RssItems;
        public DbSet<RssSource> RssSources;
        public DbSet<StaticText> Texts;
        public DbSet<Slide> Slides;
        public DbSet<TimeInterval> TimeIntervals;
        public DbSet<DateInterval> DateIntervals;
        public DbSet<Day> Days;


        public DigitalSignageContext() : base()
        {
            Database.SetInitializer<DigitalSignageContext>(new DigitalSignageInitializer());

            cLogger.Info("Conexion establecida: ConnectionString" + this.Database.Connection.ConnectionString);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            EFConfiguration.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


    }
}
