using Autofac;
using Autofac.Core;
using Autofac.Core.Activators.Reflection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;

namespace Questionnaire.CrossCutting.Logging
{
    /// <summary>
    /// Autofac configuration module for providing Serilog instances by DI, wrapped inside MS Extensions ILogger
    /// </summary>
    /// <remarks>
    /// Based on https://github.com/nblumhardt/autofac-serilog-integration/blob/master/src/AutofacSerilogIntegration/ContextualLoggingModule.cs#L44),
    /// but tinkered in order to wrap Serilog ILogger inside MS Extensions ILogger
    /// </remarks>
    internal class AutofacSerilogIntegrationModule : Autofac.Module
    {
        const string TargetTypeParameterName = "Autofac.AutowiringPropertyInjector.InstanceType";

        private readonly LoggerFactory iLoggerFactory;
        private readonly bool iSkipRegistration;

        [Obsolete("Do not use this constructor. This is required by the Autofac assembly scanning")]
        public AutofacSerilogIntegrationModule()
        {
            // Workaround to skip the logger registration when module is loaded by Autofac assembly scanning
            this.iSkipRegistration = true;
        }

        internal AutofacSerilogIntegrationModule(LoggerFactory pLoggerFactory)
        {
            this.iLoggerFactory = pLoggerFactory;
            this.iSkipRegistration = false;
        }

        protected override void Load(ContainerBuilder pBuilder)
        {
            if (this.iSkipRegistration)
                return;

            pBuilder.RegisterInstance(this.iLoggerFactory)
                .AsSelf()
                .AutoActivate()
                .OnRelease(c => c.Dispose());

            pBuilder.Register((c, p) =>
            {
                var lLoggerFactory = c.Resolve<LoggerFactory>();

                var targetType = p.OfType<NamedParameter>()
                    .FirstOrDefault(np => (np.Name == TargetTypeParameterName || np.Name == LoggingConstants.TypedLoggerKey) && np.Value is Type);

                if (targetType != null)
                    return lLoggerFactory.CreateLogger((Type)targetType.Value);

                return lLoggerFactory.CreateLogger("NO CATEGORY");
            })
                .As<Microsoft.Extensions.Logging.ILogger>()
                .ExternallyOwned();
        }

        protected override void AttachToComponentRegistration(
            IComponentRegistry pComponentRegistry,
            IComponentRegistration pRegistration)
        {
            if (this.iSkipRegistration)
                return;

            var lLoggerType = typeof(Microsoft.Extensions.Logging.ILogger);

            PropertyInfo[] lTargetProperties = null;

            var lReflectActivator = pRegistration.Activator as ReflectionActivator;
            if (lReflectActivator != null)
            {
                // As of Autofac v4.7.0 "FindConstructors" will throw "NoConstructorsFoundException" instead of returning an empty array
                // See: https://github.com/autofac/Autofac/pull/895 & https://github.com/autofac/Autofac/issues/733
                ConstructorInfo[] lConstructors;
                try
                {
                    lConstructors = lReflectActivator.ConstructorFinder.FindConstructors(lReflectActivator.LimitType);
                }
                catch (Exception ex) when (ex.GetType().Name == "NoConstructorsFoundException")
                {
                    // Avoid needing to upgrade our Autofac reference to 4.7.0
                    lConstructors = new ConstructorInfo[0];
                }

                var lUsesLogger =
                    lConstructors.SelectMany(ctor => ctor.GetParameters()).Any(pi => pi.ParameterType == lLoggerType);

                var lLogProperties = lReflectActivator.LimitType
                                        .GetRuntimeProperties()
                                        .Where(c => c.CanWrite && c.PropertyType == lLoggerType && c.SetMethod.IsPublic && !c.SetMethod.IsStatic)
                                        .ToArray();

                if (lLogProperties.Any())
                {
                    lTargetProperties = lLogProperties;
                    lUsesLogger = true;
                }

                // Ignore components known to be without logger dependencies
                if (!lUsesLogger)
                    return;
            }

            pRegistration.Preparing += (sender, args) =>
            {
                if (pRegistration.Activator.LimitType != typeof(LoggerFactory))
                {
                    var lLogger = args.Context.Resolve<LoggerFactory>().CreateLogger(pRegistration.Activator.LimitType);
                    args.Parameters = new[] { TypedParameter.From(lLogger) }.Concat(args.Parameters);
                }
            };

            if (lTargetProperties != null)
            {
                pRegistration.Activating += (sender, args) =>
                {
                    if (pRegistration.Activator.LimitType != typeof(LoggerFactory))
                    {
                        var lLogger = args.Context.Resolve<LoggerFactory>().CreateLogger(pRegistration.Activator.LimitType);
                        foreach (var targetProperty in lTargetProperties)
                        {
                            targetProperty.SetValue(args.Instance, lLogger);
                        }
                    }
                };
            }
        }
    }
}