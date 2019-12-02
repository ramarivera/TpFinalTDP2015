using Questionnaire.Model;
using System;
using System.Linq.Expressions;

namespace Questionnaire.Persistence.Specification
{
    internal class ConstructedSpecification<TEntity> : BaseSpecification<TEntity>
        where TEntity: IBaseEntity
    {
        private readonly Expression<Func<TEntity, bool>> specificationExpression;

        public ConstructedSpecification(Expression<Func<TEntity, bool>> specificationExpression)
        {
            this.specificationExpression = specificationExpression;
        }

        public override Expression<Func<TEntity, bool>> Expression => specificationExpression;
    }
}
