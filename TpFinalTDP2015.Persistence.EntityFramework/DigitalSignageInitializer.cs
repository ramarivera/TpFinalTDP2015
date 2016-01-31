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
            SeedCampaigns(pContext);

        }

        //      Name = "Campaña"

        private void SeedCampaigns(DigitalSignageContext pContext)
        {
            IList<DateInterval> lDateIntervalList = pContext.DateIntervals.ToList();

            Campaign lCampaign1 = new Campaign()
            {
                Name = "Publicidad Samsung S7 (ver 47283289)",
                Description = "Una mas de las muchas campa;as de lagsung"
            };

            var query = from interval in lDateIntervalList
                        where interval.ActiveDays.Count() >= 4
                        select interval;

            foreach (var interval in query)
            {
                lCampaign1.ActiveIntervals.Add(interval);
            };


            Campaign lCampaign2 = new Campaign()
            {
                Name = "Publicidad Apple iPhone 5se",
                Description = "Primera publicidad de Apple en Argentina,"
                               + " para el nuevo celular que no va a dar resultados"
            };

            query = from interval in lDateIntervalList
                        where interval.ActiveFrom <= new DateTime(2016, 02, 01)
                        select interval;

            foreach (var interval in query)
            {
                lCampaign2.ActiveIntervals.Add(interval);
            };


            pContext.Campaigns.Add(lCampaign1);
            pContext.Campaigns.Add(lCampaign2);

            pContext.SaveChanges();

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
            IList<Day> lDayList = pContext.Days.ToList();
            IList<TimeInterval> lTimeIntervalList = pContext.TimeIntervals.ToList();

            DateInterval lDateInterval1 = new DateInterval()
            {
                Name = "Lunes a Viernes, 08am a 12am",
                ActiveUntil = new DateTime(2016, 06, 01),
                ActiveFrom = new DateTime(2016,05,01),
            };

            lDateInterval1.ActiveDays.Add(lDayList[1]);
            //lDateInterval1.ActiveDays.Add(lDayList[1]);
            lDateInterval1.ActiveDays.Add(lDayList[2]);
            lDateInterval1.ActiveDays.Add(lDayList[3]);
            lDateInterval1.ActiveDays.Add(lDayList[4]);
            lDateInterval1.ActiveDays.Add(lDayList[5]);

            lDateInterval1.ActiveHours.Add
            (
                lTimeIntervalList.FirstOrDefault(i => i.Start == new TimeSpan(8, 0, 0) && i.End == new TimeSpan(12, 0, 0))
            );

            DateInterval lDateInterval2 = new DateInterval()
            {
                Name = "Sabados y Domingos, empiezan antes de las 12",
                ActiveUntil = new DateTime(2016, 03, 01),
                ActiveFrom = new DateTime(2016, 02, 01),
                ActiveHours = new List<TimeInterval>()
            };

            var query = from interval in lTimeIntervalList
                        where interval.Start < new TimeSpan(12, 0, 0)
                        select interval;

            foreach (var interval in query)
            {
                lDateInterval2.ActiveHours.Add(interval);
            }

            lDateInterval2.ActiveDays.Add(lDayList[0]);
            lDateInterval2.ActiveDays.Add(lDayList[6]);

            DateInterval lDateInterval3 = new DateInterval()
            {
                Name = "Miercoles, terminan despues de las 15",
                ActiveUntil = new DateTime(2016, 11, 01),
                ActiveFrom = new DateTime(2016, 10, 01),
            };

            query = from interval in lTimeIntervalList
                        where interval.End > new TimeSpan(15, 0, 0)
                        select interval;

            foreach (var interval in query)
            {
                lDateInterval3.ActiveHours.Add(interval);
            }

            lDateInterval3.ActiveDays.Add(lDayList[3]);

            pContext.Set<DateInterval>().AddRange(new[] { lDateInterval1, lDateInterval2, lDateInterval3 });
            //pContext.Set<DateInterval>().Add(lDateInterval1);
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
