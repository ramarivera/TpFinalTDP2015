using Questionnaire.Model;
using System;
using System.Linq.Expressions;

namespace Questionnaire.Persistence.Specification
{
    public interface ISpecification<TEntity>
        where TEntity : IBaseEntity 
    {
        Expression<Func<TEntity, bool>> ToExpression();

        bool IsSatisfiedBy(TEntity pEntity);
    }
}
