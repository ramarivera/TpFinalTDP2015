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
        public IList<ValueAndDescription> ActiveIntervals { get; set; }
        public IList<ValueAndDescription> Slides { get; set; }

        public CampaignDTO()
        {
            this.ActiveIntervals = new List<ValueAndDescription>();
            this.Slides = new List<ValueAndDescription>();
        }
    }
}
