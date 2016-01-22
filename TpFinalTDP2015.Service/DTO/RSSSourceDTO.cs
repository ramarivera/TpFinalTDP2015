using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Persistence.Model;

namespace TpFinalTDP2015.Service.DTO
{
    class RSSSourceDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public IList<RSSItem> Items { get; set; }
    }
}
