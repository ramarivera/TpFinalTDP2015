using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.Persistence.NHibernate.Mappings
{
    class RssItemMap : JoinedSubclassMapping<RssItem>
    {
        public RssItemMap()
        {
           /* Key(k =>
            {
                k.Column("PartyId");
                // or...
                k.Column(c =>
                {
                    c.Name("PartyId");
                    // etc.
                });

                k.ForeignKey("party_fk");
                k.NotNullable(true);
                k.OnDelete(OnDeleteAction.Cascade); // or OnDeleteAction.NoAction
                k.PropertyRef(x => x.CompanyName);
                k.Unique(true);
                k.Update(true);
            });*/
        }
        
    }
}
