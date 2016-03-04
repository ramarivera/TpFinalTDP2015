using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.Model;
using MarrSystems.TpFinalTDP2015.CrossCutting.Enum;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class DayProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Day,Days>()
                .ConvertUsing<DayToDaysEnumConverter>();
        }

        class DayToDaysEnumConverter : ITypeConverter<Day, Days>
        {
            Days ITypeConverter<Day, Days>.Convert(ResolutionContext pContext)
            {
                if (pContext == null || pContext.IsSourceValueNull)
                    return default(Days);

                Day lTemp = (Day)pContext.SourceValue;

                Days lResult = Mapper.Map<Day, Days>(lTemp);

                return lResult;
            }
        }
    }

   
}
