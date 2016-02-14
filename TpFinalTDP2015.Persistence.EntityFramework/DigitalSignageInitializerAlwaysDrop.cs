using Common.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Model.Enum;

namespace TpFinalTDP2015.Persistence.EntityFramework
{
    class DigitalSignageInitializerAlwaysDrop : System.Data.Entity.DropCreateDatabaseAlways<DigitalSignageContext>
    {
        private static readonly ILog cLogger = LogManager.GetLogger<DigitalSignageContext>();

        protected override void Seed(DigitalSignageContext pContext)
        {
            DigitalSignageDataSeeder.SeedData(pContext);
        }
    }
}
