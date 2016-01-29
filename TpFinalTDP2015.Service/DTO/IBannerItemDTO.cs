using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Service.DTO
{
    interface IBannerItemDTO : IDTO
    {
        string GetText();

        string GetTitle();
    }
}
