﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Comparers
{
    public class DateIntervalDTOComparer: IEqualityComparer<ScheduleDTO>
    {
        public bool Equals(ScheduleDTO d1, ScheduleDTO d2)
        {
            if (d2 == null && d1 == null)
                return true;
            else if (d1 == null | d2 == null)
                return false;
            else if (d1.Id == d2.Id)
                return true;
            else
                return false;
        }

        public int GetHashCode(ScheduleDTO pDateInterval)
        {
            int hCode = pDateInterval.Id;
            return hCode.GetHashCode();
        }
    }
}
