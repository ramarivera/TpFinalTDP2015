using System;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class DateTimeResolver /*: ValueResolver<DateTime, DateTime>*/
    {
        public static DateTime Resolve(DateTime source)
        {
            return source;
            // prev: return source == new DateTime(0) ? DateTime.Now : source;
        }
    }
}
