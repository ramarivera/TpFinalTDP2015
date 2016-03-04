﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.BusinessLogic.Enum;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class SlideTransitioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Model.Enum.SlideTransition, BusinessLogic.Enum.SlideTransition>()
                .ConstructUsing(EnumConversion.SlideTransition);
        }
    }
}
