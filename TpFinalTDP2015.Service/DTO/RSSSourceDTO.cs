using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Service.DTO
{
    class RSSSourceDTO
    {
        public object Title { get; internal set; }
        public object Description { get; internal set; }
        public object URL { get; internal set; }
        public object Items { get; internal set; }
    }
}
