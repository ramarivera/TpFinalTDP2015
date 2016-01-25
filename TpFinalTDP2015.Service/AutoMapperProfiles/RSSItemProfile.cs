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
    class RSSItemProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<RSSItem, RSSItemDTO>()
              .ForMember(d => d.Title, o => o.MapFrom(c => c.Title))
              .ForMember(d => d.Description, o => o.MapFrom(c => c.Description))
              .ForMember(d => d.URL, o => o.MapFrom(c => c.URL))
              .ForMember(d => d.PublicationDate, o => o.MapFrom(c => c.PublicationDate));
        }
    }
}
