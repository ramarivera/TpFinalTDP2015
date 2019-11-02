using System.Collections.Generic;

namespace Questionnaire.Model
{
    public class Question
    {
        private readonly ICollection<Answer> answers;
        private Answer iCorrectAnswer;

        public Question()
        {
            answers = new List<Answer>();
        }

        public virtual int Id { get; set; }

        public virtual Category Category { get; set; }

        public virtual Difficulty Difficulty { get; set; }

        public virtual string Description { get; set; }

        public virtual string QuestionType { get; set; }
        // TODO cambiar por QuestionType 

        public virtual IEnumerable<Answer> Answers => answers;

        public virtual Answer CorrectAnswer
        {
            get
            {
                return this.iCorrectAnswer;
            }
            set
            {
                if (value != null)
                {
                    AddAnswer(value);
                    this.iCorrectAnswer = value;
                }
            }
        }

        // TODO this property setter should probably take care of adding the answer to the list
        // of answers as well

        public virtual void AddAnswer(Answer pAnswer)
        {
            answers.Add(pAnswer);
            pAnswer.Question = this;
        }
    }
}
