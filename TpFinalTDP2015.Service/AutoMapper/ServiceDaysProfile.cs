using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Service.Enum;

namespace TpFinalTDP2015.Service.AutoMapper
{
    public class ServiceDaysProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Days, Day>()
                .ConvertUsing<ServiceDaysToDayConverter>();
        }
    }
}
