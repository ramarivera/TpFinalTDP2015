using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Service.DTO
{
    class CampaignDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<CampaignIntervalDTO> ActiveIntervals { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
