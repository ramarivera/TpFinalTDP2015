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

            void PerformInstancePerLifetimeRegistration<TInterface, TImplementation>()
            {
                lBuilder.RegisterType<TImplementation>()
                       .As<TInterface>()
                       .InstancePerLifetimeScope();
            }

            lBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            lBuilder.RegisterInstance(NHibernateHelper.CreateSessionFactory())
                    .SingleInstance();

            lBuilder.Register(c => c.Resolve<ISessionFactory>().GetCurrentSession())
                    .InstancePerLifetimeScope();

            PerformInstancePerLifetimeRegistration<IAnswerSessionServices, AnswerSessionServices>();
            PerformInstancePerLifetimeRegistration<IAnswerSessionHandler, AnswerSessionHandler>();
            PerformInstancePerLifetimeRegistration<ICategoryServices, CategoryServices>();
            PerformInstancePerLifetimeRegistration<IDifficultyServices, DifficultyServices>();

            var lContainer = lBuilder.Build();

            HandlerFactory.ConfigureHandlerFactory(lContainer);
        }
    }
}
