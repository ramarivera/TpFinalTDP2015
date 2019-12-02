using Questionnaire.Model;
using Questionnaire.Persistence.Specification;
using System;
using System.Linq.Expressions;

namespace Questionnaire.Services.Specifications.Categories
{
    public class CategoryDescriptionSpecification : BaseSpecification<Category>
    {
        private readonly string iDescription;

        public CategoryDescriptionSpecification(string pDescription)
        {
            this.iDescription = pDescription;
        }

        public override Expression<Func<Category, bool>> Expression
        {
            get
            {
                return category => category.Description == iDescription;
            }
        }
    }
}
