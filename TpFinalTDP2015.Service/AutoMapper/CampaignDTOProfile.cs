using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Model.DomainServices;
using System;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class CampaignDTOProfile : Profile
    {
        public CampaignDTOProfile()
        {
            CreateMap<CampaignDTO, Campaign>()
                .ConvertUsing<CampaignConverter>();
        }

        private class CampaignConverter : ITypeConverter<CampaignDTO, Campaign>
        {
            public Campaign Convert(CampaignDTO source, Campaign destination, ResolutionContext context)
            {
                if (source == null)
                    return null;

                try
                {
                    destination = destination ?? new Campaign();

                    destination.Id = source.Id;
                    destination.LastModified = DateTimeResolver.Resolve(source.ModificationDate);
                    destination.CreationDate = DateTimeResolver.Resolve(source.CreationDate);
                    destination.Name = source.Name;
                    destination.Description = source.Description;

                    IScheduleChecker lScheduleChecker = DomainServiceLocator.Resolve<IScheduleChecker>();

                    foreach (var item in source.ActiveIntervals)
                    {
                        destination.AddSchedule(lScheduleChecker, Mapper.Map<Schedule>(item));
                    }

                    //foreach (var item in source.Slides)
                    //{
                    //    destination.AddSlide(
                    //        Mapper.Map<SlideDTO, Slide>(item)
                    //        );
                    //}

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
