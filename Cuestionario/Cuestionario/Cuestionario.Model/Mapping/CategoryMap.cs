using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Model.Mapping
{
    class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id);
            Map(x => x.Description);
            HasMany(x => x.Questions)
                .Inverse();
            Table("Categories");
        }
    }
}
