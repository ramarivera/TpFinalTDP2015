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

    public class DateIntervalConfiguration : EntityTypeConfiguration<DateInterval>
    {
        public DateIntervalConfiguration()
        {
            ToTable("DateInterval");

            HasKey(di => di.Id);
            Property(di => di.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(di => di.Id).IsRequired();
            Property(di => di.CreationDate).IsRequired();
            Property(di => di.LastModified).IsRequired();

            Property(di => di.Name).IsRequired();
            Property(di => di.ActiveFrom).IsRequired();
            Property(di => di.ActiveUntil).IsRequired();

            Property(di => di.ActiveFrom).HasColumnType("DateTime2");
            Property(di => di.ActiveUntil).HasColumnType("DateTime2");
            
            
            
            HasMany(di => di.ActiveDays)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("DateIntervalId");
                    m.MapRightKey("DayId");
                    m.ToTable("DateIntervalDay");
                });

            HasMany(di => di.ActiveHours)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("DateIntervalId");
                    m.MapRightKey("TimeIntervalId");
                    m.ToTable("DateIntervalTimeInterval");
                });
        }

    }
}

