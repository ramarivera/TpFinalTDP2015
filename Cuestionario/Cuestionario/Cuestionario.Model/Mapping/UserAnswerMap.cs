using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Cuestionario.Model.Mapping
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
