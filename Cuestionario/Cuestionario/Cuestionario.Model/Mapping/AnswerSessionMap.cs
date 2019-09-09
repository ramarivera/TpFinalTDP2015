using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Cuestionario.Model.Mapping
{
    class AnswerSessionMap : ClassMap<AnswerSession>
    {
        public AnswerSessionMap()
        {
            Id(x => x.Id);
            Map(x => x.Username);
            Map(x => x.AnswerTime);
            Map(x => x.Score);
            Map(x => x.Date);
            References(x => x.Category)
                .Column("categoryId")
                .Cascade.All();
            References(x => x.Difficulty)
                .Column("difficultyId")
                .Cascade.All();
            HasMany(x => x.UserAnswers)
                .Inverse();
            Table("AnswerSessions");
        }
    }
}
