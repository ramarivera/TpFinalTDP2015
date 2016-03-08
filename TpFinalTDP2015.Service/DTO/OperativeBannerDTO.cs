using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarrSystems.TpFinalTDP2015.BusinessLogic.DTO
{
    public class OperativeBannerDTO : IDTO
    {
        public int Id { get; set; }
        public IList<ScheduleDTO> ActiveIntervals { get; set; } //TODO sacar esta merdah
        public IList<StaticTextDTO> Texts { get; set; }
        public IList<RssItemDTO> RssItems { get; set; }

        public OperativeBannerDTO()
        {
            this.ActiveIntervals = new List<ScheduleDTO>();//TODO ver arriba
            this.Texts = new List<StaticTextDTO>();
            this.RssItems = new List<RssItemDTO>();
        }
    }
}
