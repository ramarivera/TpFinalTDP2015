using Cuestionario.Model;
using FluentNHibernate.Mapping;

namespace Questionnaire.Persistence
{
    class AnswerMap : ClassMap<Answer>
    {
        public AnswerMap()
        {
            Id(x => x.Id);

            Map(x => x.Description);

            Map(x => x.Correct);

            References(x => x.Question)
                .Column("questionId");

            Table("Answers");
        }
    }
}
