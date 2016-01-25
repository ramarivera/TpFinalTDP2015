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
    class StaticTextProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<StaticText, StaticTextDTO>()
              .ForMember(d => d.Title, o => o.MapFrom(c => c.Title))
              .ForMember(d => d.Description, o => o.MapFrom(c => c.Description))
              .ForMember(d => d.Text, o => o.MapFrom(c => c.Text));
        }

    }
}
