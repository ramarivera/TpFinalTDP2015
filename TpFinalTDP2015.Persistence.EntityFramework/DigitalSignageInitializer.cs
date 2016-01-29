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
        }

        private void SeedTimeIntervals(DigitalSignageContext pContext)
        {
            IList<TimeInterval> lList = new List<TimeInterval>();

            for (int i = 0; i < 20; i+=2)
            {
                TimeInterval lTimeInterval = new TimeInterval()
                {
                    End = new TimeSpan(i + 1, 0, 0),
                    Start = new TimeSpan(i, 0, 0)
                };

                lList.Add(lTimeInterval);
            }

            for (int i = 1; i < 23; i += 2)
            {
                TimeInterval lTimeInterval = new TimeInterval()
                {
                    End = new TimeSpan(i + 1, 0, 0),
                    Start = new TimeSpan(i, 0, 0)
                };

                lList.Add(lTimeInterval);
            }

            pContext.Set<TimeInterval>().AddRange(lList);
            pContext.SaveChanges();
        }

        private void SeedDateIntervals(DigitalSignageContext pContext)
        {
            IList<Day> lDayList = pContext.Set<Day>().ToList<Day>();

            DateInterval lDateInterval1 = new DateInterval()
            {
                Name = "Lunes a Viernes, 08am a 12am",
                ActiveUntil = new DateTime(2016, 03, 01),
                ActiveFrom = new DateTime(2016,02,01),
                ActiveDays = new List<Day>()
                {
                    lDayList[1],
                    lDayList[2],
                    lDayList[3],
                    lDayList[4],
                    lDayList[5],
                },
                ActiveHours = new List<TimeInterval>()
                {
                    new TimeInterval()
                    {
                        End = new TimeSpan(12, 0, 0),
                        Start = new TimeSpan(08, 0, 0)
                    },
                },
            };


            DateInterval lDateInterval2 = new DateInterval()
            {
                Name = "Sabados y Domingos, 21-23",
                ActiveUntil = new DateTime(2016, 03, 01),
                ActiveFrom = new DateTime(2016, 02, 01),
                ActiveDays = new List<Day>()
                {
                    lDayList[0],
                    lDayList[6],
                },
                ActiveHours = new List<TimeInterval>()
                {
                    new TimeInterval()
                    {
                        End = new TimeSpan(23, 0, 0),
                        Start = new TimeSpan(21, 0, 0)
                    },
                },
            };


            DateInterval lDateInterval3 = new DateInterval()
            {
                Name = "Miercoles, 12-13 y 15-16",
                ActiveUntil = new DateTime(2016, 03, 01),
                ActiveFrom = new DateTime(2016, 02, 01),
                ActiveDays = new List<Day>()
                {
                    lDayList[3],
                },
                ActiveHours = new List<TimeInterval>()
                {
                    new TimeInterval()
                    {
                        End = new TimeSpan(13, 0, 0),
                        Start = new TimeSpan(12, 0, 0)
                    },
                    new TimeInterval()
                    {
                        End = new TimeSpan(16, 0, 0),
                        Start = new TimeSpan(15, 0, 0)
                    },
                },
            };

            pContext.Set<DateInterval>().AddRange(new[] { lDateInterval1, lDateInterval1, lDateInterval1 });
            pContext.SaveChanges();
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
            pContext.SaveChanges();
        }

    }
}
