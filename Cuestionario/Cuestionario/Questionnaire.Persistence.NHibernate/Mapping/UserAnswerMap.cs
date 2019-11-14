using FluentNHibernate.Mapping;
using Questionnaire.Model;

namespace Questionnaire.Persistence.NHibernate.Mappings
{
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
