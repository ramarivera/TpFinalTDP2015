using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.Model.DomainServices;
using MarrSystems.TpFinalTDP2015.Model.Exceptiones;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class AdminBannerDTOProfile : Profile
    {

        class BannerTextDTOResolver : ValueResolver<IList<StaticTextDTO>, IList<BaseBannerItem>>
        {
            protected override IList<BaseBannerItem> ResolveCore(IList<StaticTextDTO> source)
            {
                IList<BaseBannerItem> lResult = new List<BaseBannerItem>();

                foreach (StaticTextDTO text in source)
                {
                    lResult.Add(
                         Mapper.Map<StaticTextDTO, StaticText>(
                            text
                            )
                        );
                }

                return lResult;
            }


        }


        protected override void Configure()
        {
            Mapper.CreateMap<AdminBannerDTO, Banner>()
                .ConvertUsing<BannerConverter>();
        }

        private class BannerConverter : ITypeConverter<AdminBannerDTO, Banner>
        {
            Banner ITypeConverter<AdminBannerDTO, Banner>.Convert(ResolutionContext context)
            {
                if (context == null || context.IsSourceValueNull)
                    return null;

                AdminBannerDTO lDto = (AdminBannerDTO)context.SourceValue;

                try
                {
                    Banner lResult = new Banner()
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
                            DomainServiceLocator.Resolve<IScheduleChecker>(),
                            Mapper.Map<ScheduleDTO, Schedule>(item));
                    }

                    foreach (var item in lDto.Texts)
                    {
                        lResult.AddBannerItem(
                             Mapper.Map<StaticTextDTO, StaticText>(item)
                             );
                    }

                    foreach (var item in lDto.RssSources)
                    {
                        lResult.AddSource(
                            Mapper.Map<RssSourceDTO, RssSource>(item)
                            );
                    }

                    return lResult;

                }
                catch (EntidadNulaException ex)
                {
                    //TODO como lo muestro acá
                    return null;
                }
                catch(IntervaloFechaInvalidoException ex)
                {
                    //TODO como lo muestro acá
                    return null;
                }

            }
        }
    }
}
