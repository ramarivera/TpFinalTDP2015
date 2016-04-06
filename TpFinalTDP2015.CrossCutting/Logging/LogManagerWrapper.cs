using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.CrossCutting.Logging
{
    public static class LogManagerWrapper
    {
        public static ILog GetLogger<T>()
        {
            return GetLogger(typeof(T));
        }

        public static ILog GetLogger(Type pType)
        {
            return LogManager.GetLogger(pType.GetFriendlyTypeName());
        }
    }
}
