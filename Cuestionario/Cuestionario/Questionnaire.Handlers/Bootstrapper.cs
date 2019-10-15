using Autofac;
using Autofac.Features.ResolveAnything;
using Cuestionario.Model;
using Cuestionario.Services;
using Cuestionario.Services.Interfaces;
using NHibernate;
using Questionnaire.Handlers.Handlers;
using Questionnaire.Handlers.Handlers.Interfaces;

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
            PerformInstancePerLifetimeRegistration<IDifficultyServices, DifficultyServices>(lBuilder);

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
