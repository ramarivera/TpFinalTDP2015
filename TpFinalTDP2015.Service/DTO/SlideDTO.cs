using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.BusinessLogic.Enum;

namespace TpFinalTDP2015.BusinessLogic.DTO
{
    public class SlideDTO: IDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        //public tipo Image { get; set; }
        public SlideTransition Transition { get; set; }
        public int Duration { get; set; }
    }
}
