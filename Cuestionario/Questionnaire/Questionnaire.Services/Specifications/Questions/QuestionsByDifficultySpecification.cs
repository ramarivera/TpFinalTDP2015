using Questionnaire.Model;
using Questionnaire.Persistence.Specification;
using System;
using System.Linq.Expressions;

namespace Questionnaire.Services.Specifications.Questions
{
    public class QuestionsByDifficultySpecification : BaseSpecification<Question>
    {
        private readonly int iDifficultyId;

        public QuestionsByDifficultySpecification(int pDifficultyId)
        {
            this.iDifficultyId = pDifficultyId;
        }

        public override Expression<Func<Question, bool>> Expression
        {
            get
            {
                return question => (question.Difficulty.Id == iDifficultyId);

            }
        }
    }
}
