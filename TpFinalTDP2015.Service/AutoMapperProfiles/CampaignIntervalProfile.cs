using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Persistence.Model;

namespace TpFinalTDP2015.Service.AutoMapperProfiles
{
    public class CampaignIntervalProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CampaignInterval, CampaignIntervalDTO>()
              .ForMember(d => d.Name, o => o.MapFrom(c => c.Name))
              .ForMember(d => d.StartDate, o => o.MapFrom(c => c.ActiveFrom))
              .ForMember(d => d.EndDate, o => o.MapFrom(c => c.ActiveUntil))
              .ForMember(d => d.StartTime, o => o.MapFrom(c => c.StartTime))
              .ForMember(d => d.EndTime, o => o.MapFrom(c => c.EndTime))
              .ForMember(d => d.Days, o => o.MapFrom(C => C.DiasDeLaSemana));
        }
    }
}
