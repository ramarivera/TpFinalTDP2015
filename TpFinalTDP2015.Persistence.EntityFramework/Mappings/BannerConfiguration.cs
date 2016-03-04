using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework.Mapping
{
    public class BannerMapping : EntityTypeConfiguration<Banner>
    {
        public BannerMapping()
        {
            ToTable("Banner");

            HasKey(b => b.Id);
            Property(b => b.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(b => b.Id).IsRequired();
            Property(b => b.CreationDate).IsRequired();
            Property(b => b.LastModified).IsRequired();

            Property(b => b.Name).IsRequired();
            Property(b => b.Description).IsRequired();

            this.HasMany(b => b.Schedules)
                .WithMany() // <- no parameter here because there is no navigation property
                .Map(m =>
                {
                    m.MapLeftKey("BannerId");
                    m.MapRightKey("ScheduleId");
                    m.ToTable("BannerSchedule");
                });

            this.HasMany(b => b.Items)
               .WithMany() // <- no parameter here because there is no navigation property
               .Map(m =>
               {
                   m.MapLeftKey("BannerId");
                   m.MapRightKey("BannerItemId");
                   m.ToTable("BannerBannerItem");
               });

            this.HasMany(b => b.RssSources)
                .WithMany() // <- no parameter here because there is no navigation property
                .Map(m =>
                {
                    m.MapLeftKey("BannerId");
                    m.MapRightKey("RssSourceId");
                    m.ToTable("BannerRssSource");
                });
        }
    }
}