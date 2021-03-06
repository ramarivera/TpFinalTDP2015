﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.CrossCutting.Enum;
using MarrSystems.TpFinalTDP2015.BusinessLogic;
using System.Collections.Generic;
using MarrSystems.TpFinalTDP2015.Model;
using AutoMapper;

namespace MarrSystems.TpFinalTDP2015.Test
{
    [TestClass]
    public class BannerServiceTest
    {

        private void AssertAreEqualBase(AdminBannerDTO lDto, AdminBannerDTO lResult)
        {
            Assert.AreEqual(lDto.Id, lResult.Id);
            Assert.AreEqual(lDto.Name, lResult.Name);
            Assert.AreEqual(lDto.Description, lResult.Description);

            Assert.AreEqual(lDto.RssSources.Count, lResult.RssSources.Count);
            Assert.AreEqual(lDto.Texts.Count, lResult.Texts.Count);
            Assert.AreEqual(lDto.ActiveIntervals.Count, lResult.ActiveIntervals.Count);

            int i = 0;
            int j = 0;

            while ((i < lDto.RssSources.Count) && (j < lResult.RssSources.Count))
            {
                //Assert.AreEqual(lDto.RssSources[i].Id, lResult.RssSources[i].Id);
                Assert.AreEqual(lDto.RssSources[i].Title, lResult.RssSources[i].Title);
                Assert.AreEqual(lDto.RssSources[i].URL, lResult.RssSources[i].URL);
                Assert.AreEqual(lDto.RssSources[i].Description, lResult.RssSources[i].Description);

                i++;
                j++;
            }

            i = 0; j = 0;
            while ((i < lDto.Texts.Count) && (j < lResult.Texts.Count))
            {
               // Assert.AreEqual(lDto.Texts[i].Id, lResult.Texts[i].Id);
                Assert.AreEqual(lDto.Texts[i].Title, lResult.Texts[i].Title);
                Assert.AreEqual(lDto.Texts[i].Text, lResult.Texts[i].Text);
                Assert.AreEqual(lDto.Texts[i].Description, lResult.Texts[i].Description);

                i++;
                j++;
            }

            i = 0; j = 0;
            while ((i < lDto.ActiveIntervals.Count) && (j < lResult.ActiveIntervals.Count))
            {
              //  Assert.AreEqual(lDto.ActiveIntervals[i].Id, lResult.ActiveIntervals[j].Id);
                Assert.AreEqual(lDto.ActiveIntervals[i].Name, lResult.ActiveIntervals[j].Name);
              //  Assert.AreEqual(lDto.ActiveIntervals[i].CreationDate, lResult.ActiveIntervals[j].CreationDate);
                Assert.AreEqual(lDto.ActiveIntervals[i].ActiveFrom, lResult.ActiveIntervals[j].ActiveFrom);
                Assert.AreEqual(lDto.ActiveIntervals[i].ActiveUntil, lResult.ActiveIntervals[j].ActiveUntil);

                Assert.AreEqual(lDto.ActiveIntervals[i].Days.Count, lResult.ActiveIntervals[j].Days.Count);
                Assert.AreEqual(lDto.ActiveIntervals[i].ActiveHours.Count, lResult.ActiveIntervals[j].ActiveHours.Count);

                int k = 0; int l = 0;
                while ((k < lDto.ActiveIntervals[i].Days.Count) && (l < lResult.ActiveIntervals[j].Days.Count))
                {
                    Assert.AreEqual(lDto.ActiveIntervals[i].Days[k], lResult.ActiveIntervals[j].Days[l]);
                    k++;l++;
                }

                k = 0; l = 0;
                while ((k < lDto.ActiveIntervals[i].ActiveHours.Count) && (l < lResult.ActiveIntervals[j].ActiveHours.Count))
                {
                //    Assert.AreEqual(lDto.ActiveIntervals[k].ActiveHours[i].Id, lResult.ActiveIntervals[j].ActiveHours[l].Id);
                 //   Assert.AreEqual(lDto.ActiveIntervals[k].ActiveHours[i].CreationDate, lResult.ActiveIntervals[j].ActiveHours[l].CreationDate);
                    Assert.AreEqual(lDto.ActiveIntervals[i].ActiveHours[k].StartTime, lResult.ActiveIntervals[j].ActiveHours[l].StartTime);
                    Assert.AreEqual(lDto.ActiveIntervals[i].ActiveHours[k].EndTime, lResult.ActiveIntervals[j].ActiveHours[l].EndTime);
                    k++; l++;
                }

                i++;
                j++;
            }

        }

