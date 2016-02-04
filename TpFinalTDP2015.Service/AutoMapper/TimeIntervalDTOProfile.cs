using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Service.AutoMapper
{
    class TimeIntervalDTOProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TimeIntervalDTO, TimeInterval>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.LastModified, opt => opt.MapFrom(source => source.ModificationDate))
              .ForMember(dest => dest.Start, opt => opt.MapFrom(source => source.StartTime))
              .ForMember(dest => dest.End, opt => opt.MapFrom(source => source.EndTime));
        }
    }
}
