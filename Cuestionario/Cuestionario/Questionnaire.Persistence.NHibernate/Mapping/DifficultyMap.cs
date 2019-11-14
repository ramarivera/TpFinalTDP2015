using FluentNHibernate.Mapping;
using Questionnaire.Model;

namespace Questionnaire.Persistence.NHibernate.Mappings
{
    class DifficultyMap : ClassMap<Difficulty>
    {
        public DifficultyMap()
        {
            Id(x => x.Id);

            Map(x => x.Description);

            HasMany(x => x.Questions)
                .Inverse();

            Table("Difficulties");
        }
    }
}
