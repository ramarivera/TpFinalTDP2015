using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Persistence.EntityFramework.Mapping
{

    public class RssSourceMapping : EntityTypeConfiguration<RssSource>
    {
        public RssSourceMapping()
        {
            ToTable("RssSource");

            HasKey(r => r.Id);
            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(r => r.Id).IsRequired();
            Property(r => r.CreationDate).IsRequired();
            Property(r => r.LastModified).IsRequired();

            Property(r => r.Title).IsRequired();
            Property(r => r.Description).IsRequired();
            Property(r => r.URL).IsRequired();

            HasMany(r => r.Items)
                .WithMany() // <- no parameter here because there is no navigation property
                .Map(m =>
                {
                    m.MapLeftKey("RssSourceId");
                    m.MapRightKey("RssItemId");
                    m.ToTable("RssSourceRssItem");
                });
        }

    }
}
