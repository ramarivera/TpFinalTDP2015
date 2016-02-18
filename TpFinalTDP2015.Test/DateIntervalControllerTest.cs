using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TpFinalTDP2015.Service;
using TpFinalTDP2015.Service.Controllers;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Service.Enum;

namespace TpFinalTDP2015.Test
{
    [TestClass]
    public class DateIntervalControllerTest
    {

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
          //  AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"Test.config");
            AutoMapperConfiguration.Configure();
        }

        public void BaseAssertAreEqual(DateIntervalDTO lDto,DateIntervalDTO lResult)
        {
            Assert.AreEqual(lDto.Name, lResult.Name);
            Assert.AreEqual(lDto.ActiveFrom, lResult.ActiveFrom);
            Assert.AreEqual(lDto.ActiveUntil, lResult.ActiveUntil);
            Assert.AreEqual(lDto.Days.Count, lResult.Days.Count);
            int i = 0; int j = 0;
            while ((i < lDto.Days.Count) && (j < lResult.Days.Count))
            {
                Assert.AreEqual(lDto.Days[i], lResult.Days[j]);
                i++; j++;
            }
        }

        public void AssertAreEqualForAdding(DateIntervalDTO lDto,DateIntervalDTO lResult)
        {
            int i = 0; int j = 0;
            while ((i < lDto.ActiveHours.Count) && (j < lResult.ActiveHours.Count))
            {
                Assert.AreEqual(lDto.ActiveHours[i].StartTime, lResult.ActiveHours[j].StartTime);
                Assert.AreEqual(lDto.ActiveHours[i].EndTime, lResult.ActiveHours[j].EndTime);
                i++; j++;
            }
        }

        public void AssertAreEqualForUpdating(DateIntervalDTO lDto, DateIntervalDTO lResult)
        {
            int i = 0; int j = 0;
            while ((i < lDto.ActiveHours.Count) && (j < lResult.ActiveHours.Count))
            {
                Assert.AreEqual(lDto.Id, lResult.Id);
                Assert.AreEqual(lDto.CreationDate, lResult.CreationDate);
                Assert.AreEqual(lDto.ActiveHours[i].StartTime, lResult.ActiveHours[j].StartTime);
                Assert.AreEqual(lDto.ActiveHours[i].EndTime, lResult.ActiveHours[j].EndTime);
                i++; j++;
            }
        }

        [TestMethod]
        public void DateIntervalController_NewInterval()
        {
            DateIntervalController lController = (DateIntervalController)ControllerFactory.Instance.GetController<DateIntervalDTO>();

            DateIntervalDTO lDto = new DateIntervalDTO();

            lDto.ActiveFrom = new DateTime(2016, 02, 01);
            lDto.ActiveUntil = new DateTime(2016, 02, 29);

            lDto.Days.Add(Days.Lunes);
            lDto.Days.Add(Days.Miercoles);
            lDto.Days.Add(Days.Viernes);

            lDto.Name = "Crece desde el pie";

            lDto.ActiveHours.Add(new TimeIntervalDTO()
            {
                EndTime = new TimeSpan(10, 0, 0),
                StartTime = new TimeSpan(08, 0, 0)
            });

            lController.Save(lDto);


        }
        [TestMethod]
        public void DateIntervalController_DateModify()
        {
            DateIntervalController lController = (DateIntervalController)ControllerFactory.Instance.GetController<DateIntervalDTO>();

            IList<DateIntervalDTO> lList = lController.GetAll();

            DateIntervalDTO lDto = lList.Where(dto => dto.Id == 1).FirstOrDefault();

            lDto.ActiveFrom = new DateTime(2016, 03, 01);

            lController.Save(lDto);

            lList = lController.GetAll();
            DateIntervalDTO lResult = lList.Where(dto => dto.Id == 1).FirstOrDefault();

            this.BaseAssertAreEqual(lDto, lResult);
            this.AssertAreEqualForUpdating(lDto, lResult);
            
        }

        [TestMethod]
        public void DateIntervalController_DaysModify()
        {
            DateIntervalController lController = (DateIntervalController)ControllerFactory.Instance.GetController<DateIntervalDTO>();

            IList<DateIntervalDTO> lList = lController.GetAll();

            DateIntervalDTO lDto = lList.Where(dto => dto.Id == 1).FirstOrDefault();

            lDto.Days.Clear();

            lDto.Days.Add(Days.Lunes);
            lDto.Days.Add(Days.Martes);
            lDto.Days.Add(Days.Jueves);

            lController.Save(lDto);

            lList = lController.GetAll();
            DateIntervalDTO lResult = lList.Where(dto => dto.Id == 1).FirstOrDefault();

            this.BaseAssertAreEqual(lDto, lResult);
            this.AssertAreEqualForUpdating(lDto, lResult);
        }

