using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TpFinalTDP2015.Persistence.Model;

namespace TpFinalTDP2015.Test
{
    [TestClass]
    public class IntervaloAplicacionTest
    {
        [TestMethod]
        public void OverlapsWith_NoDateOverlaping_FirstLapseBeforeSecondLapse()
        {
            // Arrange
            bool lResult;
            DateTime lStartDate1 = new DateTime(1993, 12, 25);
            DateTime lStartDate2 = new DateTime(1994, 01, 15);
            DateTime lEndDate1 = new DateTime(1993, 12, 31);
            DateTime lEndDate2 = new DateTime(1994, 01, 01);
            TimeSpan lStartTime1 = new TimeSpan(17, 00, 00);
            TimeSpan lStartTime2 = new TimeSpan(21, 00, 00);
            TimeSpan lEndTime1 = new TimeSpan(23, 59, 00);
            TimeSpan lEndTime2 = new TimeSpan(22, 00, 00);
            List<Dia> lWeekDays1 = new List<Dia>() { Dia.Domingo };
            List<Dia> lWeekDays2 = new List<Dia>() { Dia.Lunes };

            CampaignInterval lLapse1 = new CampaignInterval()
            {
                StartDate = lStartDate1,
                EndDate = lEndDate1,
                StartTime = lStartTime1,
                EndTime = lEndTime1,
                DiasDeLaSemana = lWeekDays1
            };

            CampaignInterval lLapse2 = new CampaignInterval()
            {
                StartDate = lStartDate2,
                EndDate = lEndDate2,
                StartTime = lStartTime2,
                EndTime = lEndTime2,
                DiasDeLaSemana = lWeekDays2
            };

            //Act
            lResult = lLapse1.OverlapsWith(lLapse2);

            //Assert
            Assert.IsFalse(lResult);
        }

        [TestMethod]
        public void OverlapsWith_NoDateOverlaping_FirstLapseAfterSecondLapse()
        {
            // Arrange
            bool lResult;
            DateTime lStartDate1 = new DateTime(2000, 12, 25);
            DateTime lStartDate2 = new DateTime(1994, 01, 15);
            DateTime lEndDate1 = new DateTime(2000, 12, 31);
            DateTime lEndDate2 = new DateTime(1994, 01, 01);
            TimeSpan lStartTime1 = new TimeSpan(17, 00, 00);
            TimeSpan lStartTime2 = new TimeSpan(21, 00, 00);
            TimeSpan lEndTime1 = new TimeSpan(23, 59, 00);
            TimeSpan lEndTime2 = new TimeSpan(22, 00, 00);
            List<Dia> lWeekDays1 = new List<Dia>() { Dia.Domingo };
            List<Dia> lWeekDays2 = new List<Dia>() { Dia.Lunes };

            CampaignInterval lLapse1 = new CampaignInterval()
            {
                StartDate = lStartDate1,
                EndDate = lEndDate1,
                StartTime = lStartTime1,
                EndTime = lEndTime1,
                DiasDeLaSemana = lWeekDays1
            };

            CampaignInterval lLapse2 = new CampaignInterval()
            {
                StartDate = lStartDate2,
                EndDate = lEndDate2,
                StartTime = lStartTime2,
                EndTime = lEndTime2,
                DiasDeLaSemana = lWeekDays2
            };

            //Act
            lResult = lLapse1.OverlapsWith(lLapse2);

            //Assert
            Assert.IsFalse(lResult);
        }

        [TestMethod]
        public void OverlapsWith_NoTimelaping()
        {
        }

        [TestMethod]
        public void OverlapsWith_Overlaping()
        {
        }
    }
}
