﻿using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class DateIntervalProfile : Profile
    {
        public DateIntervalProfile()
        {
            CreateMap<Schedule, ScheduleDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.ModificationDate, opt => opt.MapFrom(source => source.LastModified))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
              .ForMember(dest => dest.ActiveFrom, opt => opt.MapFrom(source => source.ActiveFrom))
              .ForMember(dest => dest.ActiveUntil, opt => opt.MapFrom(source => source.ActiveUntil))
              .ForMember(dest => dest.ActiveDays, opt => opt.MapFrom(source => source.ActiveDays))
              .ForMember(dest => dest.ActiveHours, opt => opt.MapFrom(source => source.ActiveHours));
        }
    }
}
