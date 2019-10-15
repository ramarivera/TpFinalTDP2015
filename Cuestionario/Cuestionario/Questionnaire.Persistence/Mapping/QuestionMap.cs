using Cuestionario.Model;
using FluentNHibernate.Mapping;

namespace Questionnaire.Persistence
{
    class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Id(x => x.Id);

            Map(x => x.Description);

            References(x => x.Category)
                .Column("categoryId")
                .Cascade
                .All();

            References(x => x.Difficulty)
                .Column("difficultyId")
                .Cascade
                .All();

            HasMany(x => x.Answers)
                .Inverse();

            Table("Questions");
        }
    }
}
