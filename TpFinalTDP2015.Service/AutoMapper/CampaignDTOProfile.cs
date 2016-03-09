﻿using AutoMapper;
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
        /* protected override void Configure()
         {
             Mapper.CreateMap<CampaignDTO, Campaign>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
               .ForMember(dest => dest.CreationDate, opt => opt.ResolveUsing<DateTimeResolver>().FromMember(source => source.CreationDate))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Description))
               .ForMember(dest => dest.ActiveIntervals, opt => opt.MapFrom(source => source.ActiveIntervals))
            //TODO agragar al dto los campos lista   .ForMember(dest => dest.ActiveIntervals, opt => opt.MapFrom(source => source.ActiveIntervals))
               .ForMember(dest => dest.LastModified, opt => opt.ResolveUsing<DateTimeResolver>().FromMember(source => source.ModificationDate))
               .ForMember(dest => dest.Slides, opt => opt.MapFrom(source => source.Slides));
         }*/

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
                            Mapper.Map<ScheduleDTO, Schedule>(item)
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
