using Questionnaire.Model;
using Questionnaire.Persistence.Specification;
using System;
using System.Linq.Expressions;

namespace Questionnaire.Services.Specifications.Questions
{
    public class QuestionsByCategoryAndDifficultySpecification : BaseSpecification<Question>
    {
        private readonly int iCategoryId;
        private readonly int iDifficultyId;

        public QuestionsByCategoryAndDifficultySpecification(int pCategoryId, int pDifficultyId)
        {
            this.iCategoryId = pCategoryId;
            this.iDifficultyId = pDifficultyId;
        }

        public override Expression<Func<Question, bool>> Expression
        {
            get
            {
                return question => (question.Category.Id == iCategoryId) && (question.Difficulty.Id == iDifficultyId);

            }
        }
    }
}
