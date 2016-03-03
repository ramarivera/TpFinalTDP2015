using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.BusinessLogic.DTO;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class AdminBannerDTOProfile : Profile
    {
        /* protected override void Configure()
         {
             Mapper.CreateMap<AdminBannerDTO, Banner>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
               .ForMember(dest => dest.CreationDate, opt => opt.ResolveUsing<DateTimeResolver>().FromMember(source => source.CreationDate))
               .ForMember(dest => dest.LastModified, opt => opt.ResolveUsing<DateTimeResolver>().FromMember(source => source.ModificationDate))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Description))
               .ForMember(dest => dest.ActiveIntervals, opt => opt.MapFrom(source => source.ActiveIntervals))
               .ForMember(dest => dest.Items, opt => opt.ResolveUsing<BannerTextDTOResolver>().FromMember(source => source.Texts))
               .ForMember(dest => dest.RssSources, opt => opt.MapFrom(source => source.RssSources));
         }

    */
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
                        lResult.AddDateInterval(
                            Mapper.Map<DateIntervalDTO, DateInterval>(item)
                            );
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
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
