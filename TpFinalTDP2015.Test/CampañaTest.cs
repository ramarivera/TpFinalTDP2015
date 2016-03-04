﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Model.DomainServices;
using MarrSystems.TpFinalTDP2015.CrossCutting.Enum;

namespace MarrSystems.TpFinalTDP2015.Test
{
    [TestClass]
    public class CampañaTest
    {
        private IScheduleChecker iValidator = new ScheduleChecker();//TODO ver esto
        private ISeFijaSiEstaActivo iActivo = new SeFijaSiEstaActivo();//TODO ver esto
        [TestMethod]
        public void ActiveForDate_IsActive()
        {
            Campaign lCampaign = new Campaign() { Name = "Venta de cactus",Description="Publicidad para la venta de cactus para el vivero XX" };

            Schedule lInterval = new Schedule() {Name="Miércoles y Jueves de la primera quincena de febrero", ActiveUntil = new DateTime(2016, 2, 15), ActiveFrom = new DateTime(2016, 2, 1) };

            Day lDay1 = new Day() { Id = 4, Value = Days.Miercoles };
            Day lDay2 = new Day() { Id = 5, Value = Days.Jueves };

            lInterval.AddDay(lDay1);
            lInterval.AddDay(lDay2);

            TimeSpan time1 = new TimeSpan(18, 0, 0);
            TimeSpan time2 = new TimeSpan(21, 0, 0);

            ScheduleEntry lTimeInterval = new ScheduleEntry() { End = time2, Start = time1 };

            lInterval.AddTimeInterval(lTimeInterval);

            lCampaign.AddSchedule(iValidator,lInterval);

            DateTime lDate = new DateTime(2016, 2, 3,19,0,0);

            bool lResult = lCampaign.IsActiveAt(iValidator,lDate);

            Assert.IsTrue(lResult);
        }
    }
}
