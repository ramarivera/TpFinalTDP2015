using FluentNHibernate.Mapping;
using Questionnaire.Model;

namespace Questionnaire.Persistence.NHibernate.Mappings
{
    /// <summary>
    /// Maps the Category's domain model to its representation in the solution's relational database
    /// </summary>
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
