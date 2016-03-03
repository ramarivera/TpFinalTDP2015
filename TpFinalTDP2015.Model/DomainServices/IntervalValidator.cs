using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model.DomainServices
{
    public class IntervalValidator: IIntervalValidator
    {
        public bool CanBeAdded(ICosoQueTieneDateInterval pCoso, DateInterval pInterval)
        {
            bool lResult = true;
            int i = pCoso.ActiveIntervals.Count - 1;
            while ((lResult == true) && (i >= 0))
            {
                DateInterval lInterval = pCoso.ActiveIntervals[i];
                if (!pInterval.IntersectsWith(lInterval))
                {
                    lResult = false;
                }
                i--;
            }
            return lResult;
        }
    }
}
