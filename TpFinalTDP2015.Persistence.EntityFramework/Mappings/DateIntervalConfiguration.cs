﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework.Mapping
{

    public class DateIntervalMapping : EntityTypeConfiguration<DateInterval>
    {
        public DateIntervalMapping()
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



            this.HasMany(di => di.ActiveDays)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("DateIntervalId");
                    m.MapRightKey("DayId");
                    m.ToTable("DateIntervalDay");
                });

            this.HasMany(di => di.ActiveHours)
                .WithRequired()
                .Map(m => m.MapKey("DateIntervalId"))
                .WillCascadeOnDelete(true);
                
        }

    }
}

