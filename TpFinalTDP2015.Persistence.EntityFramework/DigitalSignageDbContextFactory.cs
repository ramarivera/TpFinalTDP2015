using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    class DigitalSignageDbContextFactory : IDbContextFactory
    {
        private readonly string iConnString;

        DigitalSignageDbContextFactory(string pConectionStringName)
        {
            if (ConfigurationManager.ConnectionStrings[pConectionStringName] != null)
            {
                iConnString = ConfigurationManager.ConnectionStrings[pConectionStringName].ConnectionString;
            }
            iConnString = ConfigurationManager.ConnectionStrings[@"DigitalSignageContext"].ConnectionString;
        }


        IDbContext IDbContextFactory.CreateContext()
        {
            return new DigitalSignageContext(this.iConnString);
        }
    }
}
