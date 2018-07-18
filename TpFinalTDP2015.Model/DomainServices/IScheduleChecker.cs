using MarrSystems.TpFinalTDP2015.Model.Interfaces;
using System;

namespace MarrSystems.TpFinalTDP2015.Model.DomainServices
{
    public interface IScheduleChecker
    {
        bool CanAddSchedule(IHasSchedules pHasSchedules, Schedule pInterval);

        bool IsActiveAt(IHasSchedules pHasSchedules, DateTime pDate);
    }
}
