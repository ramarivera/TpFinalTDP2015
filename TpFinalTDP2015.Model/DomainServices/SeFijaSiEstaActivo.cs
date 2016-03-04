using MarrSystems.TpFinalTDP2015.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Model.DomainServices
{
    public class SeFijaSiEstaActivo: ISeFijaSiEstaActivo
    {
        public bool IsActiveAt(IHasSchedules pCoso, DateTime pDate)
        {
            bool lResult = false;
            int i = pCoso.Schedules.Count() - 1;
            while ((lResult == false) && (i >= 0))
            {
                Schedule pInterval = pCoso.Schedules.ElementAt(i);
                lResult = pInterval.IsActiveAt(pDate);
                i--;
            }
            return lResult;
        }
    }
}
