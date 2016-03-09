using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;

namespace MarrSystems.TpFinalTDP2015.Test
{
    [TestClass]
    public class DateIntervalControllerTest
    {
        /// <summary>
        /// SACAR ESTO A LA MIERDA DE ACA!
        /// </summary>
        /// <param name="context"></param>
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            BootStrapper.Configure(); //TODO SACAR ESTO DE ACA LPM
        }

        void BaseAssertAreEqual(ScheduleDTO lDto, ScheduleDTO lResult)
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

        void AssertAreEqualForAdding(ScheduleDTO lDto, ScheduleDTO lResult)
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

        void AssertAreEqualForUpdating(ScheduleDTO lDto, ScheduleDTO lResult)
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

            ManageScheduleHandler lController = new ManageScheduleHandler();
            ScheduleDTO lResult;
            ScheduleDTO lDto;


            // Act
            lDto = new ScheduleDTO()
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
                ActiveHours = new List<ScheduleEntryDTO>()
                {
                    new ScheduleEntryDTO()
                    {
                        EndTime = lNewEndTime,
                        StartTime = lNewStartTime
                    }
                }
            };

            lDto.Id = lController.AddSchedule(lDto);

            // Assert
            lResult = lController.GetSchedule(lDto.Id);
            AssertAreEqualForAdding(lDto, lResult);

        }

        [TestMethod]
        public void DateIntervalController_DateModify()
        {
            // Arrange
            int lId = 1;
            DateTime lNewActiveFrom = new DateTime(2016, 03, 01);

            ManageScheduleHandler lController = new ManageScheduleHandler();
            ScheduleDTO lResult;
            ScheduleDTO lDto;

            // Act
            lDto = lController.GetSchedule(lId);
            lDto.ActiveFrom = lNewActiveFrom;
            lController.ModifySchedule(lDto);

            // Assert
            lResult = lController.GetSchedule(lId);
            this.AssertAreEqualForUpdating(lDto, lResult);
        }

        [TestMethod]
        public void DateIntervalController_DaysModify()
        {
            // Arrange
            int lId = 1;

            ManageScheduleHandler lController = new ManageScheduleHandler();
            ScheduleDTO lResult;
            ScheduleDTO lDto = lController.GetSchedule(lId);

            IList<Days> lDayList = new List<Days>() { Days.Lunes, Days.Martes, Days.Jueves };

            // Act
            lDto.Days = lDayList;
            lController.ModifySchedule(lDto);

            // Assert
            lResult = lController.GetSchedule(lId);
            this.AssertAreEqualForUpdating(lDto, lResult);
        }

        [TestMethod]
        public void DateIntervalController_TimeIntervalAdd()
        {
            // Arrange
            int lId = 1;
            TimeSpan lNewEnd = new TimeSpan(22, 0, 0);
            TimeSpan lNewStart = new TimeSpan(20, 0, 0);

            ManageScheduleHandler lController = new ManageScheduleHandler();
            ScheduleDTO lResult;
            ScheduleDTO lDto;
            ScheduleEntryDTO lNewTime;

            // Act
            lDto = lController.GetSchedule(lId);

            lNewTime = new ScheduleEntryDTO()
            {
                EndTime = lNewEnd,
                StartTime = lNewStart
            };

            lDto.ActiveHours.Add(lNewTime);
            lController.ModifySchedule(lDto);

            // Assert
            lResult = lController.GetSchedule(lId);
            this.AssertAreEqualForAdding(lDto, lResult);
        }

        [TestMethod]
        public void DateIntervalController_TimeIntervalModify()
        {
            // Arrange
            int lId = 1;
            int lTimeId = 19;
            TimeSpan lNewEnd = new TimeSpan(20, 0, 0);

            ManageScheduleHandler lController = new ManageScheduleHandler();
            //  var mock = new Mock<DateIntervalController>(IoCUnityContainerLocator.Container.Resolve<IUnitOfWork>());

            ScheduleDTO lDto;
            ScheduleDTO lResult;
            ScheduleEntryDTO lTimeInterval;

            // Act
            lDto = lController.GetSchedule(lId);
            lTimeInterval = lDto.ActiveHours.Where(ti => ti.EndTime.Hours == lTimeId).SingleOrDefault();
            lTimeInterval.EndTime = lNewEnd;
            lController.ModifySchedule(lDto);
           // mock.Object.Save(lDto);
           // mock.Verify(foo => foo.Save(It.IsAny<ScheduleDTO>()), Times.Never());
            

            // Assert
            lResult = lController.GetSchedule(lId);
            this.AssertAreEqualForUpdating(lDto, lResult);

        }

        [TestMethod]
        public void DateIntervalController_TimeIntervalDelete()
        {
            // Arrange
            int lId = 1;
            int lTimeId = 1;

            ManageScheduleHandler lController = new ManageScheduleHandler();
            ScheduleDTO lDto;
            ScheduleDTO lResult;
            ScheduleEntryDTO lTimeInterval;
            ScheduleEntryDTO lRemoved;

            // Act
            lDto = lController.GetSchedule(lId);
            lTimeInterval = lDto.ActiveHours.Where(ti => ti.EndTime.Hours == lTimeId).SingleOrDefault();
            lDto.ActiveHours.Remove(lTimeInterval);
            lController.ModifySchedule(lDto);

            // Assert
            lResult = lController.GetSchedule(lId);
            lRemoved = lResult.ActiveHours.Where(ti => ti.EndTime.Hours == lTimeId).SingleOrDefault();
            Assert.IsNull(lRemoved);
        }

        [TestMethod]
        public void DateIntervalController_DeleteInterval()
        {
            // Arrange
            int lId = 1;

            ManageScheduleHandler lController = new ManageScheduleHandler();
            ScheduleDTO lRemoved;
            ScheduleDTO lDto;

            // Act
            lDto = lController.GetSchedule(lId);
            lController.DeleteSchedule(lDto);

            // Assert
            lRemoved = lController.GetSchedule(lId);
            Assert.IsNull(lRemoved);
        }

    }
}
