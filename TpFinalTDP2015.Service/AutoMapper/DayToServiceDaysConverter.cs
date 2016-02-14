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
    class DayToServiceDaysConverter : ITypeConverter<Day, Days>
    {
        Days ITypeConverter<Day, Days>.Convert(ResolutionContext pContext)
        {
            if (pContext == null || pContext.IsSourceValueNull)
                return default(Days);

            Day lTemp = (Day)pContext.SourceValue;

            Days lResult = lTemp.Value;

            return lResult;
        }
    }
}
