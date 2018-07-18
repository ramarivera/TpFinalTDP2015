using log4net;
using System;

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
