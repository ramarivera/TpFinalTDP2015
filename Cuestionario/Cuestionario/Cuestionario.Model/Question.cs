using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Model
{
    public class Question
    {
        public virtual int Id { get; set; }
        public virtual Category Category { get; set; }
        public virtual Difficulty Difficulty { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Answer> Answers { get; set; }

        public void AddAnswer(Answer pAnswer)
        {
            Answers.Add(pAnswer);
            pAnswer.Question = this;
        }
    }
}
