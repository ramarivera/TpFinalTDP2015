using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model.DomainServices
{
    public interface ICosoQueTieneDateInterval
    {
        IList<DateInterval> ActiveIntervals { get; }

        void AddDateInterval(DateInterval pInterval, IIntervalValidator pValidator);
    }
}
