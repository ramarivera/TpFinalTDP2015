using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Persistence.EntityFramework.Configuration;

namespace TpFinalTDP2015.Persistence.EntityFramework
{
    public static class EFConfiguration
    {
        private static void AddConfigurations(DbModelBuilder pModel)
        {
            Type lType = typeof(IEntityConfiguration);
            Assembly lAssembly = AppDomain
                                .CurrentDomain.GetAssemblies()
                                .Where(asm => asm.GetTypes().Contains(lType))
                                .FirstOrDefault();

            pModel.Configurations.AddFromAssembly(lAssembly);
        }

        public static void Configure(DbModelBuilder pModel)
        {
            pModel.HasDefaultSchema("MARR");
            AddConfigurations(pModel);
        }

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DigitalSignage"].ConnectionString;
            }
        }
    }
}
