using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Model
{
    public class RootObject
    {
        public int ResponseCode { get; set; }
        public List<Result> Results { get; set; }
    }
}
