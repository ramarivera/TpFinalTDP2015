using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrSystems.TpFinalTDP2015.BusinessLogic.DTO
{
    class ValueAndDescription
    {
        public ValueAndDescription()
        {
            this.Description = String.Empty;
            this.Value = 0;
        }

        public string Description { get; set; }

        public int Value { get; set; }
    }
}
