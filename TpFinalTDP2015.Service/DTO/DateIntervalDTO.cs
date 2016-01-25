using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model.Enum;

namespace TpFinalTDP2015.Service.DTO
{
    public class DateIntervalDTO
    {
        public IList<Days> Days { get; set; }
        public DateTime ActiveUntil { get; set; }
        //public TimeSpan EndTime { get; set; }
        public string Name { get; set; }
        public DateTime ActiveFrom { get; set; }
        //public TimeSpan StartTime { get; set; }
    }
}
