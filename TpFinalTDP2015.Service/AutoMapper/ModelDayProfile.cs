using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.BusinessLogic.Enum;

namespace TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class ModelDayProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Day,Days>()
                .ConvertUsing<DayToServiceDaysConverter>();
        }

    }
}
