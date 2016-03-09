using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Criteria
{
    public static class PredicateExtensions
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            InvocationExpression invokedExpression = Expression.Invoke(expression2, expression1.Parameters.Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(Expression.And(expression1.Body, invokedExpression), expression1.Parameters);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            InvocationExpression invokedExpression = Expression.Invoke(expression2, expression1.Parameters.Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(Expression.Or(expression1.Body, invokedExpression), expression1.Parameters);
        }

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression1)
        {
            InvocationExpression invokedExpression = Expression.Invoke(expression1, expression1.Parameters.Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(Expression.Not(invokedExpression), expression1.Parameters);
        }
    }

}
