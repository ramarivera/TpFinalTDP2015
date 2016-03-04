using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Model.Enum;
using MarrSystems.TpFinalTDP2015.Model.DomainServices;
using MarrSystems.TpFinalTDP2015.CrossCutting.Enum;

namespace MarrSystems.TpFinalTDP2015.Test
{
    [TestClass]
    public class BannerTest
    {
       
        [TestMethod]
        public void ActiveForDate_IsActive()
        {
            Banner lBanner = new Banner() { Name = "Informacion deportiva", Description = "Noticias del ámbito deportivo nacional de distintas fuentes" };

            Schedule lInterval = new Schedule() { Name="Mes de febrero, de lunes a viernes por la mañana",ActiveUntil = new DateTime(2016, 2, 29), ActiveFrom = new DateTime(2016, 2, 1) };

            Day lDay1 = new Day() { Id = 1, Value = Days.Lunes };
            Day lDay2 = new Day() { Id = 2, Value = Days.Martes };
            Day lDay3 = new Day() { Id = 3, Value = Days.Miercoles };
            Day lDay4 = new Day() { Id = 4, Value = Days.Jueves };
            Day lDay5 = new Day() { Id = 5, Value = Days.Viernes };

            lInterval.AddDay(lDay1);
            lInterval.AddDay(lDay2);
            lInterval.AddDay(lDay3);
            lInterval.AddDay(lDay4);
            lInterval.AddDay(lDay5);

            TimeSpan time1 = new TimeSpan(8, 0, 0);
            TimeSpan time2 = new TimeSpan(12, 0, 0);

            ScheduleEntry lTimeInterval = new ScheduleEntry() { End = time2, Start = time1 };

            lInterval.AddTimeInterval(lTimeInterval);

            lBanner.AddSchedule(DomainServiceLocator.Resolve<IScheduleChecker>(), lInterval);

            DateTime lDate = new DateTime(2016, 2, 4,20,0,0);

            bool lResult = lBanner.IsActiveAt(DomainServiceLocator.Resolve<IScheduleChecker>(), lDate);

            Assert.IsFalse(lResult);
        }
    }
}
