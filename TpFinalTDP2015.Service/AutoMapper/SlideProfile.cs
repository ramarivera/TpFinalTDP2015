using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Service.AutoMapper
{
    class SlideProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Slide, SlideDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(source => source.CreationDate))
              .ForMember(dest => dest.ModificationDate, opt => opt.MapFrom(source => source.LastModified))
              //.ForMember(dest => dest.Image, opt => opt.MapFrom(source => source.Image))
              .ForMember(dest => dest.Duration, opt => opt.MapFrom(source => source.Duration))
              .ForMember(dest => dest.Transition, opt => opt.MapFrom(source => source.Transition));
        }
    }
}
