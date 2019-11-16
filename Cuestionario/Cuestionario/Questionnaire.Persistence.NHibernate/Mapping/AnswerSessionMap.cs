using Questionnaire.Model;
using FluentNHibernate.Mapping;

namespace Questionnaire.Persistence.NHibernate.Mappings
{
    /// <summary>
    /// Maps the Answer Session's domain model to its representation in the solution's relational database
    /// </summary>
    class AnswerSessionMap : ClassMap<AnswerSession>
    {
        public AnswerSessionMap()
        {
            Id(x => x.Id);

            Map(x => x.Username);

            Map(x => x.Score);

            Map(x => x.StartTime);

            Map(x => x.EndTime).Nullable();

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

            Table("AnswerSessions");
        }
    }
}
