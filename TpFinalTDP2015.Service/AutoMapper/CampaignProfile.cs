using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class CampaignProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Campaign, CampaignDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Description))
              .ForMember(dest => dest.ActiveIntervals, opt => opt.MapFrom(source => source.ActiveIntervals))
           //TODO agragar al dto los campos lista   .ForMember(dest => dest.ActiveIntervals, opt => opt.MapFrom(source => source.ActiveIntervals))
              .ForMember(dest => dest.ModificationDate, opt => opt.MapFrom(source => source.LastModified))
              .ForMember(dest => dest.Slides, opt => opt.MapFrom(source => source.Slides));
        }
    }
}
