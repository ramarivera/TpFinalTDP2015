using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TpFinalTDP2015.Service.Controllers;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Service.Enum;
using TpFinalTDP2015.Service;
using System.Collections.Generic;

namespace TpFinalTDP2015.Test
{
    [TestClass]
    public class BannerControllerTest
    {

        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            // AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"Test.config");
            AutoMapperConfiguration.Configure();
        }

        BannerController Controller
        {
            get
            {
                return (BannerController)
                    ControllerFactory.
                    GetController<AdminBannerDTO>();
            }
        }

        private void AssertAreEqualForAdding(AdminBannerDTO lDto, AdminBannerDTO lResult)
        {
            throw new NotImplementedException();
        }

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

            IList<Days> lDayList = new List<Days>() {Days.Lunes, Days.Miercoles, Days.Viernes };

            BannerController lController = this.Controller;
            AdminBannerDTO lResult;

            TimeIntervalDTO lTiDto = new TimeIntervalDTO()
            {
                EndTime = lEndTime,
                StartTime = lStartTime,
            };

            DateIntervalDTO lDiDto = new DateIntervalDTO()
            {
                Name = lDiName,
                Days = lDayList,
                ActiveUntil = lEnd,
                ActiveFrom = lStart,
                ActiveHours = new List<TimeIntervalDTO>()
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
                ActiveIntervals = new List<DateIntervalDTO>()
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
            AssertAreEqualForAdding(lDto, lResult);
        }
    }
}
