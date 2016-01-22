using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Persistence.Model;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.Service.AutoMapperProfiles
{
    class CampaignProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Campaign, CampaignDTO>()
              .ForMember(d => d.Name, o => o.MapFrom(c => c.Name))
              .ForMember(d => d.Description, o => o.MapFrom(c => c.Description))
           //TODO agragar al dto los campos lista   .ForMember(d => d.ActiveIntervals, o => o.MapFrom(c => c.));
              .ForMember(d => d.ModificationDate, o => o.MapFrom(c => c.LastModified));
        }
    }
}
