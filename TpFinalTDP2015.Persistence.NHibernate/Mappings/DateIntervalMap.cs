using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;

using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Driver;

namespace MarrSystems.TpFinalTDP2015.Persistence.NHibernate.Mappings
{
    class DateIntervalMap : ClassMapping<Schedule>
    {
        public DateIntervalMap()
        {
            Id(x => x.Id, m =>
            {
                m.Column("id");
                m.Generator(Generators.Identity);
            });

            Property(x => x.CreationDate, m =>
            {
                m.Column(c =>
                {
                    c.Name("CreationDate");
                    c.NotNullable(true);
                });

                m.Update(true);
                m.Insert(true);

                m.Access(Accessor.Property);
            });

            Property(x => x.LastModified, m =>
            {
                m.Column(c =>
                {
                    c.Name("LastModified");
                    c.NotNullable(true);
                });

                m.Update(true);
                m.Insert(true);

                m.Access(Accessor.Property);
            });

            Property(x => x.Name, m =>
            {
                m.Column(c =>
                {
                    c.Name("Name");
                    c.NotNullable(true);
                });

                m.Update(true);
                m.Insert(true);

                m.Access(Accessor.Property);
            });

            Property(x => x.ActiveFrom, m =>
            {
                m.Column(c =>
                {
                    c.Name("ActiveFrom");
                    c.SqlType("DateTime2");
                    c.NotNullable(true);
                });

                m.Update(true);
                m.Insert(true);

                m.Access(Accessor.Property);
            });

            Property(x => x.ActiveUntil, m =>
            {
                m.Column(c =>
                {
                    c.Name("ActiveUntil");
                    c.SqlType("DateTime2");
                    c.NotNullable(true);
                });

                m.Update(true);
                m.Insert(true);

                m.Access(Accessor.Property);
            });

            /*
                        HasManyToMany(c => c.ActiveHours)
                            .Cascade.None()
                            .Table("CampaignDateInterval")
                    }*/
        }
    }
}
