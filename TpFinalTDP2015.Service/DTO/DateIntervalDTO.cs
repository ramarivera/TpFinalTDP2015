using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.Enum;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Service.DTO
{
    public class DateIntervalDTO: IDTO
    {
        public string Name { get; set; }
        public DateTime ActiveUntil { get; set; }
        public DateTime ActiveFrom { get; set; }
        public IList<Days> Days { get; set; }
        public IList<TimeInterval> ActiveHours { get; set; }
    }
}
