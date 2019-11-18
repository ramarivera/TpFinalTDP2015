using Autofac;
using Castle.Core.Interceptor;
using NHibernate;
using NHibernate.Context;
using System;

namespace Questionnaire.Handlers.Proxies
{
    public class DisposableInterceptor : Castle.Core.Interceptor.IInterceptor
    {
        private readonly ILifetimeScope iLifetimeScope;

        public DisposableInterceptor(ILifetimeScope pLifetimeScope)
        {
            this.iLifetimeScope = pLifetimeScope;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.MethodInvocationTarget.Name == nameof(IDisposable.Dispose))
            {
                var lSessionFactory = this.iLifetimeScope.Resolve<ISessionFactory>();

                lSessionFactory.GetCurrentSession().Close();
                lSessionFactory.GetCurrentSession().Dispose();

                CurrentSessionContext.Unbind(lSessionFactory);

                this.iLifetimeScope.Dispose();
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}
