using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.BusinessLogic.Enum;

namespace TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class ModelDaysProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Model.Enum.Days,BusinessLogic.Enum.Days>()
                .ConstructUsing(EnumConversion.ModelDaysToServiceDays);
        }
    }

}
