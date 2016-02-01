using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Service.AutoMapperProfiles
{
    class BannerDTOProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<BannerDTO, Banner>()
              .ForMember(d => d.Name, o => o.MapFrom(c => c.Name))
              .ForMember(d => d.Description, o => o.MapFrom(c => c.Description));
            //.ForMember(d => d.CampaignIntervals, o => o.MapFrom(c => c.CampaignIntervals));
        }

        //TODO falta la lista del contenido del mismo
    }
}
