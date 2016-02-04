using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.Enum;

namespace TpFinalTDP2015.Service.AutoMapper
{
    class ModelDaysProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Model.Enum.Days,Service.Enum.Days>()
                .ConstructUsing(EnumConversion.ModelDaysToServiceDays);
        }
    }

}
