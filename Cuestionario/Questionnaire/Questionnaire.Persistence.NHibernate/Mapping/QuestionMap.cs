using FluentNHibernate.Mapping;
using Questionnaire.Model;

namespace Questionnaire.Persistence.NHibernate.Mappings
{
    /// <summary>
    /// Maps <see cref="Question"/> to its representation in the solution's relational database
    /// </summary>
    class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Id(x => x.Id);

            Map(x => x.Description);

            Map(x => x.QuestionType).CustomType<int>();

            Map(x => x.QuestionProvider).CustomType<int>();

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
