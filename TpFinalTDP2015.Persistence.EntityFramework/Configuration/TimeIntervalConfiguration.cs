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

    public class TimeIntervalConfiguration : EntityTypeConfiguration<TimeInterval>
    {
        public TimeIntervalConfiguration()
        {
            ToTable("TimeInterval");

            HasKey(ti => ti.Id);
            Property(ti => ti.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(ti => ti.Id).IsRequired();
            Property(ti => ti.CreationDate).IsRequired();
            Property(ti => ti.LastModified).IsRequired();

            Property(di => di.Name).IsRequired();
            Property(di => di.Start).IsRequired();
            Property(di => di.End).IsRequired();

            Property(di => di.Start).HasColumnType("Time");
            Property(di => di.End).HasColumnType("Time");

        }

    }
}

