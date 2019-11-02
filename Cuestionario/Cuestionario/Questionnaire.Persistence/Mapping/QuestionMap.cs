using Questionnaire.Model;
using FluentNHibernate.Mapping;

namespace Questionnaire.Persistence
{
    class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Id(x => x.Id);

            Map(x => x.Description);

            Map(x => x.QuestionType);

            References(x => x.Category)
                .Column("categoryId")
                .Cascade
                .All();

            References(x => x.Difficulty)
                .Column("difficultyId")
                .Cascade
                .All();

            HasMany(x => x.Answers)
                .Access.CamelCaseField()
                .Cascade.All()
                .Inverse();

            References(x => x.CorrectAnswer)
                .Column("correctAnswerId")
                .Cascade.All();

            Table("Questions");
        }
    }
}
