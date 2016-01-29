using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Persistence.EntityFramework
{
    class DigitalSignageInitializer : DropCreateDatabaseAlways<DigitalSignageContext>
    {
        DigitalSignageContext iContext;

        protected override void Seed(DigitalSignageContext pContext)
        {
            this.iContext = pContext;
            SeedDays();

            pContext.SaveChanges();
        }

        private void SeedDays()
        {
            Day lDay1 = new Day() { Value = Model.Enum.Days.Domingo };
            Day lDay2 = new Day() { Value = Model.Enum.Days.Lunes };
            Day lDay3 = new Day() { Value = Model.Enum.Days.Martes };
            Day lDay4 = new Day() { Value = Model.Enum.Days.Miercoles };
            Day lDay5 = new Day() { Value = Model.Enum.Days.Jueves };
            Day lDay6 = new Day() { Value = Model.Enum.Days.Viernes };
            Day lDay7 = new Day() { Value = Model.Enum.Days.Sabado };

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
