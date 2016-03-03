using Common.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Model.Enum;
using TpFinalTDP2015.Model.DomainServices;

namespace TpFinalTDP2015.Persistence.EntityFramework
{
    class DigitalSignageInitializer : System.Data.Entity.DropCreateDatabaseAlways<DigitalSignageContext>
    {
        private IIntervalValidator iValidator = new IntervalValidator();//TODO ver esto
        private static readonly ILog cLogger = LogManager.GetLogger<DigitalSignageContext>();


        protected override void Seed(DigitalSignageContext pContext)
        {
            cLogger.Debug("Corriendo metodo Seed, super clase: " + this.GetType().BaseType.Name);
            SeedDays(pContext);
            SeedDateIntervals(pContext);
            SeedTimeIntervals(pContext);
            SeedCampaigns(pContext);
            SeedRssSources(pContext);
            SeedStaticTexts(pContext);
            SeedBanners(pContext);
            //  SeedSlides(pContext);

            cLogger.InfoFormat("Metodo Seed terminado \n\n\n\n\n\n");

        }

        private void SeedStaticTexts(DigitalSignageContext pContext)
        {
            for (int i = 0; i < 10; i++)
            {
                StaticText lStaticText = new StaticText()
                {
                    Title = String.Format("Texto {0}", i),
                    Description = String.Format("Texto del {0}", DateTime.Now),
                    Text = String.Format("Texto {0} del {1}", i,DateTime.Now)
                };
                pContext.Texts.Add(lStaticText);
            }

            pContext.SaveChanges();
        }

        private void SeedSlides(DigitalSignageContext pContext)
        {
            throw new NotImplementedException();
        }

        private void SeedRssSources(DigitalSignageContext pContext)
        {
            RssSource lRssSource1 = new RssSource()
            {
                Title = "Noticias de política TN",
                Description = "Noticias de la actualidad política, siendo su fuente Todo Noticias",
                URL = "http://tn.com.ar/feed/politica"
            };

            RssSource lRssSource2 = new RssSource()
            {
                Title = "Noticias de deportes teleSur",
                Description = "Noticias de la actualidad deportiva, siendo su fuente teleSur",
                URL = "http://www.telesurtv.net/rss/RssDeporte.html"
            };

            RssSource lRssSource3 = new RssSource()
            {
                Title = "Noticias de deportes El pais",
                Description = "Noticias de la actualidad deportiva, siendo su fuente el medio internacional El Pais",
                URL = "http://ep00.epimg.net/rss/deportes/portada.xml"
            };

            pContext.RssSources.Add(lRssSource1);
            pContext.RssSources.Add(lRssSource2);
            pContext.RssSources.Add(lRssSource3);
            pContext.SaveChanges();
        }

        private void SeedBanners(DigitalSignageContext pContext)
        {
            IList<DateInterval> lDateIntervalList = pContext.DateIntervals.ToList();
            Banner lBanner1 = new Banner()
            {
                Name = "Noticias de deporte",
                Description = "Noticias de la actualidad deportiva, provenientes de distintas fuentes. Tambien contiene otros textos útiles",
                //falta contenido, pero eso falta tratar los rss
            };
            
            var query = from interval in lDateIntervalList
                        where interval.ActiveDays.Count() == 5
                        select interval;

            foreach (var interval in query)
            {
                lBanner1.AddDateInterval(interval,iValidator);
            };
            lBanner1.Items.Add(pContext.Texts.ToList()[3]);
            lBanner1.Items.Add(pContext.Texts.ToList()[4]);
            //IList<RssSource> lista = pContext.RssSources.ToList();
            lBanner1.RssSources.Add(pContext.RssSources.ToList()[0]);
            lBanner1.RssSources.Add(pContext.RssSources.ToList()[2]);
            pContext.Banners.Add(lBanner1);
        }

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
                lCampaign1.AddDateInterval(interval,iValidator);
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
                lCampaign2.AddDateInterval(interval,iValidator);
            }


            pContext.Set<Campaign>().Add(lCampaign1);
            pContext.Set<Campaign>().Add(lCampaign2);
            //  pContext.Campaigns.Add(lCampaign2);

            pContext.SaveChanges();

        }

        private void SeedTimeIntervals(DigitalSignageContext pContext)
        {
            IList<DateInterval> lDateIntervalList = pContext.Set<DateInterval>().ToList();

            for (int i = 0; i < 20; i+=2)
            {
                TimeInterval lTimeInterval = new TimeInterval()
                {
                    End = new TimeSpan(i + 1, 0, 0),
                    Start = new TimeSpan(i, 0, 0)
                };

                lDateIntervalList[0].AddTimeInterval(lTimeInterval);
            }

            for (int i = 1; i < 23; i += 2)
            {
                TimeInterval lTimeInterval = new TimeInterval()
                {
                    End = new TimeSpan(i + 1, 0, 0),
                    Start = new TimeSpan(i, 0, 0)
                };

                lDateIntervalList[1].AddTimeInterval(lTimeInterval);
            }

            TimeInterval lTinterval = new TimeInterval()
            {
                End = new TimeSpan(12, 0, 0),
                Start = new TimeSpan(08, 0, 0)
            };

            TimeInterval lTinterval2 = new TimeInterval()
            {
                End = new TimeSpan(23, 0, 0),
                Start = new TimeSpan(20, 0, 0)
            };


            lDateIntervalList[2].AddTimeInterval(lTinterval);
            lDateIntervalList[2].AddTimeInterval(lTinterval2);
            //pContext.Set<TimeInterval>().Add(lTinterval);
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

            lDateInterval1.AddDay(lDayList[1]);
            lDateInterval1.AddDay(lDayList[2]);
            lDateInterval1.AddDay(lDayList[3]);
            lDateInterval1.AddDay(lDayList[4]);
            lDateInterval1.AddDay(lDayList[5]);

           /* lDateInterval1.AddActiveHours
            (
                //lTimeIntervalList.FirstOrDefault(i => i.Start == new TimeSpan(8, 0, 0) && i.End == new TimeSpan(12, 0, 0))
                lTimeIntervalList.FirstOrDefault(i => i.Start == new TimeSpan(8, 0, 0) && i.End == new TimeSpan(9, 0, 0))
            );*/

            DateInterval lDateInterval2 = new DateInterval()
            {
                Name = "Sabados y Domingos, empiezan antes de las 12",
                ActiveUntil = new DateTime(2016, 03, 01),
                ActiveFrom = new DateTime(2016, 02, 01)
            };

           /* var query = from interval in lTimeIntervalList
                        where interval.Start < new TimeSpan(12, 0, 0)
                        select interval;

            foreach (var interval in query)
            {
                lDateInterval2.AddActiveHours(interval);
            }*/

            lDateInterval2.AddDay(lDayList[0]);
            lDateInterval2.AddDay(lDayList[6]);

            DateInterval lDateInterval3 = new DateInterval()
            {
                Name = "Miercoles, terminan despues de las 15",
                ActiveUntil = new DateTime(2016, 11, 01),
                ActiveFrom = new DateTime(2016, 10, 01),
            };

          /*  query = from interval in lTimeIntervalList
                        where interval.End > new TimeSpan(15, 0, 0)
                        select interval;

            foreach (var interval in query)
            {
                lDateInterval3.AddActiveHours(interval);
            }*/

            lDateInterval3.AddDay(lDayList[3]);

            pContext.Set<DateInterval>().AddRange(new[] { lDateInterval1, lDateInterval2, lDateInterval3 });
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
