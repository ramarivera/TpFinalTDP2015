using Autofac;
using Autofac.Features.ResolveAnything;
using Cuestionario.Services;
using Cuestionario.Services.Interfaces;
using Cuestionario.Services.OpenTrivia;
using NHibernate;
using Questionnaire.Handlers.DependencyInjection;
using Questionnaire.Handlers.Handlers;
using Questionnaire.Handlers.Handlers.Interfaces;
using Questionnaire.Persistence;
using Questionnaire.Services.DependencyInjection;
using IContainer = Questionnaire.Services.DependencyInjection.IContainer;

namespace Questionnaire.Handlers
{
    public  class Bootstrapper
    {
        public static void BootstrapApplication()
        {
            var lBuilder = new ContainerBuilder();

            lBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            lBuilder.RegisterInstance(NHibernateHelper.CreateSessionFactory())
                    .SingleInstance();

            lBuilder.Register(c => c.Resolve<ISessionFactory>().GetCurrentSession())
                    .InstancePerLifetimeScope();

            PerformInstancePerLifetimeRegistration<IAnswerSessionServices, AnswerSessionServices>(lBuilder);
            PerformInstancePerLifetimeRegistration<IAnswerSessionHandler, AnswerSessionHandler>(lBuilder);
            PerformInstancePerLifetimeRegistration<ICategoryServices, CategoryServices>(lBuilder);
            PerformInstancePerLifetimeRegistration<ICategoryHandler, CategoryHandler>(lBuilder);
            PerformInstancePerLifetimeRegistration<IDifficultyServices, DifficultyServices>(lBuilder);
            PerformInstancePerLifetimeRegistration<IDifficultyHandler, DifficultyHandler>(lBuilder);
            PerformInstancePerLifetimeRegistration<IQuestionServices, QuestionServices>(lBuilder);
            PerformInstancePerLifetimeRegistration<IQuestionHandler, QuestionHandler>(lBuilder);

            PerformInstancePerLifetimeRegistration<IContainer, AutofacContainer>(lBuilder);

            lBuilder.RegisterType<OpenTriviaQuestionsServices>()
                  .Named<IQuestionProvider>(QuestionProviderType.OpenTrivia.ToString().ToUpper())
                  .InstancePerLifetimeScope();

            var lContainer = lBuilder.Build();

            HandlerFactory.ConfigureHandlerFactory(lContainer);
        }


        private static void PerformInstancePerLifetimeRegistration<TInterface, TImplementation>(ContainerBuilder pBuilder)
        {
            pBuilder.RegisterType<TImplementation>()
                   .As<TInterface>()
                   .InstancePerLifetimeScope();
        }
    }
}
