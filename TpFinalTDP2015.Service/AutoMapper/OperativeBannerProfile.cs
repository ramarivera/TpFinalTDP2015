using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;
using System;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class OperativeBannerProfile : Profile
    {
        public OperativeBannerProfile()
        {
            CreateMap<Banner, OperativeBannerDTO>()
                .ConvertUsing<OperativeBannerConverter>();
        }

        private class OperativeBannerConverter : ITypeConverter<Banner, OperativeBannerDTO>
        {
            public OperativeBannerDTO Convert(Banner source, OperativeBannerDTO destination, ResolutionContext context)
            {
                if (source == null)
                    return null;

                destination = destination ?? new OperativeBannerDTO();
                destination.Id = source.Id;

                foreach (var interval in source.Schedules)
                {
                    destination.ActiveIntervals.Add(Mapper.Map<ScheduleDTO>(interval));
                }

                foreach (var item in source.Items)
                {
                    Type lType = item.GetType();

                    if (lType == typeof(StaticText))
                    {
                        destination.Texts.Add(Mapper.Map<StaticTextDTO>((StaticText)item));
                    }
                    else if (lType == typeof(RssItem))
                    {
                        destination.RssItems.Add(Mapper.Map<RssItemDTO>((RssItem)item));
                    }
                    else
                    {
                        //TODO EXCEPCION; CAGAMOS
                    }
                }
                return destination;
            }
        }
    }
}
