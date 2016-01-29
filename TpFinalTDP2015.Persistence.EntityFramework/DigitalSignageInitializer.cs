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
    class DigitalSignageInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DigitalSignageContext>
    {
        private static readonly ILog cLogger = LogManager.GetLogger<DigitalSignageContext>();

        DigitalSignageContext iContext;

        protected override void Seed(DigitalSignageContext pContext)
        {
            this.iContext = pContext;
            cLogger.Debug("Corriendo metodo Seed, super clase: " + this.GetType().BaseType.Name);
            SeedDays();

            pContext.SaveChanges();
        }

        private void SeedDays()
        {
            Day lDay1 = new Day() { Id = 01, Value = Model.Enum.Days.Domingo };
            Day lDay2 = new Day() { Id = 02, Value = Model.Enum.Days.Lunes };
            Day lDay3 = new Day() { Id = 03, Value = Model.Enum.Days.Martes };
            Day lDay4 = new Day() { Id = 04, Value = Model.Enum.Days.Miercoles };
            Day lDay5 = new Day() { Id = 05, Value = Model.Enum.Days.Jueves };
            Day lDay6 = new Day() { Id = 06, Value = Model.Enum.Days.Viernes };
            Day lDay7 = new Day() { Id = 07, Value = Model.Enum.Days.Sabado };

            IList<Day> lList = new List<Day>()
                {
                    lDay1,
                    lDay2,
                    lDay3,
                    lDay4,
                    lDay5,
                    lDay6,
                    lDay7
                };

            this.iContext.Set<Day>().AddRange(lList);
        }
    }
}
