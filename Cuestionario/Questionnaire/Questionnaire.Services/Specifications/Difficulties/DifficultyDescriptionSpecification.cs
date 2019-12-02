using Questionnaire.Model;
using Questionnaire.Persistence.Specification;
using System;
using System.Linq.Expressions;

namespace Questionnaire.Services.Specifications.Difficulties
{
    public class DifficultyDescriptionSpecification : BaseSpecification<Difficulty>
    {
        private readonly string iDescription;

        public DifficultyDescriptionSpecification(string pDescription)
        {
            this.iDescription = pDescription;
        }

        public override Expression<Func<Difficulty, bool>> Expression
        {
            get
            {
                return difficulty => difficulty.Description == iDescription;
            }
        }
    }
}
