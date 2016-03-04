using MarrSystems.TpFinalTDP2015.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Model.DomainServices
{
    public class ScheduleChecker: IScheduleChecker
    {
        public bool CanAddSchedule(IHasSchedules pCoso, Schedule pInterval)
        {
            bool lResult = true;
            int i = pCoso.Schedules.Count() - 1;
            while ((lResult == true) && (i >= 0))
            {
                Schedule lInterval = pCoso.Schedules.ElementAt(i);
                if (!pInterval.IntersectsWith(lInterval))
                {
                    lResult = false;
                }
                i--;
            }
            return lResult;
        }

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
