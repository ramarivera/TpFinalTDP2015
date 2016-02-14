using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Model.Enum;

namespace TpFinalTDP2015.Test
{
    [TestClass]
    public class BannerTest
    {
        [TestMethod]
        public void ActiveForDate_IsActive()
        {
            Banner lBanner = new Banner() { Name = "Informacion deportiva", Description = "Noticias del ámbito deportivo nacional de distintas fuentes" };

            DateInterval lInterval = new DateInterval() { Name="Mes de febrero, de lunes a viernes por la mañana",ActiveUntil = new DateTime(2016, 2, 29), ActiveFrom = new DateTime(2016, 2, 1) };

            Day lDay1 = new Day() { Id = 1, Value = Days.Lunes };
            Day lDay2 = new Day() { Id = 2, Value = Days.Martes };
            Day lDay3 = new Day() { Id = 3, Value = Days.Miercoles };
            Day lDay4 = new Day() { Id = 4, Value = Days.Jueves };
            Day lDay5 = new Day() { Id = 5, Value = Days.Viernes };

            lInterval.AddActiveDay(lDay1);
            lInterval.AddActiveDay(lDay2);
            lInterval.AddActiveDay(lDay3);
            lInterval.AddActiveDay(lDay4);
            lInterval.AddActiveDay(lDay5);

            TimeSpan time1 = new TimeSpan(8, 0, 0);
            TimeSpan time2 = new TimeSpan(12, 0, 0);

            TimeInterval lTimeInterval = new TimeInterval() { End = time2, Start = time1 };

            lInterval.AddActiveHours(lTimeInterval);

            lBanner.AddDateInterval(lInterval);

            DateTime lDate = new DateTime(2016, 2, 4,20,0,0);

            bool lResult = lBanner.ActiveForDate(lDate);

            Assert.IsFalse(lResult);
        }
    }
}
