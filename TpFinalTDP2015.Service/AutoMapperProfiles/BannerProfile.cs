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
    class BannerProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Banner, BannerDTO>()
              .ForMember(d => d.Id, o => o.MapFrom(c => c.Id))
              .ForMember(d => d.CreationDate, o => o.MapFrom(c => c.CreationDate))
              .ForMember(d => d.ModificationDate, o => o.MapFrom(c => c.LastModified))
              .ForMember(d => d.Name, o => o.MapFrom(c => c.Name))
              .ForMember(d => d.Description, o => o.MapFrom(c => c.Description))
              .ForMember(d => d.ActiveIntervals, o => o.MapFrom(c => c.ActiveIntervals))
              .ForMember(d => d.Items, o => o.MapFrom(c => c.Items));
        }
    }
}
