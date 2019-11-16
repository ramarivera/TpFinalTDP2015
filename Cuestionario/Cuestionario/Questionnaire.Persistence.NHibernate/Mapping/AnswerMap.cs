using FluentNHibernate.Mapping;
using Questionnaire.Model;

namespace Questionnaire.Persistence.NHibernate.Mappings
{
    /// <summary>
    /// Maps <see cref="Answer"/> to its representation in the solution's relational database
    /// </summary>
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
