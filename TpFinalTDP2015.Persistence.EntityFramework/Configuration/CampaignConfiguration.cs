﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Persistence.EntityFramework.Configuration
{

    public class CampaignConfiguration : EntityTypeConfiguration<Campaign>
    {
        public CampaignConfiguration()
        {
            ToTable("Campaign");

            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Id).IsRequired();
            Property(c => c.CreationDate).IsRequired();
            Property(c => c.LastModified).IsRequired();

            Property(c => c.Name).IsRequired();
            Property(c => c.Description).IsRequired();

            HasMany(c => c.ActiveIntervals)
                .WithMany() // <- no parameter here because there is no navigation property
                .Map(m =>
                {
                    m.MapLeftKey("CampaignId");
                    m.MapRightKey("DateIntervalId");
                    m.ToTable("CampaignDateInterval");
                });
        }

    }
}

