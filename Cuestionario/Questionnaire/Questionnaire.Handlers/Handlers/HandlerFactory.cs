using Autofac;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using NHibernate;
using NHibernate.Context;
using Questionnaire.CrossCutting.Logging;
using Questionnaire.Handlers.Handlers.Interfaces;
using Questionnaire.Handlers.Proxies;
using System;

namespace Questionnaire.Handlers.Handlers
{
    public static class HandlerFactory
    {
        private static IContainer mContainer;
        private static ILogger mLogger;

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
            var lHandlerType = typeof(THandler);

            var enabled = Logger.IsEnabled(LogLevel.Debug);
            Logger.LogDebug("Starting application");
            Logger.LogError("Requesting handler of type {lHandlerType}", lHandlerType);

            try
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

                Logger.LogDebug("Handler of type {lHandlerType} successfully built", lHandlerType);

                return lProxiedHandler;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Handler of type {lHandlerType} errored on build", lHandlerType);
                throw;
            }
        }

        private static ILogger Logger => mLogger ?? (mLogger = mContainer.GetLoggerFor(typeof(HandlerFactory)));
    }
}
