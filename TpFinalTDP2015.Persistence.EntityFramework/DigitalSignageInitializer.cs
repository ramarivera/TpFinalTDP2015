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

            TimeInterval lTinterval = new TimeInterval()
            {
                End = new TimeSpan(12, 0, 0),
                Start = new TimeSpan(08, 0, 0)
            };

            pContext.Set<TimeInterval>().AddRange(lList);
            pContext.Set<TimeInterval>().Add(lTinterval);
            pContext.SaveChanges();
        }

        private void SeedDateIntervals(DigitalSignageContext pContext)
        {
            IList<Day> lDayList = pContext.Set<Day>().ToList<Day>();
            IList<TimeInterval> lTimeIntervalList = pContext.Set<TimeInterval>().ToList<TimeInterval>();

            DateInterval lDateInterval1 = new DateInterval()
            {
                Name = "Lunes a Viernes, 08am a 12am",
                ActiveUntil = new DateTime(2016, 03, 01),
                ActiveFrom = new DateTime(2016,02,01),
            };


            lDateInterval1.ActiveDays.Add(lDayList[1]);
            lDateInterval1.ActiveDays.Add(lDayList[2]);
            lDateInterval1.ActiveDays.Add(lDayList[3]);
            lDateInterval1.ActiveDays.Add(lDayList[4]);
            lDateInterval1.ActiveDays.Add(lDayList[5]);

            lDateInterval1.ActiveHours.Add
                (
                    lTimeIntervalList.FirstOrDefault(i => i.Start == new TimeSpan(8,0,0) && i.End  == new TimeSpan(12,0,0))
                );

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

            //pContext.Set<DateInterval>().AddRange(new[] { lDateInterval1, lDateInterval1, lDateInterval1 });
            pContext.Set<DateInterval>().Add(lDateInterval1);
            
            pContext.SaveChanges();
        }

        private void SeedDays(DigitalSignageContext pContext)
        {
            Day lDay1 = new Day() {Value = Model.Enum.Days.Domingo };
            Day lDay2 = new Day() {Value = Model.Enum.Days.Lunes };
            Day lDay3 = new Day() {Value = Model.Enum.Days.Martes };
            Day lDay4 = new Day() {Value = Model.Enum.Days.Miercoles };
            Day lDay5 = new Day() {Value = Model.Enum.Days.Jueves };
            Day lDay6 = new Day() {Value = Model.Enum.Days.Viernes };
            Day lDay7 = new Day() {Value = Model.Enum.Days.Sabado };

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
