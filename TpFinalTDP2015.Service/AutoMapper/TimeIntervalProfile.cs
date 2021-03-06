﻿using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class TimeIntervalProfile : Profile
    {
        public TimeIntervalProfile()
        {
            CreateMap<ScheduleEntry, ScheduleEntryDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.ModificationDate, opt => opt.MapFrom(source => source.LastModified))
              .ForMember(dest => dest.StartTime, opt => opt.MapFrom(source => source.Start))
              .ForMember(dest => dest.EndTime, opt => opt.MapFrom(source => source.End));
        }
    }
}
