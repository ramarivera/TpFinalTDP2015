using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarrSystems.TpFinalTDP2015.BusinessLogic;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;

namespace MarrSystems.TpFinalTDP2015.Test
{
    [TestClass]
    public class RssSourceServiceTest
    {
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            // AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"Test.config");
            AutoMapperConfiguration.Configure();
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

            ManageSourceHandler lController = new ManageSourceHandler();
            RssSourceDTO lResult;
            RssSourceDTO lDto;


            // Act
            lDto = new RssSourceDTO()
            {
                Title = lTitle,
                Description = lDescription,
                URL = lURL
            };

            lDto.Id = lController.AddSource(lDto);

            // Assert
            lResult = lController.GetSource(lDto.Id);
            AssertAreEqual(lDto, lResult);
        }

        [TestMethod]
        public void RssSourceController_TitleModify()
        {
            // Arrange
            int lId = 1;
            string lTitle = "Muchas noticias";

            ManageSourceHandler lController = new ManageSourceHandler();
            RssSourceDTO lResult;
            RssSourceDTO lDto;

            // Act
            lDto = lController.GetSource(lId);
            lDto.Title = lTitle;
            lController.ModifySource(lDto);

            // Assert
            lResult = lController.GetSource(lId);
            this.AssertAreEqual(lDto, lResult);
        }

        [TestMethod]
        public void RssSourceController_DescriptionModify()
        {
            // Arrange
            int lId = 1;
            string lDescription = "Noticias políticas, fuente Todo Noticias";

            ManageSourceHandler lController = new ManageSourceHandler();
            RssSourceDTO lResult;
            RssSourceDTO lDto;

            // Act
            lDto = lController.GetSource(lId);
            lDto.Description = lDescription;
            lController.ModifySource(lDto);

            // Assert
            lResult = lController.GetSource(lId);
            this.AssertAreEqual(lDto, lResult);
        }

        [TestMethod]
        public void RssSourceController_URLModify()
        {
            // Arrange
            int lId = 1;
            string lURL = "http://tn.com.ar/rss.xml";

            ManageSourceHandler lController = new ManageSourceHandler();
            RssSourceDTO lResult;
            RssSourceDTO lDto;

            // Act
            lDto = lController.GetSource(lId);
            lDto.URL = lURL;
            lController.ModifySource(lDto);

            // Assert
            lResult = lController.GetSource(lId);
            this.AssertAreEqual(lDto, lResult);
        }


        [TestMethod]
        public void RssSourceController_DeleteSource()
        {
            // Arrange
            int lId = 1;

            ManageSourceHandler lController = new ManageSourceHandler();
            RssSourceDTO lRemoved;
            RssSourceDTO lDto;

            // Act
            lDto = lController.GetSource(lId);
            lController.DeleteSource(lDto);

            // Assert
            lRemoved = lController.GetSource(lId);
            Assert.IsNull(lRemoved);
        }
    }
}
