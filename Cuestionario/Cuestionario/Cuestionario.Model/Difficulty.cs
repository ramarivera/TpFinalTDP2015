using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Model
{
    public class Difficulty
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Question> Questions { get; set; }
    }
    
}
