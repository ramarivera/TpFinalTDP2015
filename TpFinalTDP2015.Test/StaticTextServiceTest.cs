using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarrSystems.TpFinalTDP2015.BusinessLogic;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Services;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;

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

        StaticTextService Controller
		{
			get
			{
				return (StaticTextService)
                    ServiceFactory.
                    GetService<StaticTextDTO>();
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

            StaticTextService lController = this.Controller;
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

            StaticTextService lController = this.Controller;
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

            StaticTextService lController = this.Controller;
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

            StaticTextService lController = this.Controller;
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

		[TestMethod]
		public void StaticTextController_DeleteText()
		{
			// Arrange
			int lId = 1;

            StaticTextService lController = this.Controller;
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
