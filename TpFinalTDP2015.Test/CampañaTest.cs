using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Model.Enum;

namespace TpFinalTDP2015.Test
{
    [TestClass]
    public class CampañaTest
    {
        [TestMethod]
        public void ActiveForDate_IsActive()
        {
            Campaign lCampaign = new Campaign() { Name = "Venta de cactus",Description="Publicidad para la venta de cactus para el vivero XX" };

            DateInterval lInterval = new DateInterval() {Name="Miércoles y Jueves de la primera quincena de febrero", ActiveUntil = new DateTime(2016, 2, 15), ActiveFrom = new DateTime(2016, 2, 1) };

            Day lDay1 = new Day() { Id = 4, Value = Days.Miercoles };
            Day lDay2 = new Day() { Id = 5, Value = Days.Jueves };

            lInterval.AddDay(lDay1);
            lInterval.AddDay(lDay2);

            TimeSpan time1 = new TimeSpan(18, 0, 0);
            TimeSpan time2 = new TimeSpan(21, 0, 0);

            TimeInterval lTimeInterval = new TimeInterval() { End = time2, Start = time1 };

            lInterval.AddTimeInterval(lTimeInterval);

            lCampaign.AddDateInterval(lInterval);

            DateTime lDate = new DateTime(2016, 2, 3,19,0,0);

            bool lResult = lCampaign.IsActiveAt(lDate);

            Assert.IsTrue(lResult);
        }
    }
}
