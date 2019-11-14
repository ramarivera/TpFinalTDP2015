using FluentNHibernate.Mapping;
using Questionnaire.Model;

namespace Questionnaire.Persistence.NHibernate.Mappings
{
    class AnswerMap : ClassMap<Answer>
    {
        public AnswerMap()
        {
            Id(x => x.Id);

            Map(x => x.Description);

            References(x => x.Question)
                .Column("questionId");

            Table("Answers");
        }
    }
}
