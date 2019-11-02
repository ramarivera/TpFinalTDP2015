using Questionnaire.Model;
using FluentNHibernate.Mapping;

namespace Questionnaire.Persistence
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
