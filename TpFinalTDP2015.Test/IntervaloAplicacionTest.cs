using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.CrossCutting.Enum;

namespace MarrSystems.TpFinalTDP2015.Test
{
    [TestClass]
    public class IntervaloAplicacionTest
    {
        [TestMethod]
        public void IntersectionWith_NingunaInterseccion()
        {
            DateInterval lInterval1 = new DateInterval() { ActiveUntil = new DateTime(2016, 2, 20), ActiveFrom = new DateTime(2016, 2, 2) };
            DateInterval lInterval2 = new DateInterval() { ActiveUntil = new DateTime(2016, 2, 27), ActiveFrom = new DateTime(2016, 2, 20) };

            Day lDay1 = new Day() { Id = 0, Value = Days.Domingo };
            Day lDay2 = new Day() { Id = 1, Value = Days.Lunes };
            Day lDay3 = new Day() { Id = 2, Value = Days.Martes };

            lInterval1.AddDay(lDay1);
            lInterval1.AddDay(lDay2);
            lInterval2.AddDay(lDay3);

            TimeSpan time1 = new TimeSpan(8, 0, 0);
            TimeSpan time2 = new TimeSpan(12, 0, 0);
            TimeSpan time3 = new TimeSpan(18, 0, 0);
            TimeSpan time4 = new TimeSpan(21, 0, 0);

            TimeInterval lTimeInterval1 = new TimeInterval() { End = time2, Start = time1 }; //8 a 12
            TimeInterval lTimeInterval2 = new TimeInterval() { End = time3, Start = time2 };//12 a 18
            TimeInterval lTimeInterval3 = new TimeInterval() { End = time4, Start = time3 };//18 a 21

            lInterval1.AddTimeInterval(lTimeInterval1);
            lInterval1.AddTimeInterval(lTimeInterval2);
            lInterval2.AddTimeInterval(lTimeInterval3);

            bool lResult = lInterval1.IntersectsWith(lInterval2);

            Assert.IsFalse(lResult);
        }

        [TestMethod]
        public void IntersectionWith_InterseccionSoloDeFechas()
        {
            DateInterval lInterval1 = new DateInterval() { ActiveUntil = new DateTime(2016, 2, 20), ActiveFrom = new DateTime(2016, 2, 2) };
            DateInterval lInterval2 = new DateInterval() { ActiveUntil = new DateTime(2016, 2, 26), ActiveFrom = new DateTime(2016, 2, 18) };

            Day lDay1 = new Day() { Id = 0, Value = Days.Domingo };
            Day lDay2 = new Day() { Id = 1, Value = Days.Lunes };
            Day lDay3 = new Day() { Id = 2, Value = Days.Martes };

            lInterval1.AddDay(lDay1);
            lInterval1.AddDay(lDay2);
            lInterval2.AddDay(lDay3);

            TimeSpan time1 = new TimeSpan(8, 0, 0);
            TimeSpan time2 = new TimeSpan(12, 0, 0);
            TimeSpan time3 = new TimeSpan(18, 0, 0);
            TimeSpan time4 = new TimeSpan(21, 0, 0);

            TimeInterval lTimeInterval1 = new TimeInterval() { End = time2, Start = time1 }; //8 a 12
            TimeInterval lTimeInterval2 = new TimeInterval() { End = time3, Start = time2 };//12 a 18
            TimeInterval lTimeInterval3 = new TimeInterval() { End = time4, Start = time3 };//18 a 21

            lInterval1.AddTimeInterval(lTimeInterval1);
            lInterval1.AddTimeInterval(lTimeInterval2);
            lInterval2.AddTimeInterval(lTimeInterval3);

            bool lResult = lInterval1.IntersectsWith(lInterval2);

            Assert.IsFalse(lResult);
        }
        [TestMethod]
        public void IntersectionWith_InterseccionDeFechasYDias()
        {
            DateInterval lInterval1 = new DateInterval() { ActiveUntil = new DateTime(2016, 2, 20), ActiveFrom = new DateTime(2016, 2, 2) };
            DateInterval lInterval2 = new DateInterval() { ActiveUntil = new DateTime(2016, 2, 26), ActiveFrom = new DateTime(2016, 2, 18) };

            Day lDay1 = new Day() { Id = 0, Value = Days.Domingo };
            Day lDay2 = new Day() { Id = 1, Value = Days.Lunes };
            Day lDay3 = new Day() { Id = 2, Value = Days.Martes };

            lInterval1.AddDay(lDay1);
            lInterval1.AddDay(lDay2);
            lInterval2.AddDay(lDay3);
            lInterval2.AddDay(lDay1);

            TimeSpan time1 = new TimeSpan(8, 0, 0);
            TimeSpan time2 = new TimeSpan(12, 0, 0);
            TimeSpan time3 = new TimeSpan(18, 0, 0);
            TimeSpan time4 = new TimeSpan(21, 0, 0);

            TimeInterval lTimeInterval1 = new TimeInterval() { End = time2, Start = time1 }; //8 a 12
            TimeInterval lTimeInterval2 = new TimeInterval() { End = time3, Start = time2 };//12 a 18
            TimeInterval lTimeInterval3 = new TimeInterval() { End = time4, Start = time3 };//18 a 21

            lInterval1.AddTimeInterval(lTimeInterval1);
            lInterval1.AddTimeInterval(lTimeInterval2);
            lInterval2.AddTimeInterval(lTimeInterval3);

            bool lResult = lInterval1.IntersectsWith(lInterval2);

            Assert.IsFalse(lResult);
        }
        [TestMethod]
        public void IntersectionWith_InterseccionTotal()
        {
            DateInterval lInterval1 = new DateInterval() { ActiveUntil = new DateTime(2016, 2, 20), ActiveFrom = new DateTime(2016, 2, 2) };
            DateInterval lInterval2 = new DateInterval() { ActiveUntil = new DateTime(2016, 2, 26), ActiveFrom = new DateTime(2016, 2, 18) };

            Day lDay1 = new Day() { Id = 0, Value = Days.Domingo };
            Day lDay2 = new Day() { Id = 1, Value = Days.Lunes };
            Day lDay3 = new Day() { Id = 2, Value = Days.Martes };

            lInterval1.AddDay(lDay1);
            lInterval1.AddDay(lDay2);
            lInterval2.AddDay(lDay3);
            lInterval2.AddDay(lDay1);

            TimeSpan time1 = new TimeSpan(8, 0, 0);
            TimeSpan time2 = new TimeSpan(10, 0, 0);
            TimeSpan time3 = new TimeSpan(12, 0, 0);
            TimeSpan time4 = new TimeSpan(14, 0, 0);

            TimeInterval lTimeInterval1 = new TimeInterval() { End = time3, Start = time1 }; //8 a 12
            TimeInterval lTimeInterval2 = new TimeInterval() { End = time3, Start = time2 };//10 a 12
            TimeInterval lTimeInterval3 = new TimeInterval() { End = time4, Start = time3 };//12 a 14

            lInterval1.AddTimeInterval(lTimeInterval1);
            lInterval1.AddTimeInterval(lTimeInterval3);
            lInterval2.AddTimeInterval(lTimeInterval2);

            bool lResult = lInterval1.IntersectsWith(lInterval2);

            Assert.IsTrue(lResult);
        }

