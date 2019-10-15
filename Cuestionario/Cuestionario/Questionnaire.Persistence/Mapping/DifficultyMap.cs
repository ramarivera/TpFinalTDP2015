using Cuestionario.Model;
using FluentNHibernate.Mapping;

namespace Questionnaire.Persistence
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
