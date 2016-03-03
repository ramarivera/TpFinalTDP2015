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
    public class RssItemDTOProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<RssItemDTO, RssItem>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.ResolveUsing<DateTimeResolver>().FromMember(source => source.CreationDate))
              .ForMember(dest => dest.LastModified, opt => opt.ResolveUsing<DateTimeResolver>().FromMember(source => source.ModificationDate))
              .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Title))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Description))
              .ForMember(dest => dest.URL, opt => opt.MapFrom(source => source.URL))
              .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(source => source.PublicationDate));
        }
    }
}
