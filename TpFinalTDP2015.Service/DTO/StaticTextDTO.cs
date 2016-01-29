using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Service.DTO
{
    public class StaticTextDTO: IBannerItemDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }

        string IBannerItemDTO.GetText()
        {
            throw new NotImplementedException();
        }

        string IBannerItemDTO.GetTitle()
        {
            throw new NotImplementedException();
        }
    }
}
