using System.Configuration;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    public class DigitalSignageDbContextFactory : IDbContextFactory
    {
        private readonly string iConnString;

       public DigitalSignageDbContextFactory(string pConectionStringName)
        {
            string lName = pConectionStringName;
            if (ConfigurationManager.ConnectionStrings[pConectionStringName] == null)
            {
                lName = "DigitalSignage";
            }
            iConnString = ConfigurationManager.ConnectionStrings[lName].ConnectionString;

        }


        IDbContext IDbContextFactory.CreateContext()
        {
            return new DigitalSignageContext(this.iConnString);
        }
    }
}
