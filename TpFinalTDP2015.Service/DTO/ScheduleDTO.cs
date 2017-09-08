using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarrSystems.TpFinalTDP2015.CrossCutting.Enum;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.DTO
{
    public class ScheduleDTO: IDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Name { get; set; }
        public DateTime ActiveUntil { get; set; }
        public DateTime ActiveFrom { get; set; }
        public IList<Days> ActiveDays { get; set; }
        public IList<ScheduleEntryDTO> ActiveHours { get; set; }

        public ScheduleDTO()
        {
            this.ActiveDays = new List<Days>();
            this.ActiveHours = new List<ScheduleEntryDTO>();
        }
    }
}
