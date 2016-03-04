using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.CrossCutting.Enum;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class DateIntervalDTOProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<DateIntervalDTO, DateInterval>()
                .ConvertUsing<DateIntervalConverter>();
        }

        private class DateIntervalConverter : ITypeConverter<DateIntervalDTO, DateInterval>
        {
            DateInterval ITypeConverter<DateIntervalDTO, DateInterval>.Convert(ResolutionContext context)
            {
                if (context == null || context.IsSourceValueNull)
                    return null;


                DateIntervalDTO lDto = (DateIntervalDTO)context.SourceValue;
                try
                {
                    DateInterval lResult = new DateInterval()
                    {
                        Id = lDto.Id,
                        LastModified = DateTimeResolver.Resolve(lDto.ModificationDate),
                        CreationDate = DateTimeResolver.Resolve(lDto.CreationDate),
                        Name = lDto.Name,
                        ActiveUntil = lDto.ActiveUntil,
                        ActiveFrom = lDto.ActiveFrom,
                    };

                    foreach (var item in lDto.ActiveHours)
                    {
                        lResult.AddTimeInterval(
                            Mapper.Map<TimeIntervalDTO, TimeInterval>(item)
                            );
                    }

                    foreach (var item in lDto.Days)
                    {
                        lResult.AddDay(
                            Mapper.Map<Days, Day>(item)
                            );
                    }

                    return lResult;

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
