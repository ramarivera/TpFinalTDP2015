using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Model
{
    public class UserAnswer
    {
        public virtual int Id { get; set; }
        public virtual Question Question { get; set; }
        public virtual AnswerSession AnswerSession { get; set; }
        public virtual Answer ChosenAnswer { get; set; }
        public virtual bool AnswerStatus { get; set; }
    }
}
