using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Cuestionario.Model
{
    public static class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString("Data Source=localhost\\RAR_MSSQL17;Integrated Security=SSPI;Initial Catalog=MARR.Questionnaire")
                    //.ShowSql()
                    )
                .CurrentSessionContext("thread_static")
                .Mappings(m => m
                    .FluentMappings.AddFromAssemblyOf<Question>())
                .BuildSessionFactory();
        }
    }
}