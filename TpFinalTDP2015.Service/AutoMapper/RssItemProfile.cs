﻿using AutoMapper;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;
using MarrSystems.TpFinalTDP2015.Model;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class RssItemProfile : Profile
    {
        public RssItemProfile()
        {
            CreateMap<RssItem, RssItemDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.ModificationDate, opt => opt.MapFrom(source => source.LastModified))
              .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Title))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Description))
              .ForMember(dest => dest.URL, opt => opt.MapFrom(source => source.URL))
              .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(source => source.PublicationDate));
        }
    }
}
