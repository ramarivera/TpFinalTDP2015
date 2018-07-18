using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;
using System;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class DateIntervalDTOProfile : Profile
    {
        public DateIntervalDTOProfile()
        {
            CreateMap<ScheduleDTO, Schedule>()
                .ConvertUsing<DateIntervalConverter>();
        }

        private class DateIntervalConverter : ITypeConverter<ScheduleDTO, Schedule>
        {
            public Schedule Convert(ScheduleDTO source, Schedule destination, ResolutionContext context)
            {
                if (source == null)
                {
                    return null;
                }

                try
                {
                    destination = destination ?? new Schedule();

                    destination.Id = source.Id;
                    destination.LastModified = DateTimeResolver.Resolve(source.ModificationDate);
                    destination.CreationDate = DateTimeResolver.Resolve(source.CreationDate);
                    destination.Name = source.Name;
                    destination.ActiveUntil = source.ActiveUntil;
                    destination.ActiveFrom = source.ActiveFrom;

                    foreach (var item in source.ActiveHours)
                    {
                        destination.AddTimeInterval(Mapper.Map<ScheduleEntryDTO, ScheduleEntry>(item));
                    }

                    foreach (var item in source.ActiveDays)
                    {
                        destination.AddDay(item);
                    }

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
