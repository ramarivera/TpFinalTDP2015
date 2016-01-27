using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Persistence.EntityFramework
{
    class DigitalSignageInitializer : CreateDatabaseIfNotExists<DigitalSignageContext>
    {
        protected override void Seed(DigitalSignageContext pContext)
        {
            pContext.SaveChanges();
        }
    }
}
