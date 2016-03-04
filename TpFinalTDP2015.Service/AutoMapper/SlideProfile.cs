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
    public class SlideProfile: Profile
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
