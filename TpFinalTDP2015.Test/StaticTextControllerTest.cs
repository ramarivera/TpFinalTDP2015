using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TpFinalTDP2015.Service;
using TpFinalTDP2015.Service.Controllers;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Service.Enum;

namespace TpFinalTDP2015.Test
{
	[TestClass]
	public class StaticTextControllerTest
	{
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            // AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"Test.config");
            AutoMapperConfiguration.Configure();
        }

        StaticTextController Controller
        {
            get
            {
                return (StaticTextController)
                    ControllerFactory.
                    GetController<StaticTextDTO>();
            }
        }

        void AssertAreEqual(StaticTextDTO lDto, StaticTextDTO lResult)
        {
            Assert.AreEqual(lDto.Id, lResult.Id);
            Assert.AreEqual(lDto.Title, lResult.Title);
            Assert.AreEqual(lDto.Description, lResult.Description);
            Assert.AreEqual(lDto.Text, lResult.Text);
        }

        [TestMethod]
        public void StaticTextController_NewText()
        {
            // Arrange
            string lTitle = "Confidencial";
            string lDescription = "Información super secreta";
            string lText = "Siempre que llovió, paró";

            StaticTextController lController = this.Controller;
            StaticTextDTO lResult;
            StaticTextDTO lDto;


            // Act
            lDto = new StaticTextDTO()
            {
                Title = lTitle,
                Description = lDescription,
                Text = lText
            };

            lDto.Id = lController.Save(lDto);

            // Assert
            lResult = lController.Get(lDto.Id);
            AssertAreEqual(lDto, lResult);
        }

        [TestMethod]
        public void StaticTextController_TitleModify()
        {
            // Arrange
            int lId = 1;
            string lTitle = "Texto 100";

            StaticTextController lController = this.Controller;
            StaticTextDTO lResult;
            StaticTextDTO lDto;

            // Act
            lDto = lController.Get(lId);
            lDto.Title = lTitle;
            lController.Save(lDto);

            // Assert
            lResult = lController.Get(lId);
            this.AssertAreEqual(lDto, lResult);
        }

        [TestMethod]
        public void StaticTextController_DescriptionModify()
        {
            // Arrange
            int lId = 1;
            string lDescription = "vamo a calmarno";

            StaticTextController lController = this.Controller;
            StaticTextDTO lResult;
            StaticTextDTO lDto;

            // Act
            lDto = lController.Get(lId);
            lDto.Description = lDescription;
            lController.Save(lDto);

            // Assert
            lResult = lController.Get(lId);
            this.AssertAreEqual(lDto, lResult);
        }

        [TestMethod]
        public void StaticTextController_TextModify()
        {
            // Arrange
            int lId = 1;
            string lText = "Aguante todo";

            StaticTextController lController = this.Controller;
            StaticTextDTO lResult;
            StaticTextDTO lDto;

            // Act
            lDto = lController.Get(lId);
            lDto.Text = lText;
            lController.Save(lDto);

            // Assert
            lResult = lController.Get(lId);
            this.AssertAreEqual(lDto, lResult);
        }

        public void StaticTextController_DeleteText()
        {
            // Arrange
            int lId = 1;

            StaticTextController lController = this.Controller;
            StaticTextDTO lRemoved;
            StaticTextDTO lDto;

            // Act
            lDto = lController.Get(lId);
            lController.Delete(lDto);

            // Assert
            lRemoved = lController.Get(lId);
            Assert.IsNull(lRemoved);
        }
    }
}
