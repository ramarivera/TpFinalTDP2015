using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Model
{
    public class Difficulty
    {
        public virtual int pId { get; set; }
        public virtual string pDescription { get; set; }
        public virtual IList<Question> pQuestion { get; set; }
    }
    
}
