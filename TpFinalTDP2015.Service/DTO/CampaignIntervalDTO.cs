using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Persistence.Model;

namespace TpFinalTDP2015.Service.DTO
{
    class CampaignIntervalDTO
    {
        public IList<Days> Days { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; internal set; }
    }
}
