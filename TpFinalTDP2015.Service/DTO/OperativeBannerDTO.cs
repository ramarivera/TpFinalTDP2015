using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Service.DTO
{
    public class OperativeBannerDTO : IDTO
    {
        public int Id { get; set; }
        public IList<DateIntervalDTO> ActiveIntervals { get; set; }
        public IList<StaticTextDTO> Texts { get; set; }
        public IList<RssSourceDTO> RssSources { get; set; }
    }
}
