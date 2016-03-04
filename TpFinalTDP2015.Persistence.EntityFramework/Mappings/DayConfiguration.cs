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

    public class DayMapping : EntityTypeConfiguration<Day>
    {
        public DayMapping()
        {
            ToTable("Day");

            HasKey(d => d.Id);
            Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(d => d.Id).IsRequired();
            Property(d => d.CreationDate).IsRequired();
            Property(d => d.LastModified).IsRequired();

            Property(d => d.NameOfDay).IsRequired();
            Property(d => d.Value).IsRequired();

            Property(d => d.Value).HasColumnType("Int");
        }

    }
}
