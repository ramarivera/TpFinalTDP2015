using log4net.Layout.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using System.IO;

namespace MarrSystems.TpFinalTDP2015.CrossCutting.Logging
{
   public class ShortLoggerNameConverter :  PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            string aux = Type.GetType(loggingEvent.LoggerName).GetFriendlyTypeName();
            writer.Write(aux);
        }

    }
}
