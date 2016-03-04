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

    public class TimeIntervalMapping : EntityTypeConfiguration<ScheduleEntry>
    {
        public TimeIntervalMapping()
        {
            ToTable("TimeInterval");

            HasKey(ti => ti.Id);
            Property(ti => ti.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(ti => ti.Id).IsRequired();
            Property(ti => ti.CreationDate).IsRequired();
            Property(ti => ti.LastModified).IsRequired();

            //Property(di => di.Name).IsRequired();
            Property(di => di.Start).IsRequired();
            Property(di => di.End).IsRequired();

            Property(di => di.Start).HasColumnType("Time");
            Property(di => di.End).HasColumnType("Time");

        }

    }
}

