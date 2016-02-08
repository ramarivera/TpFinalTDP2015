using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;

namespace TpFinalTDP2015.Service.Comparers
{
    public class DateIntervalDTOComparer: IEqualityComparer<DateIntervalDTO>
    {
        public bool Equals(DateIntervalDTO d1, DateIntervalDTO d2)
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

        public int GetHashCode(DateIntervalDTO pDateInterval)
        {
            int hCode = pDateInterval.Id;
            return hCode.GetHashCode();
        }
    }
}
