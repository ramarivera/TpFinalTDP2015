﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Service.AutoMapperProfiles
{
    public class DateIntervalProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<DateInterval, DateIntervalDTO>()
              .ForMember(d => d.Id, o => o.MapFrom(c => c.Id))
              .ForMember(d => d.CreationDate, o => o.MapFrom(c => c.CreationDate))
              .ForMember(d => d.ModificationDate, o => o.MapFrom(c => c.LastModified))
              .ForMember(d => d.Name, o => o.MapFrom(c => c.Name))
              .ForMember(d => d.ActiveFrom, o => o.MapFrom(c => c.ActiveFrom))
              .ForMember(d => d.ActiveUntil, o => o.MapFrom(c => c.ActiveUntil))
              .ForMember(d => d.Days, o => o.MapFrom(C => C.ActiveDays))
              .ForMember(d => d.ActiveHours, o => o.MapFrom(C => C.ActiveHours));
        }
    }
}//TODO terminar profile y actualizar DTO
