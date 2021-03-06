﻿using log4net;
using MarrSystems.TpFinalTDP2015.CrossCutting.Enum;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Model.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarrSystems.TpFinalTDP2015.Persistence.EntityFramework
{
    class DigitalSignageInitializer : System.Data.Entity.DropCreateDatabaseAlways<DigitalSignageContext>//CreateDatabaseIfNotExists<DigitalSignageContext> 
    {
        private static readonly ILog cLogger = MarrSystems.TpFinalTDP2015.CrossCutting.Logging.LogManagerWrapper.GetLogger<DigitalSignageContext>();

        protected override void Seed(DigitalSignageContext pContext)
        {
            cLogger.Debug("Corriendo metodo Seed, super clase: " + this.GetType().BaseType.Name);
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
            IList<Schedule> lDateIntervalList = pContext.DateIntervals.ToList();
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
                lBanner1.AddSchedule(DomainServiceLocator.Resolve<IScheduleChecker>(),interval);
            };

            lBanner1.AddBannerItem(pContext.Texts.ToList()[3]);
            lBanner1.AddBannerItem(pContext.Texts.ToList()[4]);
            //IList<RssSource> lista = pContext.RssSources.ToList();
            lBanner1.AddSource(pContext.RssSources.ToList()[0]);
            lBanner1.AddSource(pContext.RssSources.ToList()[2]);
            pContext.Banners.Add(lBanner1);
        }

        private void SeedCampaigns(DigitalSignageContext pContext)
        {
            IList<Schedule> lDateIntervalList = pContext.DateIntervals.ToList();

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
                lCampaign1.AddSchedule(DomainServiceLocator.Resolve<IScheduleChecker>(), interval);
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
                lCampaign2.AddSchedule(DomainServiceLocator.Resolve<IScheduleChecker>(), interval);
            }


            pContext.Set<Campaign>().Add(lCampaign1);
            pContext.Set<Campaign>().Add(lCampaign2);
            //  pContext.Campaigns.Add(lCampaign2);

            pContext.SaveChanges();

        }

        private void SeedTimeIntervals(DigitalSignageContext pContext)
        {
            IList<Schedule> lDateIntervalList = pContext.Set<Schedule>().ToList();

            for (int i = 0; i < 20; i+=2)
            {
                ScheduleEntry lTimeInterval = new ScheduleEntry()
                {
                    End = new TimeSpan(i + 1, 0, 0),
                    Start = new TimeSpan(i, 0, 0)
                };

                lDateIntervalList[0].AddTimeInterval(lTimeInterval);
            }

            for (int i = 1; i < 23; i += 2)
            {
                ScheduleEntry lTimeInterval = new ScheduleEntry()
                {
                    End = new TimeSpan(i + 1, 0, 0),
                    Start = new TimeSpan(i, 0, 0)
                };

                lDateIntervalList[1].AddTimeInterval(lTimeInterval);
            }

            ScheduleEntry lTinterval = new ScheduleEntry()
            {
                End = new TimeSpan(12, 0, 0),
                Start = new TimeSpan(08, 0, 0)
            };

            ScheduleEntry lTinterval2 = new ScheduleEntry()
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
            IList<Days> lDayList = new List<Days>
            {
                Days.Domingo,
                Days.Lunes,
                Days.Martes,
                Days.Miercoles,
                Days.Jueves,
                Days.Viernes,
                Days.Sabado,
            };


            IList<ScheduleEntry> lTimeIntervalList = pContext.TimeIntervals.ToList();

            Schedule lDateInterval1 = new Schedule()
            {
                Name = "Lunes a Viernes, 08am a 12am",
                ActiveUntil = new DateTime(2016, 06, 01),
                ActiveFrom = new DateTime(2016,05,01),
            };

            lDateInterval1.Monday = true;
            lDateInterval1.Tuesday = true;
            lDateInterval1.Wednesday = true;
            lDateInterval1.Thursday = true;
            lDateInterval1.Friday = true;

           /* lDateInterval1.AddActiveHours
            (
                //lTimeIntervalList.FirstOrDefault(i => i.Start == new TimeSpan(8, 0, 0) && i.End == new TimeSpan(12, 0, 0))
                lTimeIntervalList.FirstOrDefault(i => i.Start == new TimeSpan(8, 0, 0) && i.End == new TimeSpan(9, 0, 0))
            );*/

            Schedule lDateInterval2 = new Schedule()
            {
                Name = "Sabados y Domingos, empiezan antes de las 12",
                ActiveUntil = new DateTime(2016, 03, 01),
                ActiveFrom = new DateTime(2016, 02, 01)
            };

            lDateInterval2.Saturday = true;
            lDateInterval2.Sunday = true;

            Schedule lDateInterval3 = new Schedule()
            {
                Name = "Miercoles, terminan despues de las 15",
                ActiveUntil = new DateTime(2016, 11, 01),
                ActiveFrom = new DateTime(2016, 10, 01),
            };

            lDateInterval3.Wednesday = true;

            pContext.Set<Schedule>().AddRange(new[] { lDateInterval1, lDateInterval2, lDateInterval3 });
            pContext.Set<Schedule>().Add(lDateInterval1);
            pContext.SaveChanges();
        }


    }
}
