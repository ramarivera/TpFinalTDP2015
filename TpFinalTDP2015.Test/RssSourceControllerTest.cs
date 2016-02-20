using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TpFinalTDP2015.Service;
using TpFinalTDP2015.Service.Controllers;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.Test
{
    [TestClass]
    public class RssSourceControllerTest
    {
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            // AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"Test.config");
            AutoMapperConfiguration.Configure();
        }

        RssSourceController Controller
        {
            get
            {
                return (RssSourceController)
                    ControllerFactory.
                    GetController<RssSourceDTO>();
            }
        }

        void AssertAreEqual(RssSourceDTO lDto, RssSourceDTO lResult)
        {
            Assert.AreEqual(lDto.Id, lResult.Id);
            Assert.AreEqual(lDto.Title, lResult.Title);
            Assert.AreEqual(lDto.Description, lResult.Description);
            Assert.AreEqual(lDto.URL, lResult.URL);
        }

        [TestMethod]
        public void RssSourceController_NewSource()
        {
            // Arrange
            string lTitle = "Noticias de futbol ESPN";
            string lDescription = "Noticias del ámbito futbolistico, siendo su fuente ESPN (en inglés)";
            string lURL = "http://soccernet.espn.go.com/rss/news";

            RssSourceController lController = this.Controller;
            RssSourceDTO lResult;
            RssSourceDTO lDto;


            // Act
            lDto = new RssSourceDTO()
            {
                Title = lTitle,
                Description = lDescription,
                URL = lURL
            };

            lDto.Id = lController.Save(lDto);

            // Assert
            lResult = lController.Get(lDto.Id);
            AssertAreEqual(lDto, lResult);
        }

        [TestMethod]
        public void RssSourceController_TitleModify()
        {
            // Arrange
            int lId = 1;
            string lTitle = "Muchas noticias";

            RssSourceController lController = this.Controller;
            RssSourceDTO lResult;
            RssSourceDTO lDto;

            // Act
            lDto = lController.Get(lId);
            lDto.Title = lTitle;
            lController.Save(lDto);

            // Assert
            lResult = lController.Get(lId);
            this.AssertAreEqual(lDto, lResult);
        }

        [TestMethod]
        public void RssSourceController_DescriptionModify()
        {
            // Arrange
            int lId = 1;
            string lDescription = "Noticias políticas, fuente Todo Noticias";

            RssSourceController lController = this.Controller;
            RssSourceDTO lResult;
            RssSourceDTO lDto;

            // Act
            lDto = lController.Get(lId);
            lDto.Description = lDescription;
            lController.Save(lDto);

            // Assert
            lResult = lController.Get(lId);
            this.AssertAreEqual(lDto, lResult);
        }

        [TestMethod]
        public void RssSourceController_URLModify()
        {
            // Arrange
            int lId = 1;
            string lURL = "http://tn.com.ar/rss.xml";

            RssSourceController lController = this.Controller;
            RssSourceDTO lResult;
            RssSourceDTO lDto;

            // Act
            lDto = lController.Get(lId);
            lDto.URL = lURL;
            lController.Save(lDto);

            // Assert
            lResult = lController.Get(lId);
            this.AssertAreEqual(lDto, lResult);
        }


        [TestMethod]
        public void RssSourceController_DeleteSource()
        {
            // Arrange
            int lId = 1;

            RssSourceController lController = this.Controller;
            RssSourceDTO lRemoved;
            RssSourceDTO lDto;

            // Act
            lDto = lController.Get(lId);
            lController.Delete(lDto);

            // Assert
            lRemoved = lController.Get(lId);
            Assert.IsNull(lRemoved);
        }
    }
}
