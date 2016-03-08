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
    public class OperativeBannerProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Banner, OperativeBannerDTO>()
                .ConvertUsing<OperativeBannerConverter>();     
        }

        private class OperativeBannerConverter : ITypeConverter<Banner, OperativeBannerDTO>
        {
            OperativeBannerDTO ITypeConverter<Banner, OperativeBannerDTO>.Convert(ResolutionContext context)
            {
                if (context == null || context.IsSourceValueNull)
                    return null;

                Banner lBanner = (Banner)context.SourceValue;
                OperativeBannerDTO lResult = new OperativeBannerDTO()
                {
                    Id = lBanner.Id,
                    ActiveIntervals = new List<ScheduleDTO>(),
                    Texts = new List<StaticTextDTO>(),
                    RssItems = new List<RssItemDTO>()
                };


                foreach (var interval in lBanner.Schedules)
                {
                    lResult.ActiveIntervals.Add(
                        Mapper.Map<Schedule, ScheduleDTO>(interval)
                        );
                }

                foreach (var item in lBanner.Items)
                {
                    Type lType = item.GetType();

                    if (lType == typeof(StaticText))
                    {
                        lResult.Texts.Add(
                            Mapper.Map<StaticText, StaticTextDTO>(
                                (StaticText)item
                                )
                            );
                    }
                    else if (lType == typeof(RssItem))
                    {
                        lResult.RssItems.Add(
                            Mapper.Map<RssItem, RssItemDTO>(
                                (RssItem)item
                                )
                            );
                    }
                    else
                    {
                        //TODO EXCEPCION; CAGAMOS
                    }
                }
                return lResult;
            }
        }
    }
}
