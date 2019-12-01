using Autofac;
using Autofac.Features.ResolveAnything;
using AutoMapper;
using NHibernate;
using Questionnaire.CrossCutting.Logging;
using Questionnaire.Handlers.DependencyInjection;
using Questionnaire.Handlers.Handlers;
using Questionnaire.Handlers.Handlers.Interfaces;
using Questionnaire.Model.Enums;
using Questionnaire.Persistence.NHibernate;
using Questionnaire.Services;
using Questionnaire.Services.Impl;
using Questionnaire.Services.Interfaces;
using Questionnaire.Services.OpenTrivia;
using IContainer = Questionnaire.Services.DependencyInjection.IContainer;

namespace Questionnaire.Handlers
{
    public class Bootstrapper
    {
        public static IContainer BootstrapApplication()
        {
            var lBuilder = new ContainerBuilder();

            lBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            PerformInstancePerLifetimeRegistration<IContainer, AutofacContainer>(lBuilder);

            PerformInstancePerLifetimeRegistration<IAnswerSessionServices, AnswerSessionServices>(lBuilder);
            PerformInstancePerLifetimeRegistration<IAnswerSessionHandler, AnswerSessionHandler>(lBuilder);
            PerformInstancePerLifetimeRegistration<ICategoryServices, CategoryServices>(lBuilder);
            PerformInstancePerLifetimeRegistration<ICategoryHandler, CategoryHandler>(lBuilder);
            PerformInstancePerLifetimeRegistration<IDifficultyServices, DifficultyServices>(lBuilder);
            PerformInstancePerLifetimeRegistration<IDifficultyHandler, DifficultyHandler>(lBuilder);
            PerformInstancePerLifetimeRegistration<IQuestionServices, QuestionServices>(lBuilder);
            PerformInstancePerLifetimeRegistration<IQuestionHandler, QuestionHandler>(lBuilder);
            PerformInstancePerLifetimeRegistration<IUserAnswerServices, UserAnswerServices>(lBuilder);
            PerformInstancePerLifetimeRegistration<IUserAnswerHandler, UserAnswerHandler>(lBuilder);

            lBuilder.RegisterType<OpenTriviaQuestionsServices>()
                  .Named<IQuestionProvider>(QuestionSource.OpenTrivia.ToString().ToUpper())
                  .InstancePerLifetimeScope()
                  .PropertiesAutowired();

            ConfigureAutomapper(lBuilder);
            ConfigurePersistence(lBuilder);
            ConfigureLogging(lBuilder);
           
            var lContainer = lBuilder.Build();

            HandlerFactory.ConfigureHandlerFactory(lContainer);

            return lContainer.Resolve<IContainer>();
        }

        private static void ConfigurePersistence(ContainerBuilder lBuilder)
        {
            lBuilder.RegisterInstance(NHibernateHelper.CreateSessionFactory())
                    .SingleInstance();

            lBuilder.Register(c => c.Resolve<ISessionFactory>().GetCurrentSession())
                    .InstancePerLifetimeScope();

            NHibernateHelper.ConfigureContainer(lBuilder);
        }

        private static void PerformInstancePerLifetimeRegistration<TInterface, TImplementation>(ContainerBuilder pBuilder)
        {
            pBuilder.RegisterType<TImplementation>()
                   .As<TInterface>()
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();
        }

        private static void ConfigureAutomapper(ContainerBuilder lBuilder)
        {
            var lConfiguration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(IQuestionServices).Assembly));

            lBuilder.RegisterInstance(lConfiguration)
                    .As<IConfigurationProvider>();

            lBuilder.Register(
              ctx =>
              {
                  var scope = ctx.Resolve<ILifetimeScope>();
                  return new Mapper(ctx.Resolve<IConfigurationProvider>(), scope.Resolve);
              })
              .As<IMapper>()
              .InstancePerLifetimeScope();
        }

        private static void ConfigureLogging(ContainerBuilder lBuilder)
        {
            var lLoggerFactory = LoggingFactory.ConfigureLogging(lBuilder);

            lBuilder.RegisterType<LoggingFactory>()
                    .AsSelf()
                    .InstancePerLifetimeScope();

            lBuilder.AddSerilog(lLoggerFactory);
        }
    }
}
