using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Cuestionario.Model.Mapping
{
    class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Id(x => x.Id);
            Map(x => x.Description);
            References(x => x.Category)
                .Column("categoryId")
                .Cascade.All();
            References(x => x.Difficulty)
                .Column("difficultyId")
                .Cascade.All();
            HasMany(x => x.Answers)
                .Inverse();
            Table("Questions");
        }
    }
}
