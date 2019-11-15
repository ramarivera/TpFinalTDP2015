﻿using System;
using Autofac;
using Autofac.Features.ResolveAnything;
using AutoMapper;
using NHibernate;
using Questionnaire.Handlers.DependencyInjection;
using Questionnaire.Handlers.Handlers;
using Questionnaire.Handlers.Handlers.Interfaces;
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
            PerformInstancePerLifetimeRegistration<IUserAnswerServices, UserAnswerServices>(lBuilder);
            PerformInstancePerLifetimeRegistration<IUserAnswerHandler, UserAnswerHandler>(lBuilder);

            PerformInstancePerLifetimeRegistration<IContainer, AutofacContainer>(lBuilder);

            lBuilder.RegisterType<OpenTriviaQuestionsServices>()
                  .Named<IQuestionProvider>(QuestionProviderType.OpenTrivia.ToString().ToUpper())
                  .InstancePerLifetimeScope();

            ConfigureAutomapper(lBuilder);

            ConfigurePersistence(lBuilder);
           
            var lContainer = lBuilder.Build();

            HandlerFactory.ConfigureHandlerFactory(lContainer);
        }

        private static void ConfigurePersistence(ContainerBuilder lBuilder)
        {
            NHibernateHelper.ConfigureContainer(lBuilder);
        }

        private static void PerformInstancePerLifetimeRegistration<TInterface, TImplementation>(ContainerBuilder pBuilder)
        {
            pBuilder.RegisterType<TImplementation>()
                   .As<TInterface>()
                   .InstancePerLifetimeScope();
        }

        private static void ConfigureAutomapper(ContainerBuilder lBuilder)
        {
            var lConfiguration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(IQuestionServices).Assembly));

            lBuilder.RegisterInstance(lConfiguration);

            lBuilder.Register(
              ctx =>
              {
                  var scope = ctx.Resolve<ILifetimeScope>();
                  return new Mapper(ctx.Resolve<IConfigurationProvider>(), scope.Resolve);
              })
              .As<IMapper>()
              .InstancePerLifetimeScope();
        }
    }
}
