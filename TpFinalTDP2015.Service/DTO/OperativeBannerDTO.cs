using System.Collections.Generic;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.DTO
{
    public class OperativeBannerDTO : IDTO
    {
        public OperativeBannerDTO()
        {
            this.ActiveIntervals = new List<ScheduleDTO>();
            this.Texts = new List<StaticTextDTO>();
            this.RssItems = new List<RssItemDTO>();
        }

        public int Id { get; set; }

        public IList<ScheduleDTO> ActiveIntervals { get; set; }

        public IList<StaticTextDTO> Texts { get; set; }

        public IList<RssItemDTO> RssItems { get; set; }
    }
}
