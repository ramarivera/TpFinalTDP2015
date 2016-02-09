using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Service.AutoMapper;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.Test
{
    [TestClass]
    public class AutoMapperTest
    {
        [TestMethod]
        public void Mappings_ConfigureMappings_pass()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<BannerProfile>();
                cfg.AddProfile<CampaignProfile>();
                cfg.AddProfile<DateIntervalProfile>();
                cfg.AddProfile<ModelDayProfile>();
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
            Mapper.Initialize(cfg => {
                cfg.AddProfile<AdminBannerDTOProfile>();
                cfg.AddProfile<CampaignDTOProfile>();
                cfg.AddProfile<DateIntervalDTOProfile>();
                cfg.AddProfile<RssItemDTOProfile>();
                cfg.AddProfile<RssSourceDTOProfile>();
                cfg.AddProfile<ServiceDaysProfile>();
                cfg.AddProfile<SlideDTOProfile>();
                cfg.AddProfile<StaticTextDTOProfile>();
                cfg.AddProfile<TimeIntervalDTOProfile>();
            });
            Mapper.AssertConfigurationIsValid();
        }

        [TestMethod]
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
    }
}
