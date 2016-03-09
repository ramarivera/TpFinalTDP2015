using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model.DomainServices;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class CampaignDTOProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CampaignDTO, Campaign>()
                .ConvertUsing<CampaignConverter>();
        }

        private class CampaignConverter : ITypeConverter<CampaignDTO, Campaign>
        {
            private IScheduleChecker iValidator = new ScheduleChecker();//TODO ver esto
            Campaign ITypeConverter<CampaignDTO, Campaign>.Convert(ResolutionContext context)
            {
                if (context == null || context.IsSourceValueNull)
                    return null;


                CampaignDTO lDto = (CampaignDTO)context.SourceValue;
                try
                {
                    Campaign lResult = new Campaign()
                    {
                        Id = lDto.Id,
                        LastModified = DateTimeResolver.Resolve(lDto.ModificationDate),
                        CreationDate = DateTimeResolver.Resolve(lDto.CreationDate),
                        Name = lDto.Name,
                        Description = lDto.Description,
                    };

                    foreach (var item in lDto.ActiveIntervals)
                    {
                        lResult.AddSchedule(
                            iValidator,
                            Mapper.Map<ValueAndDescription, Schedule>(item)
                            );
                    }
                   /* foreach (var item in lDto.Slides)
                    {
                        lResult.AddSlide(
                            Mapper.Map<SlideDTO, Slide>(item)
                            );
                    }*/

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
