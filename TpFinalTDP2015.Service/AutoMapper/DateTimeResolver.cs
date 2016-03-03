using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.BusinessLogic.AutoMapper
{
    public class DateTimeResolver : ValueResolver<DateTime, DateTime>
    {
        protected override DateTime ResolveCore(DateTime source)
        {
            return DateTimeResolver.Resolve(source);
        }

        public static DateTime Resolve(DateTime source)
        {
            return source == new DateTime(0) ? DateTime.Now : source;
        }
    }
}
