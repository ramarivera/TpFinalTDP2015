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

    public class SlideConfiguration : EntityTypeConfiguration<Slide>
    {
        public SlideConfiguration()
        {
      /*      ToTable("Slide");

            HasKey(r => r.Id);
            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(r => r.Id).IsRequired();
            Property(r => r.CreationDate).IsRequired();
            Property(r => r.LastModified).IsRequired();

            Property(r => r.Title).IsRequired();
            Property(r => r.Description).IsRequired();
            Property(r => r.URL).IsRequired();
            Property(r => r.PublicationDate).IsOptional();*/

        }

    }
}