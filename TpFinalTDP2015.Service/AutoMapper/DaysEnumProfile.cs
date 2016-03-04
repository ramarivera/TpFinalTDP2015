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
    public class DaysEnumProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Days, Day>()
                .ConvertUsing<DaysEnumToDayConverter>();
        }

        class DaysEnumToDayConverter : ITypeConverter<Days, Day>
        {
            Day ITypeConverter<Days, Day>.Convert(ResolutionContext pContext)
            {
                if (pContext == null || pContext.IsSourceValueNull)
                    return default(Day);

                Days lTemp = (Days)pContext.SourceValue;

                Day lResult = new Day() { Value = lTemp };

                return lResult;
            }
        }

    }
}
