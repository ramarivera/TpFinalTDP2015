using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.NHibernate
{
    public static class NHSessionFactorySingleton
    {
        private static ISessionFactory sessionFactory = null;
        private static object lockObj = new object();

        public static ISessionFactory SessionFactory
        {
            get
            {
                lock (lockObj)
                {
                    if (sessionFactory == null)
                    {
                        sessionFactory = NHConfigurationSingleton.Configuration.BuildSessionFactory();
                    }
                }

                return sessionFactory;
            }
        }
    }
}
