using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Configuration;

namespace Questionnaire.Persistence
{
    public static class NHibernateHelper
    {
        private const string DEFAULT_CONNECTION_STRING_KEY = "DEFAULT";

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(GetConnectionString()))
                .CurrentSessionContext("thread_static")
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