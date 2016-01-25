﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.Enum;

namespace TpFinalTDP2015.Service.AutoMapperProfiles
{
    class SlideTransitioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Model.Enum.SlideTransition, Service.Enum.SlideTransition>()
                .ConstructUsing(EnumConversion.SlideTransition);
        }
    }
}
