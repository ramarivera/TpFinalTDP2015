using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.BusinessLogic.DTO
{
    public class AdminBannerDTO: IDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<DateIntervalDTO> ActiveIntervals { get; set; }
        public IList<StaticTextDTO> Texts { get; set; }
        public IList<RssSourceDTO> RssSources { get; set; }

        public AdminBannerDTO()
        {
            this.ActiveIntervals = new List<DateIntervalDTO>();
            this.Texts = new List<StaticTextDTO>();
            this.RssSources = new List<RssSourceDTO>();
        }
    }
}
