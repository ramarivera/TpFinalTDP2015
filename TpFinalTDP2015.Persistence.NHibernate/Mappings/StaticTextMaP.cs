using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Driver;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.Persistence.NHibernate.Mappings
{
    class StaticTextMap : ClassMapping<StaticText>
    {
        public StaticTextMap()
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
            });

            Property(x => x.Title, m =>
            {
                m.Column(c =>
               {
                   c.Name("Title");
                   c.NotNullable(true);
               });
            });

            Property(x => x.Description, m =>
            {
                m.Column(c =>
                {
                    c.Name("Description");
                    c.NotNullable(true);
                });
            });

            Property(x => x.Text, m =>
            {
                m.Column(c =>
                {
                    c.Name("Text");
                    c.NotNullable(true);
                });
            });
        }

    }
}
