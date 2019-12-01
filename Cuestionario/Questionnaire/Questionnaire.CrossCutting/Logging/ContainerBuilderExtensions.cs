using Autofac;
using Microsoft.Extensions.Logging;

namespace Questionnaire.CrossCutting.Logging
{
    public static class ContainerBuilderExtensions
    {

        public static void AddSerilog(this ContainerBuilder pContainerBuilder, LoggerFactory pLoggerFactory)
        {
            var lModule = new AutofacSerilogIntegrationModule(pLoggerFactory);
            pContainerBuilder.RegisterModule(lModule);
        }
    }
}
