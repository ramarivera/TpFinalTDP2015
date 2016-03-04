﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using MarrSystems.TpFinalTDP2015.Persistence;
using MarrSystems.TpFinalTDP2015.BusinessLogic;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.CrossCutting.Enum;
using Microsoft.Practices.Unity;

namespace MarrSystems.TpFinalTDP2015.Test
{
    [TestClass]
    public class DateIntervalControllerTest
    {
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            // AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"Test.config");
            AutoMapperConfiguration.Configure();
        }

        DateIntervalController Controller
        {
            get
            {
                return (DateIntervalController)
                    ServiceFactory.
                    GetService<DateIntervalDTO>();
            }
        }

        void BaseAssertAreEqual(DateIntervalDTO lDto, DateIntervalDTO lResult)
        {
            Assert.AreEqual(lDto.Id, lResult.Id);
            Assert.AreEqual(lDto.Name, lResult.Name);
            Assert.AreEqual(lDto.ActiveFrom, lResult.ActiveFrom);
            Assert.AreEqual(lDto.ActiveUntil, lResult.ActiveUntil);

            Assert.AreEqual(lDto.Days.Count, lResult.Days.Count);
            Assert.AreEqual(lDto.ActiveHours.Count, lResult.ActiveHours.Count);

            int i = 0; int j = 0;
            while ((i < lDto.Days.Count) && (j < lResult.Days.Count))
            {
                Assert.AreEqual(lDto.Days[i], lResult.Days[j]);
                i++; j++;
            }
        }

        void AssertAreEqualForAdding(DateIntervalDTO lDto, DateIntervalDTO lResult)
        {
            BaseAssertAreEqual(lDto, lResult);

            int i = 0; int j = 0;
            while ((i < lDto.ActiveHours.Count) && (j < lResult.ActiveHours.Count))
            {
                Assert.AreEqual(lDto.ActiveHours[i].StartTime, lResult.ActiveHours[j].StartTime);
                Assert.AreEqual(lDto.ActiveHours[i].EndTime, lResult.ActiveHours[j].EndTime);
                i++; j++;
            }
        }

        void AssertAreEqualForUpdating(DateIntervalDTO lDto, DateIntervalDTO lResult)
        {
            BaseAssertAreEqual(lDto, lResult);

            Assert.AreEqual(lDto.CreationDate, lResult.CreationDate);

            int i = 0; int j = 0;
            while ((i < lDto.ActiveHours.Count) && (j < lResult.ActiveHours.Count))
            {
                Assert.AreEqual(lDto.ActiveHours[i].StartTime, lResult.ActiveHours[j].StartTime);
                Assert.AreEqual(lDto.ActiveHours[i].EndTime, lResult.ActiveHours[j].EndTime);
                i++; j++;
            }
        }

        [TestMethod]
        public void DateIntervalController_NewInterval()
        {
            // Arrange
            string lNewName = "Crece desde el pie";
            DateTime lNewActiveFrom = new DateTime(2016, 02, 01);
            DateTime lNewActiveUntil = new DateTime(2016, 02, 29);
            TimeSpan lNewStartTime = new TimeSpan(08, 0, 0);
            TimeSpan lNewEndTime = new TimeSpan(10, 0, 0);

            DateIntervalController lController = this.Controller;
            DateIntervalDTO lResult;
            DateIntervalDTO lDto;


            // Act
            lDto = new DateIntervalDTO()
            {
                Name = lNewName,
                ActiveUntil = lNewActiveUntil,
                ActiveFrom = lNewActiveFrom,
                Days = new List<Days>()
                {
                    Days.Lunes,
                    Days.Miercoles,
                    Days.Viernes,
                },
                ActiveHours = new List<TimeIntervalDTO>()
                {
                    new TimeIntervalDTO()
                    {
                        EndTime = lNewEndTime,
                        StartTime = lNewStartTime
                    }
                }
            };

            lDto.Id = lController.Save(lDto);

            // Assert
            lResult = lController.Get(lDto.Id);
            AssertAreEqualForAdding(lDto, lResult);

        }

