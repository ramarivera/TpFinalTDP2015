using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarrSystems.TpFinalTDP2015.BusinessLogic;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic.UseCaseControllers;

namespace MarrSystems.TpFinalTDP2015.Test
{
	[TestClass]
	public class StaticTextServiceTest
	{
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            // AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"Test.config");
            AutoMapperConfiguration.Configure();
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

            ManageTextHandler lController = new ManageTextHandler();
			StaticTextDTO lResult;
			StaticTextDTO lDto;


			// Act
			lDto = new StaticTextDTO()
			{
				Title = lTitle,
				Description = lDescription,
				Text = lText
			};

			lDto.Id = lController.AddText(lDto);

			// Assert
			lResult = lController.GetText(lDto.Id);
			AssertAreEqual(lDto, lResult);
		}

		[TestMethod]
		public void StaticTextController_TitleModify()
		{
			// Arrange
			int lId = 1;
			string lTitle = "Texto 100";

            ManageTextHandler lController = new ManageTextHandler();
            StaticTextDTO lResult;
			StaticTextDTO lDto;

			// Act
			lDto = lController.GetText(lId);
			lDto.Title = lTitle;
			lController.ModifyText(lDto);

			// Assert
			lResult = lController.GetText(lId);
			this.AssertAreEqual(lDto, lResult);
		}

		[TestMethod]
		public void StaticTextController_DescriptionModify()
		{
			// Arrange
			int lId = 1;
			string lDescription = "vamo a calmarno";

            ManageTextHandler lController = new ManageTextHandler();
            StaticTextDTO lResult;
			StaticTextDTO lDto;

			// Act
			lDto = lController.GetText(lId);
			lDto.Description = lDescription;
			lController.ModifyText(lDto);

			// Assert
			lResult = lController.GetText(lId);
			this.AssertAreEqual(lDto, lResult);
		}

		[TestMethod]
		public void StaticTextController_TextModify()
		{
			// Arrange
			int lId = 1;
			string lText = "Aguante todo";

            ManageTextHandler lController = new ManageTextHandler();
            StaticTextDTO lResult;
			StaticTextDTO lDto;

			// Act
			lDto = lController.GetText(lId);
			lDto.Text = lText;
			lController.ModifyText(lDto);

			// Assert
			lResult = lController.GetText(lId);
			this.AssertAreEqual(lDto, lResult);
		}

		[TestMethod]
		public void StaticTextController_DeleteText()
		{
			// Arrange
			int lId = 1;

            ManageTextHandler lController = new ManageTextHandler();
            StaticTextDTO lRemoved;
			StaticTextDTO lDto;

			// Act
			lDto = lController.GetText(lId);
			lController.DeleteText(lDto);

			// Assert
			lRemoved = lController.GetText(lId);
			Assert.IsNull(lRemoved);
		}
	}
}
