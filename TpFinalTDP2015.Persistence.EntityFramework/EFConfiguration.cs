using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Persistence.EntityFramework.Mapping;

namespace TpFinalTDP2015.Persistence.EntityFramework
{
    public static class EFConfiguration
    {
      /*  private static void AddConfigurations(DbModelBuilder pModel)
        {
            pModel.Configurations.AddFromAssembly(typeof(EFConfiguration).Assembly);
        }*/

        public static void Configure(DbModelBuilder pModel)
        {
            pModel.HasDefaultSchema("MARR");
            pModel.Configurations.AddFromAssembly(typeof(EFConfiguration).Assembly);
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
