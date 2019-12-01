using Autofac;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;

namespace Questionnaire.CrossCutting.Logging
{
    public class LoggingFactory
    {
        private static bool mAlreadyConfigured = false;
        private readonly LoggerFactory iLoggerFactory;

        public static LoggerFactory ConfigureLogging(ContainerBuilder pContainerBuilder)
        {
            if (mAlreadyConfigured)
            {
                throw new InvalidOperationException("Logging configuration should be executed exactly once.");
            }

            var loggerFactory = new LoggerFactory();

            var loggerConfig = new LoggerConfiguration()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.File(path: Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questionnaire.log"), rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Logger = loggerConfig;

            pContainerBuilder.RegisterInstance(loggerConfig)
                .OnRelease(x =>
                {
                    Log.CloseAndFlush();
                });

            loggerFactory.AddSerilog(loggerConfig);
            mAlreadyConfigured = true;

            return loggerFactory;
        }

        public LoggingFactory(LoggerFactory pLoggerFactory)
        {
            this.iLoggerFactory = pLoggerFactory;
        }

        public Microsoft.Extensions.Logging.ILogger GetLoggerFor<T>()
        {
            return this.iLoggerFactory.CreateLogger<T>();
        }

        public Microsoft.Extensions.Logging.ILogger GetLoggerFor(Type pType)
        {
            return this.iLoggerFactory.CreateLogger(pType);
        }
    }
}
