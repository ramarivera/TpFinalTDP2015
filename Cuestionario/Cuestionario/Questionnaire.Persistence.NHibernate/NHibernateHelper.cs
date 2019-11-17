using Autofac;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Questionnaire.Model;
using Questionnaire.Persistence.NHibernate.Mappings;
using Questionnaire.Persistence.NHibernate.Repository;
using Questionnaire.Persistence.NHibernate.UnitOfWork;
using Questionnaire.Persistence.Repository;
using Questionnaire.Persistence.UnitOfWork;
using Questionnaire.Utilities;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace Questionnaire.Persistence.NHibernate
{
    // TODO missing documentation
    public static class NHibernateHelper
    {
        private const string DEFAULT_CONNECTION_STRING_KEY = "DEFAULT";
        private readonly static MethodInfo GetRepositoryMethod =
            Reflect<IUnitOfWork>.Method(x => x.GetRepository<Question>());

        public static void ConfigureContainer(ContainerBuilder pContainerBuilder)
        {
            pContainerBuilder.RegisterType<NHibernateUnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            pContainerBuilder.RegisterGeneric(typeof(NHibernateGenericRepository<>)).OnActivating(e =>
            {
                if (e.Parameters.FirstOrDefault() is TypedParameter typeParam)
                {
                    var lUnitOfWork = e.Context.Resolve<IUnitOfWork>();
                    var lRepositoryType = typeParam.Value.GetType();
                    var lGenericGetRepositoryMethod = GetRepositoryMethod.MakeGenericMethod(lRepositoryType);
                    var lGenericRepository = lGenericGetRepositoryMethod.Invoke(lUnitOfWork, null);
                    e.ReplaceInstance(lGenericRepository);
                }
            }).As(typeof(IRepository<>));
        }

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(GetConnectionString()))
                .CurrentSessionContext("async_local")
                .Mappings(m => m
                    .FluentMappings.AddFromAssemblyOf<AnswerMap>())
                .BuildSessionFactory();
        }

        private static string GetConnectionString()
        {
            var lMachineName = Environment.MachineName.ToUpper();
            var lConnectionString = ConfigurationManager.ConnectionStrings[lMachineName] ??
                ConfigurationManager.ConnectionStrings[DEFAULT_CONNECTION_STRING_KEY];

            if (lConnectionString == null)
            {
                throw new Exception("No connection string matching machine name or default was found.");
            }

            return lConnectionString.ConnectionString;
        }
    }
}