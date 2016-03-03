using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model.DomainServices
{
    public class SeFijaSiEstaActivo: ISeFijaSiEstaActivo
    {
        public bool IsActiveAt(ICosoQueTieneDateInterval pCoso, DateTime pDate)
        {
            bool lResult = false;
            int i = pCoso.ActiveIntervals.Count - 1;
            while ((lResult == false) && (i >= 0))
            {
                DateInterval pInterval = pCoso.ActiveIntervals[i];
                lResult = pInterval.IsActiveAt(pDate);
                i--;
            }
            return lResult;
        }
    }
}
