﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Service.AutoMapper
{
    public class DateIntervalProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<DateInterval, DateIntervalDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.ModificationDate, opt => opt.MapFrom(source => source.LastModified))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
              .ForMember(dest => dest.ActiveFrom, opt => opt.MapFrom(source => source.ActiveFrom))
              .ForMember(dest => dest.ActiveUntil, opt => opt.MapFrom(source => source.ActiveUntil))
              .ForMember(dest => dest.Days, opt => opt.MapFrom(source => source.ActiveDays))
              .ForMember(dest => dest.ActiveHours, opt => opt.MapFrom(source => source.ActiveHours));
        }
    }
}//TODO terminar profile y actualizar DTO