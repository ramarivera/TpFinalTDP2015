using Questionnaire.Model;
using Questionnaire.Persistence.Specification;
using System;
using System.Linq.Expressions;

namespace Questionnaire.Services.Specifications.Questions
{
    public class QuestionsByCategorySpecification : BaseSpecification<Question>
    {
        private readonly int iCategoryId;

        public QuestionsByCategorySpecification(int pCategoryId)
        {
            this.iCategoryId = pCategoryId;
        }

        public override Expression<Func<Question, bool>> Expression
        {
            get
            {
                return question => (question.Category.Id == iCategoryId);

            }
        }
    }
}
