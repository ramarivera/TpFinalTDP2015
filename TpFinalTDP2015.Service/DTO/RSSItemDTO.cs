using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Service.DTO
{
    public class RssItemDTO: IDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public DateTime? PublicationDate { get; set; }

    }
}
