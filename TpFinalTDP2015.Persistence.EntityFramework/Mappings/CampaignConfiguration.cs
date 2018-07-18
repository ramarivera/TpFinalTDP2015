using MarrSystems.TpFinalTDP2015.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework.Mapping
{

    public class CampaignMapping : EntityTypeConfiguration<Campaign>
    {
        public CampaignMapping()
        {
            ToTable("Campaign");

            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Id).IsRequired();
            Property(c => c.CreationDate).IsRequired();
            Property(c => c.LastModified).IsRequired();

            Property(c => c.Name).IsRequired();
            Property(c => c.Description).IsRequired();

            this.HasMany(c => c.Schedules)
                .WithMany() // <- no parameter here because there is no navigation property
                .Map(m =>
                {
                    m.MapLeftKey("CampaignId");
                    m.MapRightKey("ScheduleId");
                    m.ToTable("CampaignSchedule");
                });
        }

    }
}

