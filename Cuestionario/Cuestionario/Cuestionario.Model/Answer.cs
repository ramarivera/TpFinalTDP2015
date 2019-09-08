using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Model
{
    public class Answer
    {
        public virtual int pId { get; set; }
        public virtual int pQuestionId { get; set; }
        public virtual string pDescription { get; set; }
        public virtual bool pCorrect { get; set; }
    }
}
