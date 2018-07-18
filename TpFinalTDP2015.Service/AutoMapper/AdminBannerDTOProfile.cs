using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Model.DomainServices;
using MarrSystems.TpFinalTDP2015.Model.Exceptiones;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class AdminBannerDTOProfile : Profile
    {
        public AdminBannerDTOProfile()
        {
            CreateMap<AdminBannerDTO, Banner>()
                .ConvertUsing<BannerConverter>();
        }

        private class BannerConverter : ITypeConverter<AdminBannerDTO, Banner>
        {
            public Banner Convert(AdminBannerDTO source, Banner destination, ResolutionContext context)
            {
                if (source == null)
                    return null;

                destination = destination ?? new Banner();

                try
                {
                    destination.Id = source.Id;
                    destination.LastModified = DateTimeResolver.Resolve(source.ModificationDate);
                    destination.CreationDate = DateTimeResolver.Resolve(source.CreationDate);
                    destination.Name = source.Name;
                    destination.Description = source.Description;

                    var lScheduleChecker = DomainServiceLocator.Resolve<IScheduleChecker>();

                    foreach (var item in source.ActiveIntervals)
                    {
                        destination.AddSchedule(lScheduleChecker, Mapper.Map<Schedule>(item));
                    }

                    foreach (var item in source.Texts)
                    {
                        destination.AddBannerItem(Mapper.Map<StaticText>(item));
                    }

                    foreach (var item in source.RssSources)
                    {
                        destination.AddSource(Mapper.Map<RssSource>(item));
                    }

                    return destination;
                }
                catch (EntidadNulaException ex)
                {
                    //TODO como lo muestro acá
                    return null;
                }
                catch (IntervaloFechaInvalidoException ex)
                {
                    //TODO como lo muestro acá
                    return null;
                }
            }
        }
    }
}