        private void AssertAreEqual(AdminBannerDTO lDto, AdminBannerDTO lResult)
        {
            AssertAreEqualBase(lDto, lResult);

        }

        [TestMethod]
        public void Save_AddingNewBanner_ReturnsBannerId()
        {
            // Arrange
            int lDiId = 1;
            int lStid = 1;
            int lRssId = 1;
            string lBannerName = "Cosas varias";
            string lBannerDescription = "Distintas informaciones durante la mañana";


           IService<Banner> lController = BusinessServiceLocator.Resolve<BannerService>();
            IService<StaticText> lStController = BusinessServiceLocator.Resolve<StaticTextService>();
            IService<Schedule> lDiController = BusinessServiceLocator.Resolve<ScheduleService>();
            IService<RssSource> lRssController = BusinessServiceLocator.Resolve<RssSourceService>();


            AdminBannerDTO lResult;
            ScheduleDTO lDiDto;
            StaticTextDTO lStDto;
            RssSourceDTO lRssDto;

            // Act
            lDiDto =  Mapper.Map<Schedule,ScheduleDTO>(lDiController.Get(lDiId));
            lRssDto = Mapper.Map<RssSource,RssSourceDTO>(lRssController.Get(lRssId));
            lStDto =  Mapper.Map<StaticText,StaticTextDTO>(lStController.Get(lStid));



            AdminBannerDTO lDto = new AdminBannerDTO()
            {
                Name = lBannerName,
                Description = lBannerDescription,
                RssSources = new List<RssSourceDTO>()
                {
                    lRssDto
                },
                ActiveIntervals = new List<ScheduleDTO>()
                {
                    lDiDto
                },
                Texts = new List<StaticTextDTO>()
                {
                    lStDto
                }
            };

            lDto.Id = lController.Save(Mapper.Map<AdminBannerDTO, Banner>(  lDto));

            // Assert
            lResult = Mapper.Map<Banner, AdminBannerDTO> (lController.Get(lDto.Id));
            AssertAreEqual(lDto, lResult);

        }

        // TODO hacer un test que agregue todo, les haga get de cada cosa y lo agrege todo al dto principal
        /*
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            int lId;
            string lBannerName = "Cosas varias";
            string lBannerDescription = "Distintas informaciones durante la mañana";
            string lDiName = "Crece desde el pie";
            string lStTitle = "Palabras que te abriran muchas puertas";
            string lStDescription = "Autoayuda diaria";
            string lStText = "Tire y empuje";
            string lRssTitle = "Noticias de futbol ESPN";
            string lRssDescription = "Noticias del ámbito futbolistico, siendo su fuente ESPN (en inglés)";
            string lRssURL = "http://soccernet.espn.go.com/rss/news";

            DateTime lStart = new DateTime(2016, 02, 01);
            DateTime lEnd = new DateTime(2016, 02, 29);
            TimeSpan lEndTime = new TimeSpan(10, 0, 0);
            TimeSpan lStartTime = new TimeSpan(08, 0, 0);

            IList<Days> lDayList = new List<Days>() { Days.Lunes, Days.Miercoles, Days.Viernes };

            BannerController lController = this.Controller;
            AdminBannerDTO lResult;

            ScheduleEntryDTO lTiDto = new ScheduleEntryDTO()
            {
                EndTime = lEndTime,
                StartTime = lStartTime,
            };

            ScheduleDTO lDiDto = new ScheduleDTO()
            {
                Name = lDiName,
                Days = lDayList,
                ActiveUntil = lEnd,
                ActiveFrom = lStart,
                ActiveHours = new List<ScheduleEntryDTO>()
                {
                    lTiDto
                }
            };

            StaticTextDTO lStDto = new StaticTextDTO()
            {
                Title = lStTitle,
                Text = lStText,
                Description = lStDescription
            };

            RssSourceDTO lRssDto = new RssSourceDTO()
            {
                Title = lRssTitle,
                URL = lRssURL,
                Description = lRssDescription
            };

            AdminBannerDTO lDto = new AdminBannerDTO()
            {
                Name = lBannerName,
                Description = lBannerDescription,
                RssSources = new List<RssSourceDTO>()
                {
                    lRssDto
                },
                ActiveIntervals = new List<ScheduleDTO>()
                {
                    lDiDto
                },
                Texts = new List<StaticTextDTO>()
                {
                    lStDto
                }
            };

            // Act
            lDto.Id = lController.Save(lDto);

            // Assert
            lResult = lController.Get(lDto.Id);
            AssertAreEqual(lDto, lResult);
        } */
    }
}
