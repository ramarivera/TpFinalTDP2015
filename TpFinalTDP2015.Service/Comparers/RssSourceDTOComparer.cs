using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.BusinessLogic.DTO;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.Comparers
{
    public class RssSourceDTOComparer: IEqualityComparer<RssSourceDTO>
    {
        public bool Equals(RssSourceDTO r1, RssSourceDTO r2)
        {
            if (r2 == null && r1 == null)
                return true;
            else if (r1 == null | r2 == null)
                return false;
            else if (r1.Id == r2.Id)
                return true;
            else
                return false;
        }

        public int GetHashCode(RssSourceDTO pRssSource)
        {
            int hCode = pRssSource.Id;
            return hCode.GetHashCode();
        }
    }
}
