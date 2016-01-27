using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.EntityFramework.Configuration
{
    public interface IEntityConfiguration
    {
        void AddConfiguration(ConfigurationRegistrar pRegistrar);
    }
}
