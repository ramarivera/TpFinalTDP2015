using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.CrossCutting.Enum;
using TpFinalTDP2015.Model;

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
