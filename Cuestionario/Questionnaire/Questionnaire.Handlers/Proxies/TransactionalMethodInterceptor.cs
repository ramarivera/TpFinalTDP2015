using Castle.Core.Interceptor;
using Questionnaire.Handlers.Attributes;
using Questionnaire.Persistence.UnitOfWork;
using System.Reflection;

namespace Questionnaire.Handlers.Proxies
{
    class TransactionalMethodInterceptor : Castle.Core.Interceptor.IInterceptor
    {
        private readonly IUnitOfWork iUnitOfWork;

        public TransactionalMethodInterceptor(IUnitOfWork pUnitOfWork)
        {
            this.iUnitOfWork = pUnitOfWork;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.MethodInvocationTarget.GetCustomAttribute<TransactionalAttribute>() != null)
            {
                this.iUnitOfWork.BeginTransaction();

                try
                {
                    invocation.Proceed();
                    this.iUnitOfWork.Commit();
                }
                catch
                {
                    this.iUnitOfWork.Rollback();
                    throw; 
                }
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}