        /*[TestMethod]
          public void OverlapsWith_NoDateOverlaping_FirstLapseBeforeSecondLapse()
          {
              // Arrange
            //  bool lResult;
              DateTime lStartDate1 = new DateTime(1993, 12, 25);
              DateTime lStartDate2 = new DateTime(1994, 01, 15);
              DateTime lEndDate1 = new DateTime(1993, 12, 31);
              DateTime lEndDate2 = new DateTime(1994, 01, 01);
              TimeSpan lStartTime1 = new TimeSpan(17, 00, 00);
              TimeSpan lStartTime2 = new TimeSpan(21, 00, 00);
              TimeSpan lEndTime1 = new TimeSpan(23, 59, 00);
              TimeSpan lEndTime2 = new TimeSpan(22, 00, 00);
              List<Days> lWeekDays1 = new List<Days>() { Days.Domingo };
              List<Days> lWeekDays2 = new List<Days>() { Days.Lunes };

              DateInterval lLapse1 = new DateInterval()
              {
                  ActiveFrom = lStartDate1,
                  ActiveUntil = lEndDate1,
                  //StartTime = lStartTime1,
                  //EndTime = lEndTime1,
                  DiasDeLaSemana = lWeekDays1
              };

              DateInterval lLapse2 = new DateInterval()
              {
                  ActiveFrom = lStartDate2,
                  ActiveUntil = lEndDate2,
                  //StartTime = lStartTime2,
                  //EndTime = lEndTime2,
                  DiasDeLaSemana = lWeekDays2
              };

              //Act
              //lResult = lLapse1.OverlapsWith(lLapse2);

              //Assert
              //Assert.IsFalse(lResult);
          }

          [TestMethod]
          public void OverlapsWith_NoDateOverlaping_FirstLapseAfterSecondLapse()
          {
              // Arrange
            //  bool lResult;
              DateTime lStartDate1 = new DateTime(2000, 12, 25);
              DateTime lStartDate2 = new DateTime(1994, 01, 15);
              DateTime lEndDate1 = new DateTime(2000, 12, 31);
              DateTime lEndDate2 = new DateTime(1994, 01, 01);
              TimeSpan lStartTime1 = new TimeSpan(17, 00, 00);
              TimeSpan lStartTime2 = new TimeSpan(21, 00, 00);
              TimeSpan lEndTime1 = new TimeSpan(23, 59, 00);
              TimeSpan lEndTime2 = new TimeSpan(22, 00, 00);
              List<Days> lWeekDays1 = new List<Days>() { Days.Domingo };
              List<Days> lWeekDays2 = new List<Days>() { Days.Lunes };

              DateInterval lLapse1 = new DateInterval()
              {
                  ActiveFrom = lStartDate1,
                  ActiveUntil = lEndDate1,
                //  StartTime = lStartTime1,
                  //EndTime = lEndTime1,
                  DiasDeLaSemana = lWeekDays1
              };

              DateInterval lLapse2 = new DateInterval()
              {
                  ActiveFrom = lStartDate2,
                  ActiveUntil = lEndDate2,
                  //StartTime = lStartTime2,
                  //EndTime = lEndTime2,
                  DiasDeLaSemana = lWeekDays2
              };

              //Act
              //lResult = lLapse1.OverlapsWith(lLapse2);

              //Assert
              //Assert.IsFalse(lResult);
          }

          [TestMethod]
          public void OverlapsWith_NoTimelaping()
          {
          }

          [TestMethod]
          public void OverlapsWith_Overlaping()
          {
          }*/
    }
}
