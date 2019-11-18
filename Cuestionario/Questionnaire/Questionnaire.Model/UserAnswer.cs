namespace Questionnaire.Model
{
    /// <summary>
    /// Represent each User Answer during a Questionnaire's <see cref="Model.AnswerSession"/>
    /// </summary>
    public class UserAnswer : BaseEntity
    {
        public virtual Question Question { get; set; }

        public virtual AnswerSession AnswerSession { get; set; }

        public virtual Answer ChosenAnswer { get; set; }

        public virtual bool IsAnswerCorrect
        {
            get
            {
                return (ChosenAnswer.Id == Question.CorrectAnswer.Id);
            }
            set{}
        }
        
    }
}
