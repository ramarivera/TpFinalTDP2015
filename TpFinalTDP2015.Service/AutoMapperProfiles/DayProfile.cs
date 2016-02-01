using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Model;
using AutoMapper;

namespace TpFinalTDP2015.Service.AutoMapperProfiles
{
    class DayProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Day, DayDTO>()
              .ForMember(d => d.Id, o => o.MapFrom(c => c.Id))
              .ForMember(d => d.CreationDate, o => o.MapFrom(c => c.CreationDate))
              .ForMember(d => d.ModificationDate, o => o.MapFrom(c => c.LastModified))
              .ForMember(d => d.Value, o => o.MapFrom(c => c.Value))
              .ForMember(d => d.NameOfDay, o => o.MapFrom(c => c.NameOfDay));
        }
    }
}
