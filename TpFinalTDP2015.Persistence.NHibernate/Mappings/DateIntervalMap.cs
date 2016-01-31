using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;

using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace TpFinalTDP2015.Persistence.NHibernate.Mappings
{
    class DateIntervalMap : ClassMappping<DateInterval>
    {
        public DateIntervalMap()
        {
            Id(c => c.Id);

            Map(c => c.Id);
            Map(c => c.CreationDate);
            Map(c => c.LastModified);

            Map(c => c.Name);
            Map(c => c.ActiveFrom);
            Map(c => c.ActiveUntil);

            HasManyToMany(c => c.ActiveHours)
                .Cascade.None()
                .Table("CampaignDateInterval")
        }
    }
}
