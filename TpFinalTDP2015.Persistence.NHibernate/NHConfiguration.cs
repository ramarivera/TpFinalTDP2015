using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TpFinalTDP2015.Persistence.NHibernate
{
    public static class NHConfiguration
    {
        private static Configuration cConfiguration = null;
        private static object cLock = new object();

        public static Configuration Configuration
        {
            get
            {
                lock (cLock)
                {
                    if (cConfiguration == null)
                    {
                        var mapper = new ModelMapper();
                        cConfiguration = new Configuration();

                        mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());

                        cConfiguration.DataBaseIntegration(c =>
                        {
                            c.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DigitalSignageContextSQLEXPRESS"].ConnectionString;
                            c.Driver<Sql2008ClientDriver>();
                            c.Dialect<MsSql2012Dialect>();

                            c.LogSqlInConsole = true;
                            c.LogFormattedSql = true;
                            c.AutoCommentSql = true;
                        });

                        cConfiguration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
                    }
                }

                return cConfiguration;
            }
        }
    }
}
/*

                            




                        string[] resourceNames;
                        string nHResource = string.Empty;
                        Assembly[] asmArray = AppDomain.CurrentDomain.GetAssemblies();

                        foreach (Assembly asm in asmArray)
                        {
                            resourceNames = asm.GetManifestResourceNames();
                            nHResource = resourceNames.FirstOrDefault(x => x.ToLower().Contains("hibernate.config"));
                            if (!string.IsNullOrEmpty(nHResource))
                            {
                                using (Stream resxStream = asm.GetManifestResourceStream(nHResource))
                                {
                                    configuration = new Configuration();
                                    configuration.Configure(new XmlTextReader(resxStream));
                                }
                            }
                        }
*/