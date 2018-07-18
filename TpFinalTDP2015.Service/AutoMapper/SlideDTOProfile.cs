using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class SlideDTOProfile : Profile
    {
        public SlideDTOProfile()
        {
            CreateMap<SlideDTO, Slide>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.LastModified, opt => opt.MapFrom(source => source.ModificationDate))
              .ForMember(dest => dest.Duration, opt => opt.MapFrom(source => source.Duration))
              .ForMember(dest => dest.Transition, opt => opt.MapFrom(source => source.Transition));
        }
    }
}