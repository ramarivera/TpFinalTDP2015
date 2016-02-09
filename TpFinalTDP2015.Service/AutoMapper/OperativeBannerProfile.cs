using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Service.AutoMapper
{
    public class OperativeBannerProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Banner, OperativeBannerDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.ActiveIntervals, opt => opt.MapFrom(source => source.ActiveIntervals))
              .ForMember(dest => dest.Texts, opt => opt.MapFrom(source => source.Items))
              .ForMember(dest => dest.RssSources, opt => opt.MapFrom(source => source.RssSources)); ;
        }
    }
}
