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

    public class StaticTextMapping : EntityTypeConfiguration<StaticText>
    {
        public StaticTextMapping()
        {
            ToTable("StaticText");

            HasKey(s => s.Id);
            Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(s => s.Id).IsRequired();
            Property(s => s.CreationDate).IsRequired();
            Property(s => s.LastModified).IsRequired();

            Property(s => s.Title).IsRequired();
            Property(s => s.Description).IsRequired();
            Property(s => s.Text).IsRequired();

        }

    }
}
