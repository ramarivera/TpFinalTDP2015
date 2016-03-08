using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.DTO
{
    public class CampaignDTO: IDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ModificationDate { get; set; }
        public IList<ScheduleDTO> ActiveIntervals { get; set; }
        public IList<SlideDTO> Slides { get; set; }

        public CampaignDTO()
        {
            this.ActiveIntervals = new List<ScheduleDTO>();
            this.Slides = new List<SlideDTO>();
        }
    }
}
