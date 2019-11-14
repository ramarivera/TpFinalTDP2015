using FluentNHibernate.Mapping;
using Questionnaire.Model;

namespace Questionnaire.Persistence.NHibernate.Mappings
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
