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
    class TimeIntervalProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TimeInterval, TimeIntervalDTO>()
              .ForMember(d => d.Name, o => o.MapFrom(c => c.Name))
              .ForMember(d => d.StartTime, o => o.MapFrom(c => c.StartTime))
              .ForMember(d => d.EndTime, o => o.MapFrom(c => c.EndTime));
        }
    }
}
