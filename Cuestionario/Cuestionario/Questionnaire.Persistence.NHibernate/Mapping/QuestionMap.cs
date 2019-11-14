using FluentNHibernate.Mapping;
using Questionnaire.Model.Enums;

namespace Questionnaire.Persistence.NHibernate.Mappings
{
    class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Id(x => x.Id);

            Map(x => x.Description);

            Map(x => x.QuestionType).CustomType<int>();

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
