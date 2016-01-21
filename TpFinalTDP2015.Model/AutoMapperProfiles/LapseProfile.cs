using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model.DTO;
using TpFinalTDP2015.Persistence.Model;

namespace TpFinalTDP2015.Model.AutoMapperProfiles
{
    public class LapseProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<IntervaloAplicacion, LapseDTO>()
              .ForMember(d => d.Name, o => o.MapFrom(c => c.Name))
              .ForMember(d => d.StartDate, o => o.MapFrom(c => c.FechaInicio))
              .ForMember(d => d.EndDate, o => o.MapFrom(c => c.FechaFin))
              .ForMember(d => d.StartTime, o => o.MapFrom(c => c.HoraInicio))
              .ForMember(d => d.EndTime, o => o.MapFrom(c => c.HoraFin))
              .ForMember(d => d.Days, o => o.MapFrom(C => C.DiasDeLaSemana));
        }
    }
}