        [TestMethod]
        public void DateIntervalController_DateModify()
        {
            // Arrange
            int lId = 1;
            DateTime lNewActiveFrom = new DateTime(2016, 03, 01);

            DateIntervalController lController = this.Controller;
            DateIntervalDTO lResult;
            DateIntervalDTO lDto;

            // Act
            lDto = lController.Get(lId);
            lDto.ActiveFrom = lNewActiveFrom;
            lController.Save(lDto);

            // Assert
            lResult = lController.Get(lId);
            this.AssertAreEqualForUpdating(lDto, lResult);
        }

        [TestMethod]
        public void DateIntervalController_DaysModify()
        {
            // Arrange
            int lId = 1;
 
            DateIntervalController lController = this.Controller;
            DateIntervalDTO lResult;
            DateIntervalDTO lDto = lController.Get(lId);

            IList<Days> lDayList = new List<Days>() { Days.Lunes, Days.Martes, Days.Jueves };

            // Act
            lDto.Days = lDayList;
            lController.Save(lDto);

            // Assert
            lResult = lController.Get(lId);
            this.AssertAreEqualForUpdating(lDto, lResult);
        }

        [TestMethod]
        public void DateIntervalController_TimeIntervalAdd()
        {
            // Arrange
            int lId = 1;
            TimeSpan lNewEnd = new TimeSpan(22, 0, 0);
            TimeSpan lNewStart = new TimeSpan(20, 0, 0);

            DateIntervalController lController = this.Controller;
            DateIntervalDTO lResult;
            DateIntervalDTO lDto;
            TimeIntervalDTO lNewTime;

            // Act
            lDto = lController.Get(lId);

            lNewTime = new TimeIntervalDTO()
            {
                EndTime = lNewEnd,
                StartTime = lNewStart
            };

            lDto.ActiveHours.Add(lNewTime);
            lController.Save(lDto);

            // Assert
            lResult = lController.Get(lId);
            this.AssertAreEqualForAdding(lDto, lResult);
        }

        [TestMethod]
        public void DateIntervalController_TimeIntervalModify()
        {
            // Arrange
            int lId = 1;
            int lTimeId = 19;
            TimeSpan lNewEnd = new TimeSpan(20, 0, 0);

            DateIntervalController lController = this.Controller;
          //  var mock = new Mock<DateIntervalController>(IoCUnityContainerLocator.Container.Resolve<IUnitOfWork>());
            
            DateIntervalDTO lDto;
            DateIntervalDTO lResult;
            TimeIntervalDTO lTimeInterval;

            // Act
            lDto = lController.Get(lId);
            lTimeInterval = lDto.ActiveHours.Where(ti => ti.EndTime.Hours == lTimeId).SingleOrDefault();
            lTimeInterval.EndTime = lNewEnd;
            lController.Save(lDto);
           // mock.Object.Save(lDto);
           // mock.Verify(foo => foo.Save(It.IsAny<DateIntervalDTO>()), Times.Never());
            

            // Assert
            lResult = lController.Get(lId);
            this.AssertAreEqualForUpdating(lDto, lResult);

        }

        [TestMethod]
        public void DateIntervalController_TimeIntervalDelete()
        {
            // Arrange
            int lId = 1;
            int lTimeId = 1;

            DateIntervalController lController = this.Controller;
            DateIntervalDTO lDto;
            DateIntervalDTO lResult;
            TimeIntervalDTO lTimeInterval;
            TimeIntervalDTO lRemoved;

            // Act
            lDto = lController.Get(lId);
            lTimeInterval = lDto.ActiveHours.Where(ti => ti.EndTime.Hours == lTimeId).SingleOrDefault();
            lDto.ActiveHours.Remove(lTimeInterval);
            lController.Save(lDto);

            // Assert
            lResult = lController.Get(lId);
            lRemoved = lResult.ActiveHours.Where(ti => ti.EndTime.Hours == lTimeId).SingleOrDefault();
            Assert.IsNull(lRemoved);
        }

        [TestMethod]
        public void DateIntervalController_DeleteInterval()
        {
            // Arrange
            int lId = 1;

            DateIntervalController lController = this.Controller;
            DateIntervalDTO lRemoved;
            DateIntervalDTO lDto;

            // Act
            lDto = lController.Get(lId);
            lController.Delete(lDto);

            // Assert
            lRemoved = lController.Get(lId);
            Assert.IsNull(lRemoved);
        }

    }
}
