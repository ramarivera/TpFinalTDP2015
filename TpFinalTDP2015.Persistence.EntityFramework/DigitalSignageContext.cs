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
    class DigitalSignageContext : DbContext
    {

        public DbSet<Campaign> Campaigns;
        public DbSet<Banner> Banners;
        public DbSet<RSSItem> RssItems;
        public DbSet<RSSSource> RssSources;
        public DbSet<StaticText> Texts;
        public DbSet<Slide> Slides;
        public DbSet<TimeInterval> TimeIntervals;
        public DbSet<DateInterval> DateIntervals;


        public DigitalSignageContext() : base()
        {
            Database.SetInitializer<DigitalSignageContext>(new DigitalSignageInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            EFConfiguration.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


    }
}
