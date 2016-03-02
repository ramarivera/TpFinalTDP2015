using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TpFinalTDP2015.Model;
using System.Collections.Generic;

namespace TpFinalTDP2015.Test
{
    [TestClass]
    public class DateIntervalTest
    {
        [TestMethod]
        public void ActiveHours_ShouldNotBeAbleToClearBackingField()
        {
            DateInterval lDateInterval1 = new DateInterval()
            {
                Name = "Lunes a Viernes, 08am a 12am",
                ActiveUntil = new DateTime(2016, 06, 01),
                ActiveFrom = new DateTime(2016, 05, 01),
            };

            for (int i = 0; i < 20; i += 2)
            {
                TimeInterval lTimeInterval = new TimeInterval()
                {
                    End = new TimeSpan(i + 1, 0, 0),
                    Start = new TimeSpan(i, 0, 0)
                };

                lDateInterval1.AddTimeInterval(lTimeInterval);
            }


            lDateInterval1.AddDay(new Day() { Value = Model.Enum.Days.Domingo });
            lDateInterval1.AddDay(new Day() { Value = Model.Enum.Days.Lunes });
            lDateInterval1.AddDay(new Day() { Value = Model.Enum.Days.Martes });
            lDateInterval1.AddDay(new Day() { Value = Model.Enum.Days.Miercoles });
            lDateInterval1.AddDay(new Day() { Value = Model.Enum.Days.Jueves });
            lDateInterval1.AddDay(new Day() { Value = Model.Enum.Days.Viernes });
            lDateInterval1.AddDay(new Day() { Value = Model.Enum.Days.Sabado });



            lDateInterval1.ActiveDays.Clear();


            Assert.AreEqual(lDateInterval1.ActiveDays.Count,7);
        }
    }
}
