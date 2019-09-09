using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Model
{
    public class AnswerSession
    {
        public virtual int Id { get; set; }
        public virtual Category Category { get; set; }
        public virtual Difficulty Difficulty { get; set; }
        public virtual string Username { get; set; }
        public virtual int AnswerTime { get; set; }
        public virtual int Score { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual IList<UserAnswer> UserAnswers { get; set; }
    }
}
