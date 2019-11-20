using FluentNHibernate.Mapping;
using Questionnaire.Model;

namespace Questionnaire.Persistence.NHibernate.Mappings
{
    /// <summary>
    /// Maps <see cref="UserAnswer"/> to its representation in the solution's relational database
    /// </summary>
    class UserAnswerMap : ClassMap<UserAnswer>
    {
        public UserAnswerMap()
        {
            Id(x => x.Id);

            References(x => x.Question)
                .Column("questionId")
                .Cascade
                .All();

            References(x => x.AnswerSession)
                .Column("answerSessionId")
                .Cascade
                .All();

            References(x => x.ChosenAnswer)
                .Column("chosenAnswerId")
                .Cascade
                .All();

            Table("UserAnswers");
        }
    }
}
