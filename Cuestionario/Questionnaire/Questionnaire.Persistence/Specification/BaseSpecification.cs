using Questionnaire.Model;
using Questionnaire.Persistence.Specification.Visitors;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Questionnaire.Persistence.Specification
{
    public abstract class BaseSpecification<TEntity> : ISpecification<TEntity>
        where TEntity : IBaseEntity
    {
        private readonly Lazy<Func<TEntity, bool>> iCompiledExpression;
        
        protected BaseSpecification()
        {
            this.iCompiledExpression = new Lazy<Func<TEntity, bool>>(() => this.Expression.Compile());
        }

        public bool IsSatisfiedBy(TEntity pEntity)
        {
            return this.iCompiledExpression.Value.Invoke(pEntity);
        }

        public abstract Expression<Func<TEntity, bool>> Expression { get; }

        public static implicit operator Expression<Func<TEntity, bool>>(BaseSpecification<TEntity> pSpecification)
        {
            return pSpecification.Expression;
        }

        public static BaseSpecification<TEntity> operator &(BaseSpecification<TEntity> pLeft, BaseSpecification<TEntity> pRight)
        {
            return CombineSpecification(pLeft, pRight, System.Linq.Expressions.Expression.AndAlso);
        }

        public static BaseSpecification<TEntity> operator |(BaseSpecification<TEntity> pLeft, BaseSpecification<TEntity> pRight)
        {
            return CombineSpecification(pLeft, pRight, System.Linq.Expressions.Expression.OrElse);
        }

        public static BaseSpecification<TEntity> operator !(BaseSpecification<TEntity> pOriginal)
        {
            var lNegated = System.Linq.Expressions.Expression.Negate(pOriginal.Expression.Body);
            return new ConstructedSpecification<TEntity>(System.Linq.Expressions.Expression.Lambda<Func<TEntity, bool>>(lNegated, pOriginal.Expression.Parameters));
        }

        private static BaseSpecification<TEntity> CombineSpecification(
            BaseSpecification<TEntity> pLeft, 
            BaseSpecification<TEntity> pRight, 
            Func<Expression, Expression, BinaryExpression> pCombiner)
        {
            var lExpr1 = pLeft.Expression;
            var lExpr2 = pRight.Expression;
            var lArg = System.Linq.Expressions.Expression.Parameter(typeof(TEntity));
            var lCombined = pCombiner.Invoke(
                new ReplaceParameterVisitor { { lExpr1.Parameters.Single(), lArg } }.Visit(lExpr1.Body),
                new ReplaceParameterVisitor { { lExpr2.Parameters.Single(), lArg } }.Visit(lExpr2.Body));
            return new ConstructedSpecification<TEntity>(System.Linq.Expressions.Expression.Lambda<Func<TEntity, bool>>(lCombined, lArg));
        }
    }
}
