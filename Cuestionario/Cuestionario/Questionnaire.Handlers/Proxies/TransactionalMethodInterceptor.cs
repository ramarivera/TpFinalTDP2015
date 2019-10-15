using Castle.Core.Interceptor;
using NHibernate;
using NHibernate.Context;
using Questionnaire.Handlers.Attributes;
using System.Reflection;

namespace Questionnaire.Handlers.Proxies
{
    class TransactionalMethodInterceptor : Castle.Core.Interceptor.IInterceptor
    {
        private readonly ISessionFactory iSessionFactory;

        public TransactionalMethodInterceptor(ISessionFactory pSessionFactory)
        {
            this.iSessionFactory = pSessionFactory;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.MethodInvocationTarget.GetCustomAttribute<TransactionalAttribute>() != null)
            {
                var lTransaction = this.iSessionFactory.GetCurrentSession().BeginTransaction();

                try
                {
                    invocation.Proceed();
                    lTransaction.Commit();
                }
                catch
                {
                    lTransaction.Rollback();
                }
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}
