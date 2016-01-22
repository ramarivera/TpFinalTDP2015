using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Persistence.Model;

namespace TpFinalTDP2015.Service
{
    class RSSSourceProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<RSSSource, RSSSourceDTO>()
              .ForMember(d => d.Title, o => o.MapFrom(c => c.Title))
              .ForMember(d => d.Description, o => o.MapFrom(c => c.Description))
              .ForMember(d => d.URL, o => o.MapFrom(c => c.URL))
              .ForMember(d => d.Items, o => o.MapFrom(c => c.Items));
        }
    }
}
