using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MarrSystems.TpFinalTDP2015.CrossCutting
{
    public static class Reflect<TTarget>
    {
        /// <summary>
        /// Gets the method represented by the lambda expression.
        /// </summary>
        /// <param name="method">A method invocation.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="method"/> is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="method"/> is not a lambda expression or it does not represent a method invocation.</exception>
        /// <returns>The method info.</returns>
        public static MethodInfo Method(Expression<Action<TTarget>> method)
        {
            return GetMethodInfo(method);
        }

        /// <summary>
        /// Gets the method represented by the lambda expression.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the first parameter of the method invocation.</typeparam>
        /// <param name="method">A method invocation.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="method"/> is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="method"/> is not a lambda expression or it does not represent a method invocation.</exception>
        /// <returns>The method info.</returns>
        public static MethodInfo Method<TParameter1>(Expression<Action<TTarget, TParameter1>> method)
        {
            return GetMethodInfo(method);
        }

        /// <summary>
        /// Gets the method represented by the lambda expression.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the first parameter of the method invocation.</typeparam>
        /// <typeparam name="TParameter2">The type of the second parameter of the method invocation.</typeparam>
        /// <param name="method">A method invocation.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="method"/> is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="method"/> is not a lambda expression or it does not represent a method invocation.</exception>
        /// <returns>The method info.</returns>
        public static MethodInfo Method<TParameter1, TParameter2>(Expression<Action<TTarget, TParameter1, TParameter2>> method)
        {
            return GetMethodInfo(method);
        }

        /// <summary>
        /// Gets the method represented by the lambda expression.
        /// </summary>
        /// <typeparam name="TParameter1">The type of the first parameter of the method invocation.</typeparam>
        /// <typeparam name="TParameter2">The type of the second parameter of the method invocation.</typeparam>
        /// <typeparam name="TParameter3">The type of the third parameter of the method invocation.</typeparam>
        /// <param name="method">A method invocation.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="method"/> is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="method"/> is not a lambda expression or it does not represent a method invocation.</exception>
        /// <returns>The method info.</returns>
        public static MethodInfo Method<TParameter1, TParameter2, TParameter3>(Expression<Action<TTarget, TParameter1, TParameter2, TParameter3>> method)
        {
            return GetMethodInfo(method);
        }

        /// <summary>
        /// Gets the property name of the property represented by the lambda expression.
        /// </summary>
        /// <param name="property">An expression to get the property.</param>
        /// <typeparam name="TResult">Property type.</typeparam>
        /// <returns>The property name.</returns>
        public static string PropertyName<TResult>(Expression<Func<TTarget, TResult>> property)
        {
            return Property(property).Name;
        }

        /// <summary>
        /// Gets the property path to the property represented by the lambda expression.
        /// </summary>
        /// <param name="property">An expression to get the property</param>
        /// <typeparam name="TResult">Property type.</typeparam>
        /// <returns>The property path.</returns>
        public static string PropertyPath<TResult>(Expression<Func<TTarget, TResult>> property)
        {
            return GeneratePropertyPath((Expression)property);
        }

        /// <summary>
        /// Gets the property represented by the lambda expression.
        /// </summary>
        /// <param name="property">A lambda expression to get a property.</param>
        /// <typeparam name="TResult">Property type.</typeparam>
        /// <exception cref="ArgumentNullException">The <paramref name="property"/> is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="property"/> is not a lambda expression or it does not represent a property access.</exception>
        /// <returns>The property info.</returns>
        public static PropertyInfo Property<TResult>(Expression<Func<TTarget, TResult>> property)
        {
            PropertyInfo info = GetMemberInfo(property) as PropertyInfo;
            if (info == null) throw new ArgumentException("Member is not a property");

            return info;
        }

        /// <summary>
        /// Gets the field represented by the lambda expression.
        /// </summary>
        /// <param name="field">A lambda expression to get a field.</param>
        /// <typeparam name="TResult">Property type.</typeparam>
        /// <exception cref="ArgumentNullException">The <paramref name="field"/> is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="field"/> is not a lambda expression or it does not represent a field access.</exception>
        /// <returns>The field info.</returns>
        public static FieldInfo Field<TResult>(Expression<Func<TTarget, TResult>> field)
        {
            FieldInfo info = GetMemberInfo(field) as FieldInfo;
            if (info == null) throw new ArgumentException("Member is not a field");

            return info;
        }

        private static string GeneratePropertyPath(Expression pathExpression)
        {
            if (pathExpression.NodeType == ExpressionType.Lambda)
            {
                var lambda = (LambdaExpression)pathExpression;
                return GeneratePropertyPath(lambda.Body);
            }
            else if (pathExpression.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpression = (MemberExpression)pathExpression;
                string path = GeneratePropertyPath(memberExpression.Expression);

                return path + (String.IsNullOrEmpty(path) ? string.Empty : ".") + memberExpression.Member.Name;
            }

            if (pathExpression is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)pathExpression;
                return GeneratePropertyPath(unaryExpression.Operand);
            }
            else
            {
                return string.Empty;
            }
        }

        private static MethodInfo GetMethodInfo(Expression method)
        {
            if (method == null) throw new ArgumentNullException("method");

            LambdaExpression lambda = method as LambdaExpression;
            if (lambda == null) throw new ArgumentException("Not a lambda expression", "method");
            if (lambda.Body.NodeType != ExpressionType.Call) throw new ArgumentException("Not a method call", "method");

            return ((MethodCallExpression)lambda.Body).Method;
        }

        private static MemberInfo GetMemberInfo(Expression member)
        {
            if (member == null) throw new ArgumentNullException("member");

            LambdaExpression lambda = member as LambdaExpression;
            if (lambda == null) throw new ArgumentException("Not a lambda expression", "member");

            MemberExpression memberExpr = null;

            // The Func<TTarget, object> we use returns an object, so first statement can be either
            // a cast (if the field/property does not return an object) or the direct member access.
            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                // The cast is an unary expression, where the operand is the
                // actual member access expression.
                memberExpr = ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null) throw new ArgumentException("Not a member access", "member");

            return memberExpr.Member;
        }
    }
}
