using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Model
{
    public class UserAnswer
    {
        public virtual int pId { get; set; }
        public virtual int pQuestionId { get; set; }
        public virtual int pAnswerSessionId { get; set; }
        public virtual int pChosenAnswerId { get; set; }
        public virtual bool pAnswerStatus { get; set; }
    }
}
