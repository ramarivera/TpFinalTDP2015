using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.CrossCutting.Enum;
using TpFinalTDP2015.Service.Enum;

namespace TpFinalTDP2015.Service.DTO
{
    public class DateIntervalDTO: IDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Name { get; set; }
        public DateTime ActiveUntil { get; set; }
        public DateTime ActiveFrom { get; set; }
        public IList<Days> Days { get; set; }
        public IList<TimeIntervalDTO> ActiveHours { get; set; }

        public DateIntervalDTO()
        {
            this.Days = new List<Days>();
            this.ActiveHours = new List<TimeIntervalDTO>();
        }
    }
}
