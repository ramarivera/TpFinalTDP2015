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
    class BannerDTOProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<BannerDTO, Banner>()
              .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Description));
            //.ForMember(dest => dest.CampaignIntervals, opt => opt.MapFrom(source => source.CampaignIntervals));
        }

        //TODO falta la lista del contenido del mismo
    }
}
