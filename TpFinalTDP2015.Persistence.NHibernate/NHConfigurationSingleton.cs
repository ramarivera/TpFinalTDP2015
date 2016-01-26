using NHibernate.Cfg;
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
    public static class NHConfigurationSingleton
    {
        private static Configuration configuration = null;
        private static object lockObj = new object();

        public static Configuration Configuration
        {
            get
            {
                lock (lockObj)
                {
                    if (configuration == null)
                    {
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
                    }
                }

                return configuration;
            }
        }
    }
}
