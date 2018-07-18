using MarrSystems.TpFinalTDP2015.Model.Interfaces;
using System;
using System.Linq;

namespace MarrSystems.TpFinalTDP2015.Model.DomainServices
{
    public class ScheduleChecker : IScheduleChecker
    {
        public bool CanAddSchedule(IHasSchedules pHasSchedules, Schedule pSchedule)
        {
            return pHasSchedules.Schedules.Any(x => pSchedule.IntersectsWith(x));
        }

        public bool IsActiveAt(IHasSchedules pHasSchedules, DateTime pDate)
        {
            return pHasSchedules.Schedules.Any(x => x.IsActiveAt(pDate));
        }
    }
}
