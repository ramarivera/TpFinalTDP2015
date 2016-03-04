using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.UI.AdminModePages
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)
]
    public class AdminModePageInfo : System.Attribute
    {
        public AdminModePageInfo()
        {
        }

        public string Name { get; set; }
    }
}
