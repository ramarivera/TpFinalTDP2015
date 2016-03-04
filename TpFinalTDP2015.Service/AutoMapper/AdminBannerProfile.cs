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
    public class AdminBannerProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Banner, AdminBannerDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.ModificationDate, opt => opt.MapFrom(source => source.LastModified))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Description))
              .ForMember(dest => dest.ActiveIntervals, opt => opt.MapFrom(source => source.ActiveIntervals))
              .ForMember(dest => dest.Texts, opt => opt.ResolveUsing<BannerItemResolver>().FromMember(source => source.Items))
              .ForMember(dest => dest.RssSources, opt => opt.MapFrom(source => source.RssSources)); ;
        }


        class BannerItemResolver : ValueResolver<IList<BaseBannerItem>, IList<StaticTextDTO>>
        {
            protected override IList<StaticTextDTO> ResolveCore(IList<BaseBannerItem> source)
            {
                IList<StaticTextDTO> lResult = new List<StaticTextDTO>();

                foreach (var baseItem in source)
                {
                    if (baseItem.Type == "Text")
                    {
                        lResult.Add(
                            Mapper.Map<StaticText, StaticTextDTO>(
                                (StaticText)baseItem
                                )
                            );
                    }
                }

                return lResult;
            }

        }



    }

}
