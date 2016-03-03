using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.BusinessLogic.DTO
{
    public class RssSourceDTO: IDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public IList<RssItemDTO> Items { get; set; }

        public RssSourceDTO()
        {
            this.Items = new List<RssItemDTO>();
        }
    }
}
