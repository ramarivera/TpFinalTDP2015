using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.Test
{
    [TestClass]
    public class AutoMapperTest
    {
        [TestMethod]
        public void Mappings_ConfigureMappings_pass()
        {
            Mapper.CreateMap<DateInterval, DateIntervalDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.ModificationDate, opt => opt.MapFrom(source => source.LastModified))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
              .ForMember(dest => dest.ActiveFrom, opt => opt.MapFrom(source => source.ActiveFrom))
              .ForMember(dest => dest.ActiveUntil, opt => opt.MapFrom(source => source.ActiveUntil))
              .ForMember(dest => dest.Days, opt => opt.MapFrom(source => source.ActiveDays))
              .ForMember(dest => dest.ActiveHours, opt => opt.MapFrom(source => source.ActiveHours));
            Mapper.AssertConfigurationIsValid();
        }

       [TestMethod]
        public void Mappings_ConfigureMappings_Inverse_pass()
        {
            Mapper.CreateMap<DateIntervalDTO, DateInterval>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.LastModified, opt => opt.MapFrom(source => source.ModificationDate))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
              .ForMember(dest => dest.ActiveFrom, opt => opt.MapFrom(source => source.ActiveFrom))
              .ForMember(dest => dest.ActiveUntil, opt => opt.MapFrom(source => source.ActiveUntil))
              .ForMember(dest => dest.ActiveDays, opt => opt.MapFrom(source => source.Days))
              .ForMember(dest => dest.ActiveHours, opt => opt.MapFrom(source => source.ActiveHours));
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
