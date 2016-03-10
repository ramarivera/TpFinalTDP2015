using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.BusinessLogic;

namespace MarrSystems.TpFinalTDP2015.Test
{
    [TestClass]
    public class AutoMapperTest
    {
        [TestCleanup()]
        public void TestCleanup()
        {
            AutoMapperConfiguration.Configure();
        }



        [TestMethod]
        public void Mappings_ConfigureMappings_pass()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AdminBannerProfile>();
                cfg.AddProfile<OperativeBannerProfile>();
                cfg.AddProfile<CampaignProfile>();
                cfg.AddProfile<DateIntervalProfile>();
                cfg.AddProfile<DayProfile>();
                cfg.AddProfile<RssItemProfile>();
                cfg.AddProfile<RssSourceProfile>();
                cfg.AddProfile<SlideProfile>();
                cfg.AddProfile<StaticTextProfile>();
                cfg.AddProfile<TimeIntervalProfile>();
            });
            Mapper.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void Mappings_ConfigureMappings_Inverse_pass()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AdminBannerDTOProfile>();
                cfg.AddProfile<CampaignDTOProfile>();
                cfg.AddProfile<DateIntervalDTOProfile>();
                cfg.AddProfile<RssItemDTOProfile>();
                cfg.AddProfile<RssSourceDTOProfile>();
                cfg.AddProfile<DaysEnumProfile>();
               // cfg.AddProfile<SlideDTOProfile>();
                cfg.AddProfile<SlideTransitioProfile>();
                cfg.AddProfile<StaticTextDTOProfile>();
                cfg.AddProfile<ScheduleEntryDTOProfile>();
            });
         //   Mapper.AssertConfigurationIsValid();
        }

        /*    [TestMethod]
            public void Mappings_ViewModel_Campaign_ToDTO_pass()
            {

                Campaign campaign = new Campaign()
                {
                    Name = "publicidad",
                    Description = "perfumes de mujer",
                    LastModified = DateTime.Now,
                };

                CampaignDTO campaignDTO = Mapper.Map<Campaign, CampaignDTO>(campaign);
                Assert.IsNotNull(campaignDTO);
                Assert.AreEqual("publicidad", campaignDTO.Name);
                Assert.AreEqual("perfumes de mujer",campaignDTO.Description);
            }

            [TestMethod]
            public void Mappings_ViewModel_DTO_ToCampaign_pass()
            {

                CampaignDTO campaignDTO = new CampaignDTO()
                {
                    Name = "publicidad",
                    Description = "perfumes de mujer",
                    ModificationDate = DateTime.Now,
                };

                Campaign campaign = Mapper.Map<CampaignDTO, Campaign>(campaignDTO);
                Assert.IsNotNull(campaign);
                Assert.AreEqual("publicidad", campaign.Name);
                Assert.AreEqual("perfumes de mujer", campaign.Description);
            }
        }*/
    }
}
