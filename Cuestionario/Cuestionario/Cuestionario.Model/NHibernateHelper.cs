using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace Cuestionario.Model
{
    public class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString("Data Source=THINKPAD\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Cuestionario")
                    //.ShowSql()
                    )
                .Mappings(m => m
                    .FluentMappings.AddFromAssemblyOf<Program>())
                .BuildSessionFactory();
        }
    }
}