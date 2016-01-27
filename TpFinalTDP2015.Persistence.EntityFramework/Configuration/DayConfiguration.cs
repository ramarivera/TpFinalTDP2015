using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Persistence.EntityFramework.Configuration
{

    public class DayConfiguration : EntityTypeConfiguration<Day>
    {
        public DayConfiguration()
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
