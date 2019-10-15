using Cuestionario.Model;
using FluentNHibernate.Mapping;

namespace Questionnaire.Persistence
{
    class UserAnswerMap : ClassMap<UserAnswer>
    {
        public UserAnswerMap()
        {
            Id(x => x.Id);

            Map(x => x.AnswerStatus);

            References(x => x.Question)
                .Column("questionId")
                .Cascade.All();

            References(x => x.AnswerSession)
                .Column("answerSessionId")
                .Cascade.All();

            References(x => x.ChosenAnswer)
                .Column("chosenAnswerId")
                .Cascade.All();

            Table("UserAnswers");
        }
    }
}
