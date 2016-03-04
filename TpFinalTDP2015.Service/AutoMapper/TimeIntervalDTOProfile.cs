using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class TimeIntervalDTOProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TimeIntervalDTO, TimeInterval>()
                .ConvertUsing<TimeIntervalConverter>();
        }

        private class TimeIntervalConverter : ITypeConverter<TimeIntervalDTO, TimeInterval>
        {
            TimeInterval ITypeConverter<TimeIntervalDTO, TimeInterval>.Convert(ResolutionContext context)
            {
                if (context == null || context.IsSourceValueNull)
                    return null;


                TimeIntervalDTO lDto = (TimeIntervalDTO)context.SourceValue;
                try
                {
                    TimeInterval lResult = new TimeInterval()
                    {
                        Id = lDto.Id,
                        LastModified = DateTimeResolver.Resolve(lDto.ModificationDate),
                        CreationDate = DateTimeResolver.Resolve(lDto.CreationDate),
                       // End = lDto.EndTime,
                      //  Start = lDto.StartTime,
                    };

                    lResult.End = lDto.EndTime;
                    lResult.Start = lDto.StartTime;

                    return lResult;

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        /*protected override void Configure() ANTERIOR
        {
            Mapper.CreateMap<TimeIntervalDTO, TimeInterval>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.ResolveUsing<DateTimeResolver>().FromMember(source => source.CreationDate))
              .ForMember(dest => dest.LastModified, opt => opt.ResolveUsing<DateTimeResolver>().FromMember(source => source.ModificationDate))
              .ForMember(dest => dest.Start, opt => opt.MapFrom(source => source.StartTime))
              .ForMember(dest => dest.End, opt => opt.MapFrom(source => source.EndTime));
        }*/
    }
}
