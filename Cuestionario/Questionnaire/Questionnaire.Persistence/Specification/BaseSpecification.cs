using Questionnaire.Model;
using System;
using System.Linq.Expressions;

namespace Questionnaire.Persistence.Specification
{
    public abstract class BaseSpecification<TEntity> : ISpecification<TEntity>
        where TEntity : IBaseEntity
    {
        private readonly Func<TEntity, bool> iCompiledExpression;
        
        protected BaseSpecification()
        {
            this.iCompiledExpression = this.ToExpression().Compile();
        }

        public bool IsSatisfiedBy(TEntity pEntity)
        {
            return this.iCompiledExpression.Invoke(pEntity);
        }

        public abstract Expression<Func<TEntity, bool>> ToExpression();
    }
}
