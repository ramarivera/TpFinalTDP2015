using Questionnaire.Model.Enums;
using System.Collections.Generic;

namespace Questionnaire.Model
{
    /// <summary>
    /// Represents a Questionnaire's Question, which contains many Answers, and belongs to a Category and Difficulty
    /// </summary>
    public class Question : BaseEntity
    {
        private readonly ICollection<Answer> answers;
        private Answer iCorrectAnswer;

        public Question()
        {
            answers = new List<Answer>();
        }

        public virtual Category Category { get; set; }

        public virtual Difficulty Difficulty { get; set; }

        public virtual string Description { get; set; }

        public virtual QuestionType QuestionType { get; set; }

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