        [TestMethod]
        public void DateIntervalController_TimeIntervalAdd()
        {
            DateIntervalController lController = (DateIntervalController)ControllerFactory.Instance.GetController<DateIntervalDTO>();

            IList<DateIntervalDTO> lList = lController.GetAll();

            DateIntervalDTO lDto = lList.Where(dto => dto.Id == 1).FirstOrDefault();

            lDto.Name = "Lunes a Viernes, 08am a 12pm y 08pm a 10pm";

            lDto.ActiveHours.Add(new TimeIntervalDTO()
            {
                EndTime = new TimeSpan(22, 0, 0),
                StartTime = new TimeSpan(20, 0, 0)
            });

            lController.Save(lDto);

            lList = lController.GetAll();
            DateIntervalDTO lResult = lList.Where(dto => dto.Id == 1).FirstOrDefault();

            this.BaseAssertAreEqual(lDto, lResult);
            this.AssertAreEqualForAdding(lDto, lResult);
        }

        [TestMethod]
        public void DateIntervalController_TimeIntervalModify()
        {
            DateIntervalController lController = (DateIntervalController)ControllerFactory.Instance.GetController<DateIntervalDTO>();

            IList<DateIntervalDTO> lList = lController.GetAll();

            DateIntervalDTO lDto = lList.Where(dto => dto.Id == 1).FirstOrDefault();

            lDto.Name = "Lunes a Viernes, 08am a 13pm";

            var timeInterval = lDto.ActiveHours.Where(ti => ti.EndTime.Hours == 19).Single();
            timeInterval.EndTime = new TimeSpan(20, 0, 0);

            lController.Save(lDto);

            lList = lController.GetAll();
            DateIntervalDTO lResult = lList.Where(dto => dto.Id == 1).FirstOrDefault();

            this.BaseAssertAreEqual(lDto, lResult);
            this.AssertAreEqualForUpdating(lDto, lResult);
        }

        [TestMethod]
        public void DateIntervalController_TimeIntervalDelete()
        {
            DateIntervalController lController = (DateIntervalController)ControllerFactory.Instance.GetController<DateIntervalDTO>();

            IList<DateIntervalDTO> lList = lController.GetAll();

            DateIntervalDTO lDto = lList.Where(dto => dto.Id == 1).FirstOrDefault();

            lDto.ActiveHours.Remove(lDto.ActiveHours.Where(ti => ti.EndTime.Hours == 1).Single());

            lController.Save(lDto);

            lList = lController.GetAll();
            DateIntervalDTO lResult = lList.Where(dto => dto.Id == 1).FirstOrDefault();
            TimeIntervalDTO lRemoved = lResult.ActiveHours.Where(ti => ti.EndTime.Hours == 1).FirstOrDefault();

            Assert.IsNull(lRemoved);
 
        }

        [TestMethod]
        public void DateIntervalController_DeleteInterval()
        {
            DateIntervalController lController = (DateIntervalController)ControllerFactory.Instance.GetController<DateIntervalDTO>();

            IList<DateIntervalDTO> lList = lController.GetAll();

            DateIntervalDTO lDto = lList.Where(dto => dto.Id == 1).FirstOrDefault();

            lController.Delete(lDto);

            DateIntervalDTO lRemoved = lList.Where(dto => dto.Id == 1).FirstOrDefault();

            Assert.IsNull(lRemoved);
        }

      /*  [TestMethod]
        public void Save()
        {
            DateIntervalController lController = new DateIntervalController();

            IList<DateIntervalDTO> lList = lController.GetDateIntervals();

            DateIntervalDTO lDto = lList.Where(dto => dto.Id == 3).FirstOrDefault();

            lDto.Days.Clear();

            lDto.Days.Add(Days.Domingo);
            lDto.Days.Add(Days.Lunes);
            lDto.Days.Add(Days.Martes);
            lDto.Days.Add(Days.Miercoles);
            lDto.Days.Add(Days.Jueves);
            lDto.Days.Add(Days.Viernes);

            lDto.Name = "xDD";

            var tii = lDto.ActiveHours.Where(ti => ti.Id == 22).Single();
            tii.EndTime = new TimeSpan(13, 0, 0);
            // tii.CreationDate = new DateTime(2050, 07, 11, 12, 0, 0);
            lDto.ActiveHours.Remove(lDto.ActiveHours.Where(ti => ti.Id == 23).Single());
            lDto.ActiveHours.Add(new TimeIntervalDTO()
            {
                EndTime = new TimeSpan(17, 0, 0),
                StartTime = new TimeSpan(13, 0, 0)
            });

            // lDto.Id = 0;

            lController.SaveDateInterval(lDto);

            Assert.IsTrue(true);

        }

        [TestMethod]
        public void Test2()
        {
            Assert.IsTrue(true);
         */

    }


}
