using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;
using System.Collections.Generic;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class AdminBannerProfile : Profile
    {
        public AdminBannerProfile()
        {
            CreateMap<Banner, AdminBannerDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.ModificationDate, opt => opt.MapFrom(source => source.LastModified))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Description))
              .ForMember(dest => dest.ActiveIntervals, opt => opt.MapFrom(source => source.Schedules))
              .ForMember(dest => dest.Texts, opt => opt.ResolveUsing<BannerItemResolver>())
              .ForMember(dest => dest.RssSources, opt => opt.MapFrom(source => source.RssSources)); ;
        }

        class BannerItemResolver : IValueResolver<Banner, AdminBannerDTO, IList<StaticTextDTO>>
        {
            public IList<StaticTextDTO> Resolve(Banner source, AdminBannerDTO destination, IList<StaticTextDTO> destMember, ResolutionContext context)
            {
                IList<StaticTextDTO> lResult = new List<StaticTextDTO>();

                foreach (var baseItem in source.Items)
                {
                    if (baseItem.Type == "Text")
                    {
                        lResult.Add(Mapper.Map<StaticTextDTO>((StaticText)baseItem));
                    }
                }

                return lResult;
            }
        }
    }
}
