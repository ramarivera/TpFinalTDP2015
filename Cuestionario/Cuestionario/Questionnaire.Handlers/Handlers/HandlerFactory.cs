using Autofac;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using NHibernate;
using NHibernate.Context;
using Questionnaire.Handlers.Handlers.Interfaces;
using Questionnaire.Handlers.Proxies;

namespace Questionnaire.Handlers.Handlers
{
    public static class HandlerFactory
    {
        private static IContainer mContainer;

        public static void ConfigureHandlerFactory(IContainer pContainer)
        {
            if (mContainer == null)
            {
                mContainer = pContainer;
            }
            else
            {
                throw new System.Exception("factory already configured");
            }

        }

        public static THandler Get<THandler>()
            where THandler : class, IBaseHandler
        {
            var lGenerator = new ProxyGenerator();

            var lScopedContainer = mContainer.BeginLifetimeScope();
            var lSessionFactory = lScopedContainer.Resolve<ISessionFactory>();

            if (!CurrentSessionContext.HasBind(lSessionFactory))
            {
                CurrentSessionContext.Bind(lSessionFactory.OpenSession());
            };

            var lInterceptors = new Castle.Core.Interceptor.IInterceptor[]
            {
                lScopedContainer.Resolve<TransactionalMethodInterceptor>(),
                lScopedContainer.Resolve<DisposableInterceptor>()
            };

            var lHandler = lScopedContainer.Resolve<THandler>();
            var lProxiedHandler = lGenerator.CreateInterfaceProxyWithTarget(lHandler, lInterceptors);

            return lProxiedHandler;
        }
    }
}
