using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Model.Mapping
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
