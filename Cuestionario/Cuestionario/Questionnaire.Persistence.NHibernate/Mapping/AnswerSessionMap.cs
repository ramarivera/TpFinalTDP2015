﻿using Questionnaire.Model;
using FluentNHibernate.Mapping;

namespace Questionnaire.Persistence.NHibernate.Mappings
{
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
