using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.CrossCutting.Enum;
using TpFinalTDP2015.Model;
using TpFinalTDP2015.Service.Enum;

namespace TpFinalTDP2015.Service.AutoMapper
{
    class ServiceDaysToDayConverter : ITypeConverter<Days, Day>
    {
        Day ITypeConverter<Days, Day>.Convert(ResolutionContext pContext)
        {
            if (pContext == null || pContext.IsSourceValueNull)
                return default(Day);

            Days lTemp = (Days)pContext.SourceValue;

            Day lResult = new Day();

            lResult.Value = lTemp;
            
            return lResult;
        }
    }
}
