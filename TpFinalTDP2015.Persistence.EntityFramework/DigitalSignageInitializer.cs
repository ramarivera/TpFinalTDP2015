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
    class DigitalSignageInitializer : System.Data.Entity.DropCreateDatabaseAlways<DigitalSignageContext>
    {
        private static readonly ILog cLogger = LogManager.GetLogger<DigitalSignageContext>();


        protected override void Seed(DigitalSignageContext pContext)
        {
            cLogger.Debug("Corriendo metodo Seed, super clase: " + this.GetType().BaseType.Name);
            SeedDays(pContext);
            SeedTimeIntervals(pContext);
            SeedDateIntervals(pContext);
            pContext.SaveChanges();
        }

        private void SeedTimeIntervals(DigitalSignageContext pContext)
        {
            IList<TimeInterval> lList = new List<TimeInterval>();

            for (int i = 0; i < 20; i+=2)
            {
                TimeInterval lTimeInterval = new TimeInterval()
                {
                    Start = new TimeSpan(i, 0, 0),
                    End = new TimeSpan(i + 1, 0, 0)
                };

                lList.Add(lTimeInterval);
            }

            pContext.Set<TimeInterval>().AddRange(lList);
        }

        private void SeedDateIntervals(DigitalSignageContext pContext)
        {
            //throw new NotImplementedException();
        }

        private void SeedDays(DigitalSignageContext pContext)
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

            pContext.Set<Day>().AddRange(lList);
        }
    }
}
