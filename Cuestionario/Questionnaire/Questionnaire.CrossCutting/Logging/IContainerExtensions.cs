using Autofac;
using Microsoft.Extensions.Logging;
using System;

namespace Questionnaire.CrossCutting.Logging
{
    public static class IContainerExtensions
    {
        public static ILogger GetLoggerFor<T>(this IContainer pContainer)
        {
            return pContainer.GetLoggerFor(typeof(T));
        }

        public static ILogger GetLoggerFor(this IContainer pContainer, Type pType)
        {
            return pContainer.Resolve<ILogger>(new[]
            {
                new NamedParameter(LoggingConstants.TypedLoggerKey, pType)
            });
        }
    }
}
