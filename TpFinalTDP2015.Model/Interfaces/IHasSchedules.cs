using MarrSystems.TpFinalTDP2015.Model.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.Model.Interfaces
{
    public interface IHasSchedules
    {
        IEnumerable<Schedule> Schedules { get; }

        bool IsActiveAt(IScheduleChecker pValidator, DateTime pDate);

        void AddSchedule(IScheduleChecker pValidator, Schedule pInterval);

        void RemoveSchedule(Schedule pSchedule);

        void RemoveAllSchedules();
    }
}
