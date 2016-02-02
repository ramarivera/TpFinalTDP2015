using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.Enum;

namespace TpFinalTDP2015.Service.DTO
{
    public class DayDTO: IDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public Days Value { get; set; }
        public string NameOfDay { get; set; }
    }
}
