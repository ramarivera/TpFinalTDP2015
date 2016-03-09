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
    public class ScheduleEntryDTOProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ScheduleEntryDTO, ScheduleEntry>()
                .ConvertUsing<TimeIntervalConverter>();
        }

        private class TimeIntervalConverter : ITypeConverter<ScheduleEntryDTO, ScheduleEntry>
        {
            ScheduleEntry ITypeConverter<ScheduleEntryDTO, ScheduleEntry>.Convert(ResolutionContext context)
            {
                if (context == null || context.IsSourceValueNull)
                    return null;


                ScheduleEntryDTO lDto = (ScheduleEntryDTO)context.SourceValue;
                try
                {
                    ScheduleEntry lResult = new ScheduleEntry()
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
            Mapper.CreateMap<ScheduleEntryDTO, TimeInterval>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.ResolveUsing<DateTimeResolver>().FromMember(source => source.CreationDate))
              .ForMember(dest => dest.LastModified, opt => opt.ResolveUsing<DateTimeResolver>().FromMember(source => source.ModificationDate))
              .ForMember(dest => dest.Start, opt => opt.MapFrom(source => source.StartTime))
              .ForMember(dest => dest.End, opt => opt.MapFrom(source => source.EndTime));
        }*/
    }
}
