using MarrSystems.TpFinalTDP2015.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework.Mapping
{

    public class RssItemMapping : EntityTypeConfiguration<RssItem>
    {
        public RssItemMapping()
        {
            ToTable("RssItem");

            HasKey(r => r.Id);
            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(r => r.Id).IsRequired();
            Property(r => r.CreationDate).IsRequired();
            Property(r => r.LastModified).IsRequired();

            Property(r => r.Title).IsRequired();
            Property(r => r.Description).IsRequired();
            Property(r => r.URL).IsRequired();
            Property(r => r.PublicationDate).IsOptional();

            Property(r => r.PublicationDate).HasColumnType("DateTime2");

        }

    }
}
