using System.Linq.Expressions;
using System.Reflection;

namespace Questionnaire.Utilities
{
    public static class ExpressionDebugExtensions
    {
        /// <summary>
        /// Returns the string provided by the DebugView property while debugging Expressions.
        /// </summary>
        /// <param name="pExpression">Expression to be debugged.</param>
        /// <returns>Debug view expression value.</returns>
        public static string DebugView(this Expression pExpression)
        {
            if (pExpression == null)
                return null;

            var propertyInfo = typeof(Expression).GetProperty("DebugView", BindingFlags.Instance | BindingFlags.NonPublic);
            return propertyInfo.GetValue(pExpression) as string;
        }
    }
}
