using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;
using System;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class ScheduleEntryDTOProfile : Profile
    {
        public ScheduleEntryDTOProfile()
        {
            CreateMap<ScheduleEntryDTO, ScheduleEntry>()
                .ConvertUsing<TimeIntervalConverter>();
        }

        private class TimeIntervalConverter : ITypeConverter<ScheduleEntryDTO, ScheduleEntry>
        {
            public ScheduleEntry Convert(ScheduleEntryDTO source, ScheduleEntry destination, ResolutionContext context)
            {
                if (source == null)
                    return null;

                try
                {
                    destination = destination ?? new ScheduleEntry();

                    destination.Id = source.Id;
                    destination.LastModified = DateTimeResolver.Resolve(source.ModificationDate);
                    destination.CreationDate = DateTimeResolver.Resolve(source.CreationDate);
                    destination.End = source.EndTime;
                    destination.Start = source.StartTime;

                    return destination;

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
