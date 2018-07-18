using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaign, CampaignDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Description))
              .ForMember(dest => dest.ActiveIntervals, opt => opt.MapFrom(source => source.Schedules))
              .ForMember(dest => dest.ModificationDate, opt => opt.MapFrom(source => source.LastModified))
              .ForMember(dest => dest.Slides, opt => opt.MapFrom(source => source.Slides));
        }
    }
}
